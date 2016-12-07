using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sbAccountEmail : System.Web.UI.UserControl
{
    public string LabelText
    {
        set { lblAccount.Text = value; }
    }

    public string Text
    {
        get { return txtAccount.Text; }
        set { txtAccount.Text = value; }
    }

    public string PlaceHolderText
    {
        set { txtAccount.Attributes.Add("placeholder", value); }
    }

    public string ValidatorMessage
    {
        set { valAccount.ErrorMessage = value; }
    }

    public string ValidationGroupText
    {
        set { valAccount.ValidationGroup = value; valEmail2.ValidationGroup = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}