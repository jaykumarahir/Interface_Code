using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;

public partial class All_Recipes : System.Web.UI.Page
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
        BindList("SELECT * FROM rr_recipe ORDER BY reci_id", rptRecipes);
        
    }

    private void BindList(string lvSQL, Repeater rep)
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



            /*Opening Database*/
            //conn.Open();
            orclComm.Connection.Open();

            OracleDataReader reader = orclComm.ExecuteReader();
            rep.DataSource = reader;
            rep.DataBind();

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

    protected void rptRecipes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "BuyRecipe")
        {
            //HttpApplication webApp = HttpContext.Current.ApplicationInstance;
            Session["recipe"] = e.CommandArgument.ToString();
            Response.Redirect("Recipe_Details.aspx");
        }
    }

}