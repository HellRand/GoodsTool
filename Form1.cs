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
    public partial class MainForm : Form
    {
        private static List<Store> stores = new List<Store>();
        private string[] storeNames = new string[] { "Бахетле, ул.Ямашева 71а", "Вишневского, 29/48", "ГУМ, ул.Баумана 51а",
                                                 "Кольцо, ул.Петербургская 1", "Основной склад", "Сити-центр, Мавлютова 45", "Южный, ул.Пр.Победы 91"};
        int filled = 0;

        public MainForm()
        {
            InitializeComponent();
            #region Заполняем список объектов stores
            for (int i = 0; i < storeNames.Length; i++)
            {
                stores.Add(new Store(i, storeNames[i]));
            }
            #endregion
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ProductsReader reader = new ProductsReader(@"17.08.2020 UTF-8.txt", stores);
            treeView1.Nodes.Clear();
            filled = 0;
            reader.ScanDone += Reader_sCandone;     
        }

        private void Reader_sCandone(Store store)
        {
            label1.Invoke((MethodInvoker)delegate () { label1.Text = $"{filled + 1} (+{store.ToString()})"; });
            treeView1.Invoke((MethodInvoker)delegate () {
                treeView1.Nodes.Add(new TreeNode(store.ToString()));
                var node = treeView1.Nodes[filled++];


                for (int i = 0; i < store.Models.Count; i++)
                {
                    if (store.Models[i].Count != 0)
                    {
                        var modelNode = node.Nodes.Add(store.Models[i].ToString());

                        for (int j = 0; j < store.Models[i].Products.Count; j++)
                        {
                            if (store.Models[i].Products.Count != 0)
                                modelNode.Nodes.Add(store.Models[i].Products[j].ToString());
                        }
                    }
                }
            });
        }
    }
}
