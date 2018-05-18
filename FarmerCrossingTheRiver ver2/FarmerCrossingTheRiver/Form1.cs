using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmerCrossingTheRiver
{
    public partial class Form1 : Form
    {
        private List<MyData> _leftList;
        private List<MyData> _rightList;
        public static int count = -1;


        public Form1()
        {
            _leftList = CreateList();
            _rightList = new List<MyData>();
            InitializeComponent();
            SetListBoxDataSource();
            ChangeDate();
        }

        private static List<MyData> CreateList()
        {
            var list = new List<MyData>();
            list.Add(new MyData() { ItemNumber = 0, Item = "農夫" });
            list.Add(new MyData() { ItemNumber = 1, Item = "草" });
            list.Add(new MyData() { ItemNumber = 2, Item = "羊" });
            list.Add(new MyData() { ItemNumber = 3, Item = "狼" });
            return list;
        }

        private void SetListBoxDataSource()//設定兩個ListBox的SelectionMode
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox2.SelectionMode = SelectionMode.MultiSimple;
        }

        private void ChangeDate()//設定兩個ListBox的資料來源
        {
            var leftNumber = _leftList.OrderBy((x) => x.ItemNumber);
            var rightNumber = _rightList.OrderBy((x) => x.ItemNumber);
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.DataSource = leftNumber.ToList();
            listBox1.DisplayMember = "Item";
            listBox2.DataSource = rightNumber.ToList();
            listBox2.DisplayMember = "Item";
            count += 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (count % 2 == 0) //判斷哪一邊(左邊)
            {
                if (listBox1.SelectedItem == null)
                {
                    MessageBox.Show("必須選擇一個項目，最多不能超過二個項目");
                }
                else if (((MyData)listBox1.SelectedItem).Item != "農夫")//農夫不在
                    MessageBox.Show("物品不能自己過河");

                else if (listBox1.SelectedItems.Count < 3 && listBox1.SelectedItems.Count > 0)//判斷選擇的項目數，必須1<數目<3
                {
                    foreach (var i in listBox1.SelectedItems)
                    {
                        _leftList.Remove((MyData)i);
                        _rightList.Add((MyData)i);
                    }
                    ChangeDate();
                    
                    if (((List<MyData>)listBox1.DataSource).Any((x) => x.Item == "狼")
                                && ((List<MyData>)listBox1.DataSource).Any((x) => x.Item == "草")
                                && ((List<MyData>)listBox1.DataSource).Any((x) => x.Item == "羊"))
                    {
                        MessageBox.Show("Game Over！！羊吃掉草，狼吃掉羊");
                        this.Close();
                    }
                    else if (((List<MyData>)listBox1.DataSource).Any((x) => x.Item == "草")
                                && ((List<MyData>)listBox1.DataSource).Any((x) => x.Item == "羊"))
                    {
                        MessageBox.Show("Game Over！！羊吃掉草");
                        this.Close();
                    }

                    else if (((List<MyData>)listBox1.DataSource).Any((x) => x.Item == "狼")
                        && ((List<MyData>)listBox1.DataSource).Any((x) => x.Item == "羊"))
                    {
                        MessageBox.Show("Game Over！！狼吃掉羊");
                        this.Close();
                    }
                    else if (((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "狼")
                                && ((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "草")
                                && ((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "羊")
                                && ((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "農夫"))
                    {
                        MessageBox.Show("WIN!");
                    }
                }
                else
                    MessageBox.Show("不能超過二個項目");
            }
            else//(右邊)
            {
                if (listBox2.SelectedItem == null)
                {
                    MessageBox.Show("必須選擇一個項目，最多不能超過二個項目");
                }
                else if (((MyData)listBox2.SelectedItem).Item != "農夫")//農夫不在
                    MessageBox.Show("物品不能自己過河");

                else if (listBox2.SelectedItems.Count < 3 || listBox2.SelectedItems.Count > 0)//判斷選擇的項目數，必須1<數目<3
                {
                    foreach (var i in listBox2.SelectedItems)
                    {
                        _leftList.Add((MyData)i);
                        _rightList.Remove((MyData)i);
                    }
                    ChangeDate();

                    if (((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "狼")
                                && ((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "草")
                                && ((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "羊"))
                    {
                        MessageBox.Show("Game Over！！羊吃掉草，狼吃掉羊");
                        this.Close();
                    }
                    
                    else if (((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "草")
                                && ((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "羊"))
                    {
                        MessageBox.Show("Game Over！！羊吃掉草");
                        this.Close();
                    }

                    else if (((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "狼")
                               && ((List<MyData>)listBox2.DataSource).Any((x) => x.Item == "羊"))
                    {
                        MessageBox.Show("Game Over！！狼吃掉羊");
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("不能超過二個項目");
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            count = -1;
            _leftList = CreateList();
            _rightList = new List<MyData>();
            SetListBoxDataSource();
            ChangeDate();
        }
    }
}
