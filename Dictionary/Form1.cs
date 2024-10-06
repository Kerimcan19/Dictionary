using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Dictionary
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\vt_sozluk.accdb");
        private void Form1_Load(object sender, EventArgs e)
        {
            


        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand eklekomutu = new OleDbCommand("insert into ingturkce(ingilizce,turkce)values('" +textBox1.Text + "','" + textBox2.Text + "')",connection);
                eklekomutu.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Sözcük Veri Tabanina Eklendi !", "Veri Tabani Islemleri");
                textBox1.Clear();
                textBox2.Clear();

            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri Tabani Islemleri");
                connection.Close();
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand guncellekomutu = new OleDbCommand("update ingturkce set turkce='" + textBox2.Text + "'where ingilizce='" + textBox1.Text + "'", connection);
                guncellekomutu.ExecuteNonQuery ();
                connection.Close();
                MessageBox.Show("Sozcuk Veri Tabaninda Guncellendi !", "Veri Tabani Islemleri");
                textBox1.Clear (); textBox2.Clear();

            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri Tabani Islemleri");
                connection.Close();
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand silkomutu = new OleDbCommand("delete from ingturkce where ingilizce='" + textBox1.Text + "'", connection);
                silkomutu.ExecuteNonQuery ();
                connection.Close();
                MessageBox.Show("Sozcuk Veri Tabanindan Silindi !","Veri Tabani Islemleri");
                textBox1.Clear (); textBox2.Clear();

            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message,"Veri Tabani Islemleri");
                connection.Close();
                
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                connection.Open();
                OleDbCommand aramakomutu = new OleDbCommand("select ingilizce,turkce from ingturkce where ingilizce like'"+textBox1.Text+"%'",connection);
                OleDbDataReader read = aramakomutu.ExecuteReader();
                while (read.Read())
                {
                    listBox1.Items.Add(read["ingilizce"].ToString() + "=" + read["turkce"].ToString());
                }
                connection.Close();

            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri Tabani Islemleri");
                connection.Close();

            }

        }

           
    
    }
}
