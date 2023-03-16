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


namespace NotKayıtSistemi
{
    public partial class FrmOgrenciDetar : Form
    {
        public FrmOgrenciDetar()
        {
            InitializeComponent();
        }


        public string numara;

        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-TCEOMIL\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");

        private void FrmOgrenciDetar_Load(object sender, EventArgs e)
        {
            lblnumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDRES where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblisim.Text = oku[2].ToString() + " " + oku[3].ToString();
                lblsınav1.Text = oku[4].ToString();
                lblsınav2.Text = oku[5].ToString();
                lblsınav3.Text = oku[6].ToString();
                lblOrtalama.Text = oku[7].ToString();
                lblDurum.Text = oku[8].ToString();
            }
            baglanti.Close();
        }
    }
}
