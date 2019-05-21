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
    public partial class Islemler : Form
    {
        public Islemler()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbl_bilgi.Text = "Fakülte Kodu + Bölüm Kodu + Demirbaş Türü şeklinde olacak. ";
        }
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP - HKNTLBK\\DILARA;Initial Cataslog = StokTakipSistemi; Integrated Security = True");
        

        private void btn_denirbasekle_Click(object sender, EventArgs e)
        {
            
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "INSERT INTO Demirbas(DemirbasAdi,Fiyat,AlimTarihi,Adet)VALUES('"+txt_demirbasadi.Text+"','" + txt_fiyat.Text + "','" + dt_alımtarihi.Text + "','" + txt_demirabsadet.Text+"') ";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Demirbaş Ekleme Başarıyla Tamamlanmıştır.");
            }

        }

        private void btn_demirbasturekle_Click(object sender, EventArgs e)
        {
            grp_demirbasturadi.Visible = true;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            //SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HKNTLBK\FATIH;Initial Catalog=StokTakip;Integrated Security=True");
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "INSERT INTO DemirbasTurleri(DemirbasTurAdi) VALUES ('" + txt_demirbasturadi.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Demirbas Türü Ekleme Basarıyla Tamamlandı");


                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT DemirbasTurAdi FROM DemirbasTurleri";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = komut.ExecuteReader();
                cmb_demirbasturu.Items.Add(txt_demirbasturadi.Text);
                baglanti.Close();
                txt_demirbasturadi.Text = "";
                grp_demirbasturadi.Visible = false;
            }
        }

        private void Islemler_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT DemirbasTurAdi FROM DemirbasTurleri";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    cmb_demirbasturu.Items.Add(dr["DemirbasTurAdi"]);
                }
                baglanti.Close();
            }
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT FakulteAdi FROM Fakulteler";
                cmd.CommandText = "SELECT DepartmanAdi FROM Departmanlar";
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_ekleDepartman.Items.Add(dr["DepartmanAdi"]);
                    cmb_ekle_fakulte.Items.Add(dr["FakulteAdi"]);
                    cmb_demırgınfaklt.Items.Add(dr["FakulteAdi"]);
                    cmb_demirgundepartman.Items.Add(dr["DepartmanAdi"]);
                    cmb_odagun_fakulte.Items.Add(dr["FakulteAdi"]);
                    cmb_odagun_departman.Items.Add(dr["DepartmanAdi"]);
                    cmb_oda_fakulteadi.Items.Add(dr["FakulteAdi"]);
                    cmb_oda_departmanadi.Items.Add(dr["DepartmanAdi"]);
                    cmb_dep_gunfaklt.Items.Add(dr["FakulteAdi"]);
                    cmb_Departman_fakulte.Items.Add(dr["FakulteAdi"]);
                }
                baglanti.Close();
               
            }
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand();
                kmt.CommandText = "SELECT OdaAdi FROM Odalar";
                kmt.CommandText = "SELECT DemirbasAdi FROM Demirbas";
                kmt.CommandText = "SELECT PersonelAdi FROM Personel";
                kmt.Connection = baglanti;
                kmt.CommandType = CommandType.Text;
                SqlDataReader okuyucu;
                okuyucu = kmt.ExecuteReader();
                while (okuyucu.Read())
                {
                    cmb_OdaAdi.Items.Add(okuyucu["OdaAdi"]);
                    cmb_DemirbasAdi.Items.Add(okuyucu["DemirbasAdi"]);
                    cmb_odaPersonel.Items.Add(okuyucu["PersonelAdi"]);
                }
            }
            fakultelistele();
            fakultelisteleme();
            departmanlistele();
            departmanlisteleme();
        }

        private void fakultelistele()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT FakulteAdi FROM Fakulteler";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    cmb_ekle_fakulte.Items.Add(dr["FakulteAdi"]);
                }
                baglanti.Close();
            }
        }
        private void fakultelisteleme()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT FakulteAdi FROM Fakulteler";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    cmb_demırgınfaklt.Items.Add(dr["FakulteAdi"]);
                }
                baglanti.Close();
            }
        }
        private void departmanlistele()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT DeparmanAdi FROM Departmanlar";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    cmb_ekle_fakulte.Items.Add(dr["DeparmanAdi"]);
                }
                baglanti.Close();
            }
        }
        private void departmanlisteleme()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT DeparmanAdi FROM Departmanlar";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    cmb_demırgınfaklt.Items.Add(dr["DeparmanAdi"]);
                }
                baglanti.Close();
            }
        }
        private void btn_goster_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Demirbas where DemirbasAdi='" + txt_gos_demirbas_adi.Text + "'";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Demirbas");
                dtgw_silme.DataSource = ds.Tables["Demirbas"];
                baglanti.Close();
            }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "Delete from Demirbas where id=@numara";
                cmd.Parameters.AddWithValue("@numara", dtgw_silme.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Kayıt silinmiştir");
                baglanti.Close();
            }
            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("Silme İşlemi Yapılmadı");
            }

        }

        private void btn_listeleme_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Demirbas ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Demirbas");
                dtg_listeleme.DataSource= ds.Tables["Demirbas"];
            }
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Demirbas ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Demirbas");
                dtg_listele.DataSource = ds.Tables["Demirbas"];
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "UPDATE Demirbas set DemirbasKodu='" + txt_gunDemirbaskodu.Text + "',DemirbasAdi='" + txt_gunDemirbasAdi.Text + "',Fiyat='" + txt_gunfiyat.Text + "', DemirbasTur='" + txt_gunDemirbasTuru.Text + "',Fakulte='" + cmb_demırgınfaklt.Text + "',AlımTarihi='"+ dt_gunalimtarihi.Text + "',Departman='" + cmb_demirgundepartman.Text + "',Adet='"+txt_gunAdet.Text+"'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Güncelleme Tamamlanmıştır");
            }
        }

        private void dtg_listele_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_gunDemirbaskodu.Text = dtg_listele.CurrentRow.Cells[1].Value.ToString();
            txt_gunDemirbasAdi.Text= dtg_listele.CurrentRow.Cells[2].Value.ToString();
            txt_gunfiyat.Text= dtg_listele.CurrentRow.Cells[3].Value.ToString();
            txt_gunDemirbasTuru.Text= dtg_listele.CurrentRow.Cells[4].Value.ToString();
            cmb_demırgınfaklt.Text= dtg_listele.CurrentRow.Cells[5].Value.ToString();
            cmb_demirgundepartman.Text= dtg_listele.CurrentRow.Cells[6].Value.ToString();
            txt_gunAdet.Text= dtg_listele.CurrentRow.Cells[7].Value.ToString();

        }

        private void btn_fakulteGoster_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Fakulteler ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Fakulteler");
                dt_fakulteEkle.DataSource = ds.Tables["Fakulteler"];
            }
        }

        private void btn_fakulteEkle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "INSERT INTO Fakulteler(FakulteAdi) VALUES ('" + txt_fakulteAdi.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Fakülte Ekleme Basarıyla Tamamlandı");
            }

        }

        private void btn_fakulte_goster_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Fakulteler ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Fakulteler");
                dt_fakulte_sil.DataSource = ds.Tables["Fakulteler"];
            }

        }

        private void btn_fakulte_sil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "Delete from Fakulteler where id=@numara";
                cmd.Parameters.AddWithValue("@numara", dt_fakulte_sil.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Kayıt silinmiştir");
                baglanti.Close();
            }
            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("Silme İşlemi Yapılmadı");
            }
        }

        private void btn_Fakgöster_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Fakulteler ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Fakulteler");
                dt_fakulte_guncelle.DataSource = ds.Tables["Fakulteler"];
            }
        }

        private void btn_faklt_guncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "UPDATE Fakulteler set FakulteAdi='" + txt_fakulteGuncelle.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Güncelleme Tamamlanmıştır");
            }

        }

        private void btn_departmanEkle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "INSERT INTO Departmanlar(DepartmanAdi,FakulteAdi) VALUES ('"+ txt_Departman_Adi.Text + "','" + cmb_Departman_fakulte.Text + "')";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Departmanlar");
                dt_departman_ekle.DataSource = ds.Tables["Departmanlar"];
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Departmanlara Ekleme Basarıyla Tamamlandı");
            }
        }

        private void btn_departma_listele_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Departmanlar ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Departmanlar");
                dt_departman_sil.DataSource = ds.Tables["Departmanlar"];
            }
        }

        private void btn_departman_sil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "Delete from Departmanlar where id=@numara";
                cmd.Parameters.AddWithValue("@numara", dt_departman_sil.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Kayıt silinmiştir");
                baglanti.Close();
            }
            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("Silme İşlemi Yapılmadı");
            }

        }

        private void btn_departmanlistele_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Departmanlar ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Departmanlar");
                dt_departman_guncelle.DataSource = ds.Tables["Departmanlar"];
            }

        }

        private void btn_departman_guncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "UPDATE Departmanlar set DepartmanAdi='"+ txt_depart_guncelad.Text+ "' , FakulteAdi='" + cmb_dep_gunfaklt.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Güncelleme Tamamlanmıştır");
            }
        }

        private void btn_odaekle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "INSERT INTO Odalar(OdaAdi,DepartmanAdi,FakulteAdi) VALUES ('" + txt_odaAdi.Text + "','" + cmb_oda_departmanadi.Text + "','" + cmb_oda_fakulteadi.Text + "')";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Odalar");
                dt_oda_ekle.DataSource = ds.Tables["Odalar"];
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Departmanlara Ekleme Basarıyla Tamamlandı");
            }
        }

        private void btn_odagoster_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Odalar ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Odalar");
                dt_oda_sil.DataSource = ds.Tables["Odalar"];
            }
        }

        private void btn_odasil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "Delete from Odalar where id=@numara";
                cmd.Parameters.AddWithValue("@numara", dt_oda_sil.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Kayıt silinmiştir");
                    //MessageBox.Show("Güncel liste için listeleme/gösterme işlemini tekrar yapınız...");
                baglanti.Close();
            }
            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("Silme İşlemi Yapılmadı");
            }
        }

        private void btn_odalisteleme_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Odalar ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Odalar");
                dt_oda_sil.DataSource = ds.Tables["Odalar"];
            }
        }

        private void btn_odaguncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "UPDATE Odalar set OdaAdi='"+ txt_odaguncelle_adi .Text+ "',DepartmanAdi='"+ cmb_odagun_departman.Text+ "', FakulteAdi='" + cmb_odagun_fakulte.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Güncelleme Tamamlanmıştır");
            }
        }

        private void btn_atamayap_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "INSERT INTO OdaDemirbasAtama(OdaAdi,DemirbasAdi,Adet,PersonelAdi) VALUES ('" + cmb_OdaAdi.Text + "','" + cmb_DemirbasAdi.Text + "','" + txt_odaAdet.Text + "','" + cmb_odaPersonel.Text + "')";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "OdaDemirbasAtama");
                dt_oda_atama.DataSource = ds.Tables["OdaDemirbasAtama"];
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("Departmanlara Ekleme Basarıyla Tamamlandı");
            }
        }

        private void btn_atamagoster_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM OdaDemirbasAtama ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "OdaDemirbasAtama");
                dt_oda_atama.DataSource = ds.Tables["OdaDemirbasAtama"];
            }
        }

        private void btn_bilgi_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void txt_fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void txt_demirabsadet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void txt_gunAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void txt_gunfiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void txt_odaAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void txt_demirbasadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void txt_gos_demirbas_adi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void txt_gunDemirbasAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void txt_gunDemirbasTuru_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void txt_odaAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void txt_odaguncelle_adi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void txt_Departman_Adi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void txt_depart_guncelad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }
    }
}
