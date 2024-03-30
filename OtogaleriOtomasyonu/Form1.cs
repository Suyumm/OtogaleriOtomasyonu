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

namespace OtogaleriOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\otogalerivtperf.accdb");


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
                checkBox1.Text = "Şifreyi Gizle";
            }
            else if (checkBox1.Checked == false)
            {
                textBox2.PasswordChar = '*';
                checkBox1.Text = "Şifreyi Göster";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == textBox5.Text)
                {
                    baglan.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into uye values('" + textBox4.Text + "','" + textBox3.Text + "')", baglan);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Eklendi", "Kullanıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglan.Close();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else if (textBox3.Text != textBox5.Text)
                {
                    MessageBox.Show("Lütfen Şifrenizi Doğru Giriniz!!", "Hatalı Şifre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                OleDbCommand ekle = new OleDbCommand("select uye_adisoyadi from uye where uye_adisoyadi='" + textBox8.Text + "'", baglan);
                OleDbDataReader oku = ekle.ExecuteReader();
                if (oku.Read() == true)
                {
                    panel1.Visible = true;
                }
                else
                    MessageBox.Show("Kullanıcı Bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                OleDbCommand giris = new OleDbCommand("select * from uye where uye_adisoyadi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'", baglan);
                OleDbDataReader oku = giris.ExecuteReader();
                if (oku.Read() == true)
                {
                    MessageBox.Show("Hoşgeldiniz sayın " + textBox1.Text);
                    Form1 f1 = new Form1();
                    this.Hide();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!!", "Giriş Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglan.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == textBox5.Text)
                {
                    baglan.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into uye values('" + textBox4.Text + "','" + textBox3.Text + "')", baglan);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Eklendi", "Kullanıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglan.Close();
                    textBox3.Clear();
                        textBox4.Clear();
                    textBox5.Clear();
                }
                else if (textBox3.Text != textBox5.Text)
                {
                    MessageBox.Show("Lütfen Şifrenizi Doğru Giriniz!!", "Hatalı Şifre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == textBox7.Text)
                {
                    baglan.Open();
                    OleDbCommand ekle = new OleDbCommand("update uye set sifre='" + textBox6.Text + "'", baglan);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Şifreniz Başarıyla Güncellendi", "Şifre Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglan.Close();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                }
                else if (textBox6.Text != textBox7.Text)
                {
                    MessageBox.Show("Lütfen Şifrenizi Doğru Giriniz!!", "Hatalı Şifre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();

            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox6.PasswordChar = '\0';
                textBox7.PasswordChar = '\0';
                checkBox3.Text = "Şifreyi Gizle";
            }
            else if (checkBox3.Checked == false)
            {
                textBox6.PasswordChar = '*';
                textBox7.PasswordChar = '*';
                checkBox3.Text = "Şifreyi Göster";
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
                checkBox1.Text = "Şifreyi Gizle";
            }
            else if (checkBox1.Checked == false)
            {
                textBox2.PasswordChar = '*';
                checkBox1.Text = "Şifreyi Göster";
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox3.PasswordChar = '\0';
                textBox5.PasswordChar = '\0';
                checkBox1.Text = "Şifreyi Gizle";
            }
            else if (checkBox2.Checked == false)
            {
                textBox3.PasswordChar = '*';
                textBox5.PasswordChar = '*';
                checkBox2.Text = "Şifreyi Göster";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == textBox5.Text)
                {
                    baglan.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into uye (kullanici_adi,sifre) values('" + textBox4.Text + "','" + textBox3.Text + "')", baglan);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Eklendi", "Kullanıcı Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglan.Close();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else if (textBox3.Text != textBox5.Text)
                {
                    MessageBox.Show("Lütfen Şifrenizi Doğru Giriniz!!", "Hatalı Şifre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();

            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                OleDbCommand ekle = new OleDbCommand("select uye_adisoyadi from uye where uye_adisoyadi='" + textBox8.Text + "'", baglan);
                OleDbDataReader oku = ekle.ExecuteReader();
                if (oku.Read() == true)
                {
                    panel1.Visible = true;
                }
                else
                    MessageBox.Show("Kullanıcı Bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                OleDbCommand giris = new OleDbCommand("select * from uye where kullanici_adi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'", baglan);
                OleDbDataReader oku = giris.ExecuteReader();
                if (oku.Read() == true)
                {
                    MessageBox.Show("Hoşgeldiniz sayın " + textBox1.Text);
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!!", "Giriş Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglan.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();
            }
        }
    }
}
