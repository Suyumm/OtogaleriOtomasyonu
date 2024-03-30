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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\otogalerivtperf.accdb");
        string foto_uzanti = "";

        private void kayit()
        {
            try
            {
                baglan.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from otomobil", baglan);
                DataSet ds = new DataSet();
                liste.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                baglan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();
            }
        }

        private void fotouzanti()
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.ShowDialog();
            pictureBox1.ImageLocation = dosya.FileName;
            foto_uzanti = dosya.FileName;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            fotouzanti();
            textBox10.Text = foto_uzanti;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("select * from otomobil where ilanno='" + textBox1.Text + "'", baglan);
                DataSet ds = new DataSet();
                ara.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                button6.Visible = true;

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

                if (MessageBox.Show("İlacı Veritabanından silmek istediğinize emin misiniz?", "İlan Sil", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    baglan.Open();
                    OleDbCommand sil = new OleDbCommand("delete from otomobil where ilanno='" + textBox1.Text + "'", baglan);
                    sil.ExecuteNonQuery();
                    textBox1.Clear();
                    MessageBox.Show("İlan Başarıyla Silindi", "İlan Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglan.Close();
                    kayit();
                }
                else
                    MessageBox.Show("İlac Silme İşlemi İptal Edildi", "İlaç Silinmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                if (MessageBox.Show("İlanın fiyatını güncellemek emin misiniz?", "Fiyat Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    baglan.Open();
                    OleDbCommand guncel = new OleDbCommand("update otomobil set fiyat='" + textBox6.Text + "' where ilanno='" + textBox1.Text + "'", baglan);
                    guncel.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox6.Clear();
                    MessageBox.Show("İlanınızın Fiyatı Başarıyla Güncellendi!", "Fiyat Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglan.Close();
                    kayit();
                }
                else
                    MessageBox.Show("İlan Fiyat Güncelleme İşlemi İptal Edildi!", "Fiyat Güncellenmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                baglan.Open();


                OleDbCommand ekle = new OleDbCommand("insert into otomobil values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')", baglan);
                ekle.ExecuteNonQuery();
                MessageBox.Show("İlan başarıyla kaydedildi", "KAYDET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                baglan.Close();
                kayit();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                baglan.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                button6.Visible = false;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                kayit();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
        }
    }
}
