using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

// p.317「コラム：JSON.NETの利用」のコード

namespace JsonNet {

    class Program {
        static void Main(string[] args) {
            SerializeJson();
            DeserializeJson();
            SerializeJson2();
            Console.ReadLine();
        }

        private static void SerializeJson() {
            var novel = new Novel {
                Author = "ロバート・A・ハインライン",
                Title = "夏への扉",
                Published = 1956,
            };

            using (var stream = new StreamWriter(@"sample.json"))
            using (var writer = new JsonTextWriter(stream)) {
                JsonSerializer serializer = new JsonSerializer {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                };
                serializer.Serialize(writer, novel);
            }
        }

        private static void DeserializeJson() {
            using (var stream = new StreamReader(@"sample.json"))
            using (var writer = new JsonTextReader(stream)) {
                JsonSerializer serializer = new JsonSerializer {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                };
                var novel = serializer.Deserialize<Novel>(writer);
                Console.WriteLine(novel);
            }
        }


        // これは、書籍には掲載していないコード。
        private static void SerializeJson2() {
            var novel = new Novelist {
                Name = "アーサー・C・クラーク",
                Birth = new DateTime(1917, 12, 16),
                Masterpieces = new[] { "2001年宇宙の旅", "幼年期の終り", },
            };
            {
                using (var stream = new StreamWriter(@"sample2.json"))
                using (var writer = new JsonTextWriter(stream)) {
                    JsonSerializer serializer = new JsonSerializer {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    };
                    serializer.Serialize(writer, novel);
                }
            }
            {
                using (var stream = new MemoryStream()) {
                    var serializer = new DataContractJsonSerializer(novel.GetType(),
                                      new DataContractJsonSerializerSettings {
                                          DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
                                      });
                    serializer.WriteObject(stream, novel);
                    stream.Close();
                    var jsonText = Encoding.UTF8.GetString(stream.ToArray());
                    Console.WriteLine(jsonText);
                }
            }
        }
    }
    [DataContract(Name = "novelist")]

    class Novelist {
        [DataMember(Name ="name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "birth", Order = 2)]
        public DateTime Birth { get; set; }

        [DataMember(Name = "masterpieces", Order = 3)]
        public string[] Masterpieces { get; set; }
    }

}
