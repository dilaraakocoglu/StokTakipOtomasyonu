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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btn_rapor_goster_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP - HKNTLBK\\DILARA;Initial Catalog = StokTakipSistemi; Integrated Security = True");

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM OdaDemirbasAtama where OdaAdi='"+ cmb_rapor_odaadi.Text+ "' ";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "OdaDemirbasAtama");
                dt_rapor.DataSource = ds.Tables["OdaDemirbasAtama"];
            }
        }

        private void btn_rapor_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
