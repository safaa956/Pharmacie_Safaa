using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie__Safaa
{
    public partial class FrmClients : Form
    {
        public FrmClients()
        {
            InitializeComponent();
        }

        private void btn_enregistrer_Click(object sender, EventArgs e)
        {
            Clsconn c = new Clsconn();
            c.connecter();
            if (txt_nom.Text == "" || txt_tel.Text == "" || txt_adress.Text == "" || cmb_sex.SelectedIndex == -1)
            {
                MessageBox.Show("information manquante");
            }
            else
            {
                c.cmd.CommandText = "insert into Client  values ('" + txt_nom.Text + "','" + txt_adress.Text + "'," + txt_tel.Text + "," + dtm.Value.Date + ",'" + cmb_sex.SelectedItem.ToString() + "')";
                c.cmd.Connection = c.cn;
                c.cmd.ExecuteNonQuery();
                MessageBox.Show("dddd");
            }
            c.deconnecter();
        }
        private void charger()
        {
            Clsconn c = new Clsconn();
            c.connecter();
            c.cmd.CommandText = "select * from Client";
            c.cmd.Connection = c.cn;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dgv_client.DataSource = c.dt;
            c.deconnecter();
        }

        private void FrmClients_Load(object sender, EventArgs e)
        {
            charger();
        }

     

        private void dgv_client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
