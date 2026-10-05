using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp12 // Kendi proje adýnýz
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> markalar = new Dictionary<string, List<string>>()
        {
            { "Audi", new List<string> { "A3", "A4", "A6", "Q5" } },
            { "BMW", new List<string> { "1 Serisi", "3 Serisi", "5 Serisi", "X5" } },
            { "Mercedes", new List<string> { "A-Serisi", "C-Serisi", "E-Serisi" } }
        };

        Dictionary<string, List<string>> paketler = new Dictionary<string, List<string>>()
        {
            // Audi
            { "A3", new List<string> { "Advanced", "S Line", "Design" } },
            { "A4", new List<string> { "Design", "Sport", "Dynamic" } },
            { "A6", new List<string> { "Sport", "Design", "Quattro Edition" } },
            { "Q5", new List<string> { "Design", "Sport", "S Line" } },

            // BMW
            { "1 Serisi", new List<string> { "Sport Line", "Urban Line", "M Sport" } },
            { "3 Serisi", new List<string> { "First Edition", "Sport Line", "Luxury Line", "M Sport" } },
            { "5 Serisi", new List<string> { "Luxury Line", "M Sport", "Exclusive" } },
            { "X5", new List<string> { "xLine", "M Sport", "Pure Excellence" } },

            // Mercedes
            { "A-Serisi", new List<string> { "Style", "Progressive", "AMG Line" } },
            { "C-Serisi", new List<string> { "Avantgarde", "Exclusive", "AMG Line" } },
            { "E-Serisi", new List<string> { "Avantgarde", "Exclusive", "AMG Line", "Edition 1" } }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListeyiGuncelle();
        }

        private void ListeyiGuncelle()
        {
            listBox1.Items.Clear();
            foreach (var marka in markalar.Keys)
            {
                listBox1.Items.Add(marka);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            if (listBox1.SelectedItem != null)
            {
                string secilenMarka = listBox1.SelectedItem.ToString() ?? "";

                if (!string.IsNullOrEmpty(secilenMarka) && markalar.ContainsKey(secilenMarka))
                {
                    foreach (var model in markalar[secilenMarka])
                    {
                        listBox2.Items.Add(model);
                    }
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            if (listBox2.SelectedItem != null)
            {
                string secilenModel = listBox2.SelectedItem.ToString() ?? "";

                if (!string.IsNullOrEmpty(secilenModel) && paketler.ContainsKey(secilenModel))
                {
                    foreach (var paket in paketler[secilenModel])
                    {
                        listBox3.Items.Add(paket);
                    }
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string yeniMarka = textBox1.Text.Trim();
                if (!markalar.ContainsKey(yeniMarka))
                {
                    markalar.Add(yeniMarka, new List<string>());
                    ListeyiGuncelle();
                    textBox1.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string silinecek = listBox1.SelectedItem.ToString() ?? "";
                if (!string.IsNullOrEmpty(silinecek))
                {
                    markalar.Remove(silinecek);
                    ListeyiGuncelle();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                }
            }
        }

     
        

        }
    }
