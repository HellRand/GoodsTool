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
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count != 0) treeView1.Nodes.Clear();    //Подчищаем отображение
            filled = 0;                 //Обнуляем индексатор.
            if (stores.Count != 0) stores.Clear();             //Чистим список объектов.

            #region Заполняем список объектов stores
            for (int i = 0; i < storeNames.Length; i++)
            {
                stores.Add(new Store(i, storeNames[i]));
            }
            #endregion
            ProductsReader reader = new ProductsReader(@"17.08.2020 UTF-8.txt", stores);
            reader.ScanDone += Reader_sCandone;
        }

        private void Reader_sCandone(Store store)
        {
            label1.Invoke((MethodInvoker)delegate () { label1.Text = $"{filled + 1} (+{store.ToString()})"; });
            #region Заполнение treeview
            treeView1.Invoke((MethodInvoker)delegate () {
                treeView1.Nodes.Add(new TreeNode(store.ToString()));
                var storeNode = treeView1.Nodes[filled++];
                
                // Цикл по моделям
                for (int i = 0; i < store.Models.Count; i++)
                {
                    if (store.Models[i].Count != 0)
                    {
                        var modelNode = storeNode.Nodes.Add(store.Models[i].ToString());
                        //Цикл по товарам моделей
                        for (int j = 0; j < store.Models[i].Products.Count; j++)
                        {
                            if (store.Models[i].Products.Count != 0)
                            {
                                var productNode = modelNode.Nodes.Add(store.Models[i].Products[j].ToString());
                                if (store.Models[i].Products[j].Color == "BUG!")
                                {
                                    modelNode.BackColor = Color.Red;
                                    productNode.BackColor = Color.Red;
                                    storeNode.BackColor = Color.Yellow;
                                }
                            }
                        }
                    }
                }
            });
            #endregion

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Clipboard.SetText(e.Node.Text);
            MessageBox.Show("Скопировано в буфер обмена!");
        }
    }
}
