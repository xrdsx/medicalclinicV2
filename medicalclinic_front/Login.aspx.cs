using medicalclinic_back;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web;

namespace medicalclinic
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            LabelSec.Visible = false;
            IncorrectDataLabel.Visible = false;

            if (Session["timer"] != null)
            {
                if ((DateTime)Session["timer"] > DateTime.Now)
                {

                    Button1.Enabled = false;
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    LabelSec.Visible = true;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {


                if (TextBox1.Text == "" || TextBox2.Text == "")
                {
                    IncorrectDataLabel.Visible = true;
                    IncorrectDataLabel.Text = "Enter your login and password!";

                }
                if (LoginUser.checkAttempt() & Session["timer"] == null)
                {


                    Session["timer"] = DateTime.Now.AddMinutes(LoginUser.setTime());
                    Button1.Enabled = false;
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;




                }
                else
                {
                    LoginUser.logIn(TextBox1.Text, TextBox2.Text);

                    if (LoginUser.checkIfLogged())
                    {
                        if (!LoginUser.checkIsActive())
                        {
                            IncorrectDataLabel.Visible = true;
                            IncorrectDataLabel.Text = "Your account had been deactivated.";
                            return;
                        }
                        Session["id"] = LoginUser.getUserId();
                        Session["role"] = LoginUser.getRoleName(LoginUser.getUserId());
                        Response.Redirect("Default.aspx");

                    }
                    IncorrectDataLabel.Visible = true;
                    if (LoginUser.checkAttempt())
                    {
                        IncorrectDataLabel.Text = LoginUser.showInfo();
                        TextBox1.Enabled = false;
                        TextBox2.Enabled = false;
                        Button1.Enabled = false;

                    }

                    else
                    {
                        IncorrectDataLabel.Text = LoginUser.wrongData();
                    }

                }
            }
            catch
            {
                IncorrectDataLabel.Text = "Error";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (Session["timer"] != null)
            {

                if ((DateTime)Session["timer"] > DateTime.Now)
                {
                    LabelSec.Visible = true;
                    LabelSec.Text = "Time left: " + (((Int32)DateTime.Parse(Session["timer"].ToString()).Subtract(DateTime.Now).TotalMinutes) + " minutes ") + (((Int32)DateTime.Parse(Session["timer"].ToString()).Subtract(DateTime.Now).TotalSeconds) % 60 + " seconds");
                    Button1.Enabled = false;
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;

                }
                else
                {
                    Session["timer"] = null;
                    Button1.Enabled = true;
                    TextBox1.Enabled = true;
                    TextBox2.Enabled = true;
                    LoginUser.NumOfAttempt = 3;
                    Response.Redirect("Login.aspx");
                }

            }
        }
    }
}