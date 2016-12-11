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

public partial class Search_Recipe : System.Web.UI.Page
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
            BindList("SELECT DISTINCT(price) FROM rr_recipe ORDER BY price", ddlPriceRange, "price", "ALL PRICES");
            BindList("SELECT DISTINCT(category) FROM rr_recipe WHERE category IS NOT NULL ORDER BY category", ddlCategory, "category", "ALL CATEGORY");
            BindList("SELECT DISTINCT(name) FROM rr_ingredient ORDER BY name", ddlIngredient, "name", "ALL INGREDIENT NAME");

            if (Session["customer"].ToString() == "-1")
                lblLoginMessage.Text = "<h3 style = 'text-center' ><strong ><span class='glyphicon glyphicon-warning-sign'></span> "
                    + "Please, Login to your account!" + "</strong></h3>";
        }

    }

    private void BindList(string lvSQL, DropDownList control, string value, string name)
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

            if (name == "ALL PRICES")
                control.Items.Insert(0, new ListItem(name, "1000"));
            else
                control.Items.Insert(0, new ListItem(name, "%"));
        }

    }

    private void BindList(Repeater rep)
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
                string sql_price = ddlPriceRange.SelectedValue != "1000" ? "WHERE (price = :price)" : "WHERE (price between 0 and :price) "; 

                sql = "SELECT DISTINCT(reci_id), rr_recipe.name, category, cook_time, descr, price " +
                    "FROM rr_recipe LEFT JOIN rr_ingredient USING(reci_id) " +
                    sql_price +
                    "AND (category LIKE :category) " +
                    "AND (rr_ingredient.name LIKE :name)  ";

                orclComm = new OracleCommand(sql, orclConn);

                // PARAMETERs

                orclParam = new OracleParameter("price", OracleDbType.Double);
                orclParam.Value = ddlPriceRange.SelectedValue;
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
                    lblError.Text = "";
                    rep.DataSource = reader;
                    rep.DataBind();
                }
                else
                {
                    lblError.Text = "<h3 style='text-center'><strong><span class='glyphicon glyphicon-warning-sign'></span>" +
                        "  No Recipe satisfies the respective query!</strong></h3>";
                    rep.DataSource = reader;
                    rep.DataBind();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList(rptRecipes);
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

                lblError.Text = "<h5 style = 'text-center' >< strong >< span class='glyphicon glyphicon-warning-sign'></span> "
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