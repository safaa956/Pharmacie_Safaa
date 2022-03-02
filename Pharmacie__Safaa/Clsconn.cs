using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Pharmacie__Safaa
{
    class Clsconn
    {
        public SqlConnection cn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();

        public void connecter()
        {
            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            {
                cn.ConnectionString = "Data Source=DESKTOP-SOPOU7N;Initial Catalog=Pharmacie;Integrated Security=True";
                cn.Open();
            }
        }

        public void deconnecter()
        {
            if (cn.State == ConnectionState.Open)
            {

                cn.Close();
            }
        }
    }
}
