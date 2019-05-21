using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YazilimSınamaProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            int hata = 0;
            string kulad = "";
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HKNTLBK\\DILARA;Initial Catalog=StokTakipSistemi;Integrated Security=True");
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT KullanıcıAdi,Yetki,Sifre FROM Kullanıcılar WHERE Yetki=1 and KullanıcıAdi='" + txt_kul_ad.Text + "'and Sifre='" + txt_sifre.Text + "'";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == false)
                {
                    hata = 1;
                    MessageBox.Show("Kullanıcı adı bulunamadı");
                }
                int knt = 0;
               
                while (dr.Read())
                {
                    knt = 1;
                    kulad = dr["KullanıcıAdi"].ToString();

                }

                if(hata==0)
                {
                    if (knt == 1)
                    {
                        Islemler frm2 = new Islemler();
                        frm2.Show();
                        this.Hide();
                    }
                    else if (knt == 0)
                    {
                        Form3 frm3 = new Form3();
                        frm3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
