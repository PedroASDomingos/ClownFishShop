using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline
{
    public partial class team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTeam();
        }

        private void LoadTeam()
        {
            try
            {
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                myConn.Open();

                SqlCommand myCommand = myConn.CreateCommand();
                myCommand.CommandType = CommandType.Text;
                myCommand.CommandText = "select * from funcionario";

                myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(myCommand);

                da.Fill(dt);
                d1.DataSource = dt;
                d1.DataBind();

                myConn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GetImage(object ctype, object img)
        {
            return "data:"+ ctype + ";base64," + Convert.ToBase64String((byte[])img);
        }
    }
}