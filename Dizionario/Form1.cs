using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dizionario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, double> accounts = new Dictionary<string, double>();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox2.Text);
                accounts.Add(textBox1.Text, a);
                Aggiorna();
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    string s = listView1.SelectedItems[i].Text;
                    accounts.Remove(s);
                    Aggiorna();
                }
            }
           

        }
        public void Aggiorna()
        {
            listView1.Items.Clear();
            double b = 0;
            foreach (KeyValuePair<string, double> p in accounts)
            {
                string[] row = { p.Key, p.Value.ToString() };
                var ListViewItem = new ListViewItem(row);
                listView1.Items.Add(ListViewItem);
                b = b+p.Value; 
            }
            label1.Text = b.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    MessageBox.Show("errore");
                    string s = listView1.SelectedItems[i].Text;
                    textBox1.Text = s;
                    textBox2.Text = accounts[s].ToString();
                    accounts.Remove(s);
                    Aggiorna();
                }
            }
            else
                MessageBox.Show("Errore");
        }
    }
}
