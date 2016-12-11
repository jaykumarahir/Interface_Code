using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

public partial class My_Basket : System.Web.UI.Page
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
            
                BindListBoughtRecipes(int.Parse(Session["customer"].ToString()));
                BindDataCustomer(int.Parse(Session["customer"].ToString()));

                if (Session["customer"].ToString() == "-1")
                    lblLoginMessage.Text = "<h3 style = 'text-center' ><strong ><span class='glyphicon glyphicon-warning-sign'></span> "
                        + "Please, Login to your account!" + "</strong></h3>";
        }
    }

    private void BindListBoughtRecipes(int id)
    {
        // Database Oracle Objects
        
        OracleConnection orclConn = null;                       // Oracle Connection :: Connection String
        OracleCommand orclComm = null;                          // Oracle Command 
        OracleParameter orclParam = null;                       // Oracle Parameters
        string sql = null;                                      // Query to be executed
        
        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                sql = "SELECT * FROM rr_recipe WHERE reci_id IN (" +
                "SELECT reci_id FROM rr_basket_item WHERE bsk_id = (" +
                "SELECT bsk_id FROM rr_basket WHERE cust_id = :cust_id))";

                orclComm = new OracleCommand(sql, orclConn);
                
                // Shortcut
                orclComm.Parameters.Add("cust_id", OracleDbType.Int32).Value = id;


                /*Opening Database*/
                //conn.Open();
                orclComm.Connection.Open();

                OracleDataReader reader = orclComm.ExecuteReader();
                rptRecipes.DataSource = reader;
                rptRecipes.DataBind();

            }
            catch (OracleException ex)
            {
                //myLabel.Text = ex.Message;
            }
            finally
            {
                /*Closing Database*/
                //conn.Close();
                orclComm.Connection.Close();
            }
        }
    }

    private void BindDataCustomer(int id)
    {
        // Database Oracle Objects

        OracleConnection orclConn = null;                       // Oracle Connection :: Connection String
        OracleCommand orclComm = null;                          // Oracle Command 
        OracleParameter orclParam = null;                       // Oracle Parameters
        string sql = null;                                      // Query to be executed

        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                sql = "SELECT * FROM rr_customer JOIN rr_basket USING (cust_id) WHERE cust_id = :cust_id";
                orclComm = new OracleCommand(sql, orclConn);

                orclParam = new OracleParameter("cust_id", OracleDbType.Int32);
                orclParam.Value = id;
                orclComm.Parameters.Add(orclParam);

                /*Opening Database*/
                //conn.Open();
                orclComm.Connection.Open();

                OracleDataReader reader = orclComm.ExecuteReader();
                while (reader.Read())
                {
                    lblName.Text = string.Format("{0} {1}", reader["fname"], reader["lname"]);
                    lblCustFullName.Text = string.Format("{0} {1}", reader["fname"], reader["lname"]);
                    lblCustId.Text = reader["cust_id"].ToString();
                    lblEmail.Text = reader["email"].ToString();
                    lblPhone.Text = reader["phone"].ToString() == "" ? "Not Given" : reader["phone"].ToString();
                    lblBasket.Text = reader["bsk_id"].ToString();
                    lblBalance.Text = string.Format("{0:c}", Double.Parse(reader["balance"].ToString()));
                    txtCurrBalance.Text = string.Format("{0:c}", Double.Parse(reader["balance"].ToString()));
                }

            }
            catch (OracleException ex)
            {
                //myLabel.Text = ex.Message;
            }
            finally
            {
                /*Closing Database*/
                //conn.Close();
                orclComm.Connection.Close();
            }
        }
    }


    protected void rptRecipes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "MoreInformation")
        {
            //HttpApplication webApp = HttpContext.Current.ApplicationInstance;
            Session["recipe"] = e.CommandArgument.ToString();
            Response.Redirect("Recipe_Details.aspx");
        }
    }

    protected void btnAddBalance_Click(object sender, EventArgs e)
    {
        OracleConnection orclConn = null;
        OracleCommand orclComm = null;
        OracleCommand orclParameter = null;
        string procName = null;
        
        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                procName = "rr_add_balance_sp";

                orclComm = new OracleCommand(procName, orclConn);
                orclComm.CommandType = CommandType.StoredProcedure;

                // Passing Parameters
                orclComm.Parameters.Add("cust_id", OracleDbType.Int32).Value = int.Parse(Session["customer"].ToString());
                orclComm.Parameters.Add("amt", OracleDbType.Int32).Value = int.Parse(txtNewAmount.Text);

                orclComm.Connection.Open();
                orclComm.ExecuteNonQuery();

                Response.Redirect("My_Basket.aspx");
            }
            catch (OracleException orclEx)
            {
                // Nothing...
            }
            finally
            {
                orclComm.Connection.Close();
            }

        }
    }

}