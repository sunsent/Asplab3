using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//let commit it
namespace ASPlab2
{
    public partial class myhome : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UsrId"] != null)
            //{
            //    Response.Redirect("myhome.aspx");
            //}
            //页面第一次加载的动作
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //输入的用户名
                string usrName = txtUsrname.Text.Trim();
                //输入的密码
                string pwd = txtPwd.Text.Trim();
                string cmdText = "select PASSWORD,USERID from STUDENT where USERNAME='" + usrName+"'";
                SqlCommand command = new SqlCommand(cmdText, connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    string usrId = sqlDataReader["USERID"].ToString();
                    if (pwd == sqlDataReader["PASSWORD"].ToString())
                    {
                        Session["UsrId"] = sqlDataReader["USERID"];
                        Session["UsrName"]=usrName;
                        Session["Pwd"] = sqlDataReader["PASSWORD"];
                        Response.Redirect("myhome.aspx");
                    }
                    else
                    {
                        label_tip.Text = "密码错误!";
                    }
                }
                else
                {
                    label_tip.Text = "用户名不存在!";
                }
            }
            catch(SqlException sqlex)
            {
                Response.Write(sqlex.Message + "<br>");
            }
            //label_tip.Text = "请输入用户名和密码";
            //if (Session["UsrId"] != null&& Session["Pwd"] != null)
            //{
            //    var usrName = Server.HtmlEncode(txtUsrname.Text.Trim());
            //    var pwd = Server.HtmlEncode(txtPwd.Text.Trim());
            //    if (Session["UsrId"].Equals(usrName))
            //    {
            //        if (Session["Pwd"].Equals(pwd))
            //        {
            //            Response.Redirect("myhome.aspx");
            //            Session["IsLogin"] = 1;
            //        }
            //    }
            //    label_tip.Text = "用户名或密码错误";
            //}
            //else 
            //{
            //    Session["UsrId"] =Server.HtmlEncode(txtUsrname.Text.Trim());
            //    Session["Pwd"]= Server.HtmlEncode(txtPwd.Text.Trim());
            //    Session["IsLogin"] = 1;
            //    Response.Redirect("myhome.aspx");
            //}
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            label_tip.Text = "请输入用户名和密码";
            txtUsrname.Text = "";
            txtPwd.Text = "";
        }
    }
}