using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class AddTalent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var foo = new BlackCrusadeEntities())
            {
                var coo = foo.AttributeTypes.Select(f => f.Name).ToList();
            }
        }
    }
}