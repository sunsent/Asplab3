using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPlab2
{
    public partial class login : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Pwd"] ==null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                label_usrInfo.Text = "当前用户：" + Session["UsrName"].ToString() + "/" + Session["Pwd"].ToString();
            }
            
            label_time.Text = DateTime.Now.ToString();
            if (!Page.IsPostBack)
            {
                ListBox_MyClass.Items.Add(new ListItem("所修课程"));
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["IsLogin"] = 0;
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void BtnSearchMyClass_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string usrId = Session["UsrId"].ToString();
                string cmdText = "select CLASSID from STUDENT_CLASS where USERID='" + usrId + "'";
                SqlCommand command = new SqlCommand(cmdText, connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ListBox_MyClass.Items.Add(new ListItem(sqlDataReader["CLASSID"].ToString()));
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write(sqlex.Message + "<br>");
            }

        }
    }
}