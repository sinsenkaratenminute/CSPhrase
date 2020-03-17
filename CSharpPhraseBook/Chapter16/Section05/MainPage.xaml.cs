using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace Section05 {
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        // List 16-12
        private async void button_Click(object sender, RoutedEventArgs e) {
            var texts = await GetLinesAsync();
            textBlock.Text = texts[0];
        }

        private async Task<string[]> GetLinesAsync() {
            var picker = new FileOpenPicker {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            picker.FileTypeFilter.Add(".txt");
            StorageFile file = await picker.PickSingleFileAsync();
            var texts = await FileIO.ReadLinesAsync(file);
            return texts.ToArray();
        }

        // List 16-13
        private async void button2_Click(object sender, RoutedEventArgs e) {
            await WriteTexts("sample.txt");
        }

        private async Task WriteTexts(string filename) {
            var lines = new string[] {
                "色はにほへど　散りぬるを",
                "我が世たれぞ　常ならむ",
                "有為の奥山　今日越えて",
                "浅き夢見じ　酔ひもせず",
           };

            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteLinesAsync(file, lines);
        }

        // List 16-14
        private async void button3_Click(object sender, RoutedEventArgs e) {
            var lines = await ReadLines("sample.txt");
            textBlock.Text = String.Join("\n", lines);
        }

        private async Task<IEnumerable<string>> ReadLines(string filename) {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync(filename);
            var lines = await FileIO.ReadLinesAsync(file);
            return lines;
        }

        // List 16-15
        private async void button4_Click(object sender, RoutedEventArgs e) {
            var lines = await ReadLinesFromInstallFile();
            textBlock.Text = String.Join("\n", lines);
        }

        private async Task<IEnumerable<string>> ReadLinesFromInstallFile() {
            StorageFolder installedFolder = Package.Current.InstalledLocation;
            StorageFolder dataFolder = await installedFolder.GetFolderAsync("AppData");
            StorageFile sampleFile = await dataFolder.GetFileAsync("sample.txt");
            var lines = await FileIO.ReadLinesAsync(sampleFile);
            return lines;
        }
    }
}
