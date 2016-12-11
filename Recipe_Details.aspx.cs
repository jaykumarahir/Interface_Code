using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

public partial class Recipe_Details : System.Web.UI.Page
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
            BindList("SELECT * FROM rr_recipe WHERE reci_id = :reci_id", rptSingleRecipe, "reci_id", Session["recipe"].ToString());
            BindList("SELECT * FROM rr_ingredient where reci_id = :reci_id", rptIngredient, "reci_id", Session["recipe"].ToString());
            GetRecipeName(Session["recipe"].ToString());
            GetRecipeRating(Session["customer"].ToString(), Session["recipe"].ToString());
        }
    }

    private void BindList(string lvSQL, Repeater control, string key, string value)
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

                sql = lvSQL;
                orclComm = new OracleCommand(sql, orclConn);

                orclParam = new OracleParameter(value, OracleDbType.Int32);
                orclParam.Value = value;
                orclComm.Parameters.Add(orclParam);

                /*Opening Database*/
                //conn.Open();
                orclComm.Connection.Open();

                OracleDataReader reader = orclComm.ExecuteReader();
                control.DataSource = reader;
                control.DataBind();

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

    private void DeleteFromBasket(int custID, int reciID)
    {
        // Database Oracle Objects
        
        OracleConnection orclConn = null;                       // Oracle Connection :: Connection String
        OracleCommand orclComm = null;                          // Oracle Command 
        OracleParameter orclParam = null;                       // Oracle Parameters
        string procName = null;                                 // Procedure Name

        using (orclConn = new OracleConnection(orclConnectString))
        {

            try
            {
                procName = "rr_del_basket_item_sp";
                orclComm = new OracleCommand(procName, orclConn);
                orclComm.CommandType = CommandType.StoredProcedure;

                // Passing Parameters
                orclComm.Parameters.Add("cust_id", OracleDbType.Int32).Value = custID;
                orclComm.Parameters.Add("reci_id", OracleDbType.Int32).Value = reciID;

                /*Opening Database*/
                //conn.Open();
                orclComm.Connection.Open();

                // INSERTING DATA INTO TABLE COMMAND
                orclComm.ExecuteNonQuery();

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

    private void GetRecipeName(string reciID)
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

                orclComm = new OracleCommand("SELECT rr_sel_reci_name_sf(:reci_id) FROM DUAL", orclConn);

                orclParam = new OracleParameter("reci_id", OracleDbType.Int32);
                orclParam.Value = reciID;
                orclComm.Parameters.Add(orclParam);


                //conn.Open();
                orclComm.Connection.Open();

                lblRecipeName.Text = orclComm.ExecuteScalar().ToString();
                

            }
            catch (OracleException ex)
            {
                //myLabel.Text = ex.Message;
            }
            finally
            {

                //conn.Close();
                orclComm.Connection.Close();
            }
        }

    }

    private void GetRecipeRating(string custID, string reciID)
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

                orclComm = new OracleCommand("SELECT rr_sel_reci_rating_sf(:cust_id, :reci_id) FROM DUAL", orclConn);

                // Passing Parameters
                orclComm.Parameters.Add("cust_id", OracleDbType.Int32).Value = custID;
                orclComm.Parameters.Add("reci_id", OracleDbType.Int32).Value = reciID;


                //conn.Open();
                orclComm.Connection.Open();

                string result = orclComm.ExecuteScalar().ToString();
                lblRating.Text = string.Format("<h4>Your Rating: {0:f1}</h4>", Double.Parse(result));
                txtCurrRating.Text = result;



            }
            catch (OracleException ex)
            {
                //myLabel.Text = ex.Message;
            }
            finally
            {

                //conn.Close();
                orclComm.Connection.Close();
            }
        }

    }

    protected void rptSingleRecipe_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            DeleteFromBasket(int.Parse(Session["customer"].ToString()), int.Parse(Session["recipe"].ToString()));   
            Response.Redirect("My_Basket.aspx");
        }
    }

    protected void btnAddRating_Click(object sender, EventArgs e)
    {
        OracleConnection orclConn = null;
        OracleCommand orclComm = null;
        OracleCommand orclParameter = null;
        string procName = null;

        using (orclConn = new OracleConnection(orclConnectString))
        {
            try
            {
                procName = "rr_add_rating_sp";

                orclComm = new OracleCommand(procName, orclConn);
                orclComm.CommandType = CommandType.StoredProcedure;

                // Passing Parameters
                orclComm.Parameters.Add("cust_id", OracleDbType.Int32).Value = int.Parse(Session["customer"].ToString());
                orclComm.Parameters.Add("reci_id", OracleDbType.Int32).Value = int.Parse(Session["recipe"].ToString());
                orclComm.Parameters.Add("rating", OracleDbType.Int32).Value = int.Parse(txtNewRating.Text);

                orclComm.Connection.Open();
                orclComm.ExecuteNonQuery();

                Response.Redirect("Recipe_Details.aspx");
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