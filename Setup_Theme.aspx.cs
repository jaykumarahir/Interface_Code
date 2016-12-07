using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setup_Theme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        string theme = (string)Session["theme"];
        if (theme != null)
            Page.Theme = theme;
        else
            Page.Theme = "Light";
    }

    protected void btnLight_Click(object sender, EventArgs e)
    {
        Session["theme"] = "Light";
        Response.Redirect("Default.aspx");
    }

    protected void btnDark_Click(object sender, EventArgs e)
    {
        Session["theme"] = "Dark";
        Response.Redirect("Default.aspx");
    }
}