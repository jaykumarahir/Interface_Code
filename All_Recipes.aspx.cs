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

public partial class All_Recipes : System.Web.UI.Page
{
    // Connection String
    string orclConnectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

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
            
                BindListNoBoughtRecipes(int.Parse(Session["customer"].ToString()));
           
                if (Session["customer"].ToString() == "-1")
                lblError.Text = "<h3 style = 'text-center' ><strong ><span class='glyphicon glyphicon-warning-sign'></span> "
                + "Please, Login to your account!" + "</strong></h3>";
        }
    }

    private void BindListNoBoughtRecipes(int id)
    {
        // Database Oracle Objects

        OracleConnection orclConn = null;                       // Oracle Connection :: Connection String
        OracleCommand orclComm = null;                          // Oracle Command 
        //OracleParameter orclParam = null;                       // Oracle Parameters
        string sql = null;                                      // Query to be executed

        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                sql = "SELECT * FROM rr_recipe WHERE reci_id NOT IN (" +
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

                ltlCustId.Text = string.Format("<strong>Recipes displayed are not yet bought by customer #{0}</strong>", id);


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
        if (e.CommandName == "BuyRecipe")
        {
            
            bool isSuccess = BuyRecipe(GetUserBasketId(int.Parse(Session["customer"].ToString())), int.Parse(e.CommandArgument.ToString()));
            if ((lblError.Text == "" || lblError.Text == null) || isSuccess)
                Response.Redirect("My_Basket.aspx");
        }
    }

    private bool BuyRecipe(int bskID, int reciID)
    {
        bool isSuccess = false;
        OracleConnection orclConn = null;
        OracleCommand orclComm = null;
        string procName = null;
        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                procName = "rr_ins_basket_item_sp";
                orclComm = new OracleCommand(procName, orclConn);
                orclComm.CommandType = CommandType.StoredProcedure;

                // Passing Parameters
                orclComm.Parameters.Add("bsk_id", OracleDbType.Int32).Value = bskID;
                orclComm.Parameters.Add("reci_id", OracleDbType.Int32).Value = reciID;

                orclComm.Connection.Open();
                orclComm.ExecuteNonQuery();

                isSuccess = true;
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
        return isSuccess;
    }

    private int GetUserBasketId(int custID)
    {
        OracleConnection orclConn = null;
        OracleCommand orclComm = null;
        string procName = null;
        int bskId = -1;
        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                procName = "rr_get_basket_sp";
                orclComm = new OracleCommand(procName, orclConn);
                orclComm.CommandType = CommandType.StoredProcedure;

                // Passing Parameters
                orclComm.Parameters.Add("cust_id", OracleDbType.Int32).Value = custID;

                // Getting Parameters
                orclComm.Parameters.Add("bsk_id", OracleDbType.Int32);
                orclComm.Parameters["bsk_id"].Direction = ParameterDirection.Output;


                orclComm.Connection.Open();
                orclComm.ExecuteNonQuery();

                bskId = int.Parse(orclComm.Parameters["bsk_id"].Value.ToString());
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

        return bskId;
    }
}