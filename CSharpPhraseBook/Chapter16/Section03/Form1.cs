using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        // List 16-6
        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await Task.Run(() => DoSomething());
            toolStripStatusLabel1.Text = "終了";
        }

        // 戻り値のない同期メソッド 
        private void DoSomething() {
            Thread.Sleep(4000); // 本来は時間のかかる処理
        }

        // List 16-7
        private async void button2_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await Task.Run(() => DoSomething2());
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }

        // 戻り値のある同期メソッド 
        private long DoSomething2() {
            var sw = Stopwatch.StartNew();
            Thread.Sleep(4000); // 本来は時間のかかる処理
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        // List 16-8
        private async void button3_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await DoSomethingAsync();
            toolStripStatusLabel1.Text = "終了";
        }

        // 非同期メソッド - DoSomethingAsyncは何も戻さない 
        private async Task DoSomethingAsync() {
            await Task.Run(() => {
                Thread.Sleep(4000); // 本来は時間のかかる処理
            });
        }

        // List 16-9
        private async void button4_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await DoSomethingAsync(4000);
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }

        // 非同期メソッド - DoSomethingAsyncは、long型の値を戻す 
        private async Task<long> DoSomethingAsync(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                Thread.Sleep(4000); // 本来は時間のかかる処理
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

    }
    
}
