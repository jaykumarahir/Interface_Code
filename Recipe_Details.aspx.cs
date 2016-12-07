using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

public partial class Recipe_Details : System.Web.UI.Page
{
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
        //HttpApplication webApp = HttpContext.Current.ApplicationInstance;
        BindList("SELECT * FROM zz_recipe WHERE reci_id = :reci_id", rptSingleRecipe, "reci_id", Session["recipe"].ToString());
        BindList("SELECT * FROM zz_ingredient where reci_id = :reci_id", rptIngredient, "reci_id", Session["recipe"].ToString());
    }

    private void BindList(string lvSQL, Repeater control, string key, string value)
    {
        // Database Oracle Objects
        string orclConnectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection orclConn = null;                       // Oracle Connection :: Connection String
        OracleCommand orclComm = null;                          // Oracle Command 
        OracleParameter orclParam = null;                       // Oracle Parameters
        string sql = null;                                      // Query to be executed

        try
        {
            orclConn = new OracleConnection(orclConnectString);
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

    private void DeleteFromDatabase(string lvSQL, Repeater control, string value)
    {
        // Database Oracle Objects
        string orclConnectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection orclConn = null;                       // Oracle Connection :: Connection String
        OracleCommand orclComm = null;                          // Oracle Command 
        OracleParameter orclParam = null;                       // Oracle Parameters
        string sql = null;                                      // Query to be executed

        try
        {
            orclConn = new OracleConnection(orclConnectString);
            sql = lvSQL;
            orclComm = new OracleCommand(sql, orclConn);

            orclParam = new OracleParameter(value, OracleDbType.Int32);
            orclParam.Value = value;
            orclComm.Parameters.Add(orclParam);

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

    protected void rptSingleRecipe_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            DeleteFromDatabase("DELETE FROM zz_ingredient WHERE reci_id = :reci_id", rptSingleRecipe, e.CommandArgument.ToString());
            DeleteFromDatabase("DELETE FROM zz_recipe WHERE reci_id = :reci_id", rptSingleRecipe, e.CommandArgument.ToString());

            Response.Redirect("All_Recipes.aspx");
        }
    }
}