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

namespace Pharmacie__Safaa
{
    public partial class Medicaments_1 : Form
    {
        public Medicaments_1()
        {
            InitializeComponent();
        }

      

        private void btn_enregistre_Click(object sender, EventArgs e)
        {
            Clsconn c = new Clsconn();
            c.connecter();
            if (txt_nom.Text == "" || txt_prix.Text == "" || txt_quantite.Text == "" || txt_nom_fabricont.Text=="" || cmb_fabricont.SelectedIndex==-1)
            {
                MessageBox.Show("information manquante");
            }
            else
            {
                try
                {

                    c.cmd.CommandText = "insert into  Fournisseur values('" + txt_nom.Text + "','" + cmb_type.SelectedItem.ToString()+  "'," + txt_quantite.Text + "," + txt_prix.Text + ",'"+cmb_fabricont.SelectedValue.ToString()+"','"+txt_nom_fabricont.Text+"')";

                    c.cmd.Connection = c.cn;
                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajout bien fait");
                    charger();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            c.deconnecter();

        }
        private void charger()
        {
            Clsconn c = new Clsconn();
            c.connecter();
            c.cmd.CommandText = "select * from Medicament";
            c.cmd.Connection = c.cn;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dgv_medicaments.DataSource = c.dt;
            c.deconnecter();
        }
        private void charger_comF()
        {
            Clsconn c = new Clsconn();
            c.connecter();
            c.cmd.CommandText = "select Id_FO from Fournisseur";
            c.cmd.Connection = c.cn;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Columns.Add("Id_FO", typeof(int));
            c.dt.Load(c.dr);
            cmb_fabricont.ValueMember = "Id_FO";
            cmb_fabricont.DataSource = c.dt;
            c.deconnecter();
        }
        private void Medicaments_1_Load(object sender, EventArgs e)
        {
            charger();
            charger_comF();
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void name()
        {
             
           Clsconn c = new Clsconn();
            c.connecter();
            c.cmd.CommandText = "select * from Medicament where Id_FO ='" + cmb_fabricont.SelectedValue.ToString() + "'";
            c.cmd.Connection = c.cn;
            c.dr = c.cmd.ExecuteReader();
            c.dr.Read();
            
                txt_nom_fabricont.Text = c.dr["Nom_FO"].ToString();
            
         
            //SqlDataAdapter sda = new SqlDataAdapter(c.cmd);
           

            //sda.Fill(c.dt);

            //foreach (DataRow da in c.dt.Rows)
            //{
            //    txt_nom_fabricont.Text = da["Nom_FO"].ToString();
            //}




            c.deconnecter();
          
        }



        private void cmb_fabricont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_fabricont_SelectionChangeCommitted(object sender, EventArgs e)
        {
            name();
        }

        private void txt_nom_fabricont_TextChanged(object sender, EventArgs e)
        {
           
        }
        int i = 0;
        private void dgv_medicaments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_nom.Text = dgv_medicaments.SelectedRows[0].Cells[1].Value.ToString();
            cmb_type.SelectedItem= dgv_medicaments.SelectedRows[0].Cells[2].Value.ToString();
            txt_quantite.Text = dgv_medicaments.SelectedRows[0].Cells[3].Value.ToString();
            txt_prix.Text = dgv_medicaments.SelectedRows[0].Cells[4].Value.ToString();
            cmb_fabricont.SelectedValue = dgv_medicaments.SelectedRows[0].Cells[5].Value.ToString();
            txt_nom_fabricont.Text= dgv_medicaments.SelectedRows[0].Cells[6].Value.ToString();
            if (txt_nom_fabricont.Text == "")
            {
                i = 0;
            }
            else
            {
                i = int.Parse(dgv_medicaments.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
