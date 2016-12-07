using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

public partial class Search_Recipe : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            BindList("SELECT DISTINCT(submitted_by) FROM zz_recipe ORDER BY submitted_by", ddlSubmittedBy, "submitted_by", "ALL SUBMITTED BY");
            BindList("SELECT DISTINCT(category) FROM zz_recipe WHERE category IS NOT NULL ORDER BY category", ddlCategory, "category", "ALL CATEGORY");
            BindList("SELECT DISTINCT(name) FROM zz_ingredient ORDER BY name", ddlIngredient, "name", "ALL INGREDIENT NAME");
        }

    }

    private void BindList(string lvSQL, DropDownList control, string value, string name)
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
                control.DataSource = reader;
                control.DataTextField = value;
                control.DataValueField = value;
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

        control.Items.Insert(0, new ListItem(name, "%"));

    }

    private void BindList(Repeater rep)
    {
        // Database Oracle Objects
        string orclConnectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection orclConn = null;                       // Oracle Connection :: Connection String
        OracleCommand orclComm = null;                          // Oracle Command 
        OracleParameter orclParam = null;                       // Oracle Parameters
        string sql = null;                                      // Query to be executed

        //try
        //{
            orclConn = new OracleConnection(orclConnectString);
            sql = "SELECT DISTINCT(zz_recipe.name), submitted_by, category, cook_time, num_serving, descr " +
                "FROM zz_recipe LEFT JOIN zz_ingredient ON zz_recipe.reci_id = zz_ingredient.reci_id " +
                "WHERE (submitted_by LIKE :submitted_by) " + 
                "AND (category LIKE :category) " +
                "AND (zz_ingredient.name LIKE :name)  ";

            orclComm = new OracleCommand(sql, orclConn);

            // PARAMETERs

            orclParam = new OracleParameter("submitted_by", OracleDbType.Varchar2, 20);
            orclParam.Value = ddlSubmittedBy.SelectedValue;
            orclComm.Parameters.Add(orclParam);

            orclParam = new OracleParameter("category", OracleDbType.Varchar2, 20);
            orclParam.Value = ddlCategory.SelectedValue;
            orclComm.Parameters.Add(orclParam);

            orclParam = new OracleParameter("name", OracleDbType.Varchar2, 20);
            orclParam.Value = ddlIngredient.SelectedValue;
            orclComm.Parameters.Add(orclParam);

            /*Opening Database*/
            //conn.Open();
            orclComm.Connection.Open();

            OracleDataReader reader = orclComm.ExecuteReader();


            if (reader.HasRows)
            {
                lblResult.Text = "";
                rep.DataSource = reader;
                rep.DataBind();
           }
            else
            {
                lblResult.Text = "<h3 style='text-center'><strong><span class='glyphicon glyphicon-warning-sign'></span>" +
                    "  No Recipe satisfies the respective query!</strong></h3>";
                rep.DataSource = reader;
                rep.DataBind();
            }

        try { }
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList(rptRecipes);
    }
}