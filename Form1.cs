using GoodsToolReworked.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodsToolReworked
{
    public partial class Form1 : Form
    {
        private static List<Store> stores = new List<Store>();
        private string[] storeNames = new string[] { "Бахетле, ул.Ямашева 71а", "Вишневского, 29/48", "ГУМ, ул.Баумана 51а",
                                                 "Кольцо, ул.Петербургская 1", "Основной склад", "Сити-центр, Мавлютова 45", "Южный, ул.Пр.Победы 91"};
        int filled = 0;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < storeNames.Length; i++)
            {
                stores.Add(new Store(i, storeNames[i]));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductsReader reader = new ProductsReader(@"17.08.2020 UTF-8.txt", stores);
            reader.ScanDone += Reader_ScanDone;     
        }

        private void Reader_ScanDone(Store store)
        {         
            label1.Invoke((MethodInvoker)delegate () { label1.Text = $"{++filled} (+{store.ToString()})"; });
            richTextBox1.Invoke((MethodInvoker)delegate ()
            {
                richTextBox1.Text += store.GetFullInfo();
            });
        }
    }
}
