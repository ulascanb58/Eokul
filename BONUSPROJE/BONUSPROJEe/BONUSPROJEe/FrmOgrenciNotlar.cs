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


namespace BONUSPROJEe
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QE2NQQH\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        public string test;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA DURUM FROM TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID=1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
          //  this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            // 
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("SELECT * FROM TBLOGRENCILER WHERE OGRID =@P2",baglanti);
            komut.Parameters.AddWithValue("@p2", test);
            SqlDataReader dr = komut1.ExecuteReader();
            
            while(dr.Read())
            {
                this.Text = dr[0] + "" + dr[1];
            }
            baglanti.Close();
        }
    }
}
