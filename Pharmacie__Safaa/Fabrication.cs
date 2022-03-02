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
    public partial class Fabrication : Form
    {
        public Fabrication()
        {
            InitializeComponent();
        }
        int i;
        private void btn_enregistrer_Click(object sender, EventArgs e)
        {
            Clsconn c = new Clsconn();
            c.connecter();
            if (txt_adress.Text == "" || txt_nom.Text == "" || txt_tel.Text == "")
            {
                MessageBox.Show("information manquante");
            }
            else
            {
                try
                {
                 
                    c.cmd.CommandText = "insert into  Client values('" + txt_nom.Text+ "','" +txt_adress.Text+ "'," +txt_tel.Text+",'"+bunifo_date.Value.Date+"')" ;
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
            c.cmd.CommandText = "select * from Fournisseur";
            c.cmd.Connection = c.cn;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dgv_fabrication.DataSource = c.dt;
            c.deconnecter();
        }

        private void Fabrication_Load(object sender, EventArgs e)
        {
            charger();
        }
        
        private void dgv_fabrication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_nom.Text = dgv_fabrication.SelectedRows[0].Cells[1].Value.ToString();
            txt_adress.Text = dgv_fabrication.SelectedRows[0].Cells[2].Value.ToString();
            txt_tel.Text = dgv_fabrication.SelectedRows[0].Cells[3].Value.ToString();
            bunifo_date.Text = dgv_fabrication.SelectedRows[0].Cells[3].Value.ToString();
            if (txt_tel.Text =="")
            {
                i= 0;
            }
            else
            {
                i =int.Parse(dgv_fabrication.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btn_vider_Click(object sender, EventArgs e)
        {
            
            txt_adress.Text = string.Empty;
            txt_nom.Text = string.Empty;
            txt_tel.Text = string.Empty;
            bunifo_date.Value = DateTime.Now;
            i = 0;
        }

        

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            Clsconn c = new Clsconn();
            c.connecter();
            if (i==0)
            {
                MessageBox.Show("Sélectionner le fabricant");
            }
            else
            {
                try
                {
                    c.cmd.CommandText = "delete from Fournisseur where Id_FO=@k";
                    
                    c.cmd.Connection = c.cn;
                    c.cmd.Parameters.AddWithValue("@k", i);
                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("La Suppression bien fait");
                    charger();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            c.deconnecter();
        }

        private void btn_Éditer_Click(object sender, EventArgs e)
        {

            Clsconn c = new Clsconn();
            c.connecter();
            if (txt_adress.Text == "" || txt_nom.Text == "" || txt_tel.Text == "")
            {
                MessageBox.Show("Sélectionner le fabricant");
            }
            else
            {
                try
                {

                    c.cmd.CommandText = "updat Fournisseur set Nom_FO=@nm ,Adress_FO=@add , Tel_FO=@te , JoinDate=@dat where Id_FO=@k ";
                        
                    c.cmd.Connection = c.cn;
                    c.cmd.Parameters.AddWithValue("@nm",txt_nom.Text);
                    c.cmd.Parameters.AddWithValue("@add", txt_adress.Text);
                    c.cmd.Parameters.AddWithValue("@te", txt_tel.Text);
                    c.cmd.Parameters.AddWithValue("@dat", bunifo_date.Text);
                    c.cmd.Parameters.AddWithValue("@k",i);


                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("la modification bien fait");
                    charger();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            c.deconnecter();
        }

        private void lbl_details_Click(object sender, EventArgs e)
        {

        }
    }
}
