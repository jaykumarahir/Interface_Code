using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;

public partial class Sign_Up : System.Web.UI.Page
{
    private string orclConnectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        string theme = (string)Session["theme"];
        if (theme != null)
            Page.Theme = theme;
        else
            Page.Theme = "Light";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindListCustomer();
        }
    }

    private void BindListCustomer()
    {
        // Database Oracle Objects
        OracleConnection orclConn = null;                       // Oracle Connection :: Connection String
        OracleDataAdapter orclAdapter = null;
        OracleCommand orclComm = null;                          // Oracle Command 
        //OracleParameter orclParam = null;                       // Oracle Parameters
        DataTable dataTab = null;


        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                dataTab = new DataTable();
                orclAdapter = new OracleDataAdapter("SELECT fname, lname, email FROM rr_customer ORDER BY fname", orclConn);
                orclAdapter.Fill(dataTab);

                dataTab.Columns.Add("FullName", typeof(string), "fname + ' ' + lname");

                

                if (dataTab.Rows.Count > 0)
                {
                    ddlAccount.DataSource = dataTab;
                    ddlAccount.DataTextField = "FullName";
                    ddlAccount.DataValueField = "email";
                    ddlAccount.DataBind();
                }
               

            }
            catch (OracleException ex)
            {
                //myLabel.Text = ex.Message;
            }

            ddlAccount.Items.Insert(0, new ListItem("--SELECT USER--", "NOBODY"));
        }

    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        OracleConnection orclConn = null;
        OracleCommand orclComm = null;
        string procName = null;
        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                procName = "rr_authenticate_sp";
                orclComm = new OracleCommand(procName, orclConn);
                orclComm.CommandType = CommandType.StoredProcedure;

                // Passing Parameters
                orclComm.Parameters.Add("email", OracleDbType.Varchar2, 40).Value = ddlAccount.SelectedValue;
                orclComm.Parameters.Add("password", OracleDbType.Varchar2, 32).Value = sbAccountPassword.Text;

                // Out Parameters
                orclComm.Parameters.Add("cust_id", OracleDbType.Int32).Direction = ParameterDirection.Output;

                orclComm.Connection.Open();
                orclComm.ExecuteNonQuery();

                Session["customer"] = orclComm.Parameters["cust_id"].Value.ToString();

                Response.Redirect("My_Basket.aspx");
            }
            catch (OracleException orclEx)
            {
                string errorMessage = "";
                for (int i = 0; i < orclEx.Errors.Count; i++)
                {
                    errorMessage += "Index #" + i + " " +
                        "Message: " + orclEx.Errors[i].Message + ""; //+
                                                                     //"LineNumber: " + orclEx.Errors[i].LineNumber + "\n" +
                                                                     //"Source: " + orclEx.Errors[i].Source + "\n" +
                                                                     //"Procedure: " + orclEx.Errors[i].Procedure + "\n";
                }

                lblError.Text = "<h5 style = 'text-center' ><strong ><span class='glyphicon glyphicon-warning-sign'></span> "
                + errorMessage + "</strong></h5>";
            }

            finally
            {
                orclComm.Connection.Close();
            }
        }

    }

    protected void btnSaveAccount_Click(object sender, EventArgs e)
    {
        OracleConnection orclConn = null;
        OracleCommand orclComm = null;
        OracleParameter orclParam = null;
        string procName = null;

        using(orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                procName = "rr_ins_customer_sp";
                orclComm = new OracleCommand(procName, orclConn);
                orclComm.CommandType = CommandType.StoredProcedure;

                // Passing Parameters
                orclComm.Parameters.Add("fname", OracleDbType.Varchar2, 15).Value = sbAccount.Text;
                orclComm.Parameters.Add("lname", OracleDbType.Varchar2, 15).Value = sbAccount1.Text;
                orclComm.Parameters.Add("email", OracleDbType.Varchar2, 40).Value = sbAccountEmail.Text;
                orclComm.Parameters.Add("password", OracleDbType.Varchar2, 32).Value = sbAccountPassword1.Text;
                orclComm.Parameters.Add("phone", OracleDbType.Char, 10).Value = txtPhone.Text;

                orclComm.Connection.Open();
                orclComm.ExecuteNonQuery();

                Response.Redirect("Sign_Up.aspx");

            } catch (OracleException orclEx)
            {
                string errorMessage = "";
                for (int i = 0; i < orclEx.Errors.Count; i++)
                {
                    errorMessage += "Index #" + i + " " +
                        "Message: " + orclEx.Errors[i].Message + ""; //+
                                                                     //"LineNumber: " + orclEx.Errors[i].LineNumber + "\n" +
                                                                     //"Source: " + orclEx.Errors[i].Source + "\n" +
                                                                     //"Procedure: " + orclEx.Errors[i].Procedure + "\n";
                }

                lblError1.Text = "<h5 style = 'text-center' ><strong ><span class='glyphicon glyphicon-warning-sign'></span> "
                + errorMessage + "</strong></h5>";
            }
            finally
            {
                orclComm.Connection.Close();
            }
        }
    }
}