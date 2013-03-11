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
            if (!Page.IsPostBack)
            {
                using (var context = new BlackCrusadeEntities())
                {
                    // Test entity framework!!! gsdfgdfsgfds
                    //var coo = context.AttributeTypes.Select(f => f.Name).ToList();

                    var joined = (from T in context.TalentSpells
                                  from G in context.BlackCrusadeGods
                                  from A in context.AttributeTypes
                                  where T.WhichGod == G.Id
                                  where T.AttributeType == A.Id
                                  select new
                                  {
                                      GodId = T.WhichGod,
                                      Id = T.Id,
                                      TalentName = T.Name,
                                      TalentDescription = T.Description,
                                      WasRevised = T.Revised,
                                      Tier = T.Tier,
                                      Cost = T.Cost,
                                      GodName = G.Name,
                                      AttributeName = A.Name
                                  })
                                 .ToList();

                    GridView1.DataSource = joined;
                    GridView1.DataBind();

                    //            var Query =
                    //Context.Users
                    //.Join(Context.UserStats,            // Table to Join
                    //    u => u.msExchMailboxGuid,       // Column to Join From
                    //    us => us.MailboxGuid,           // Column to Join To
                    //    (u, us) => new                  // Alias names from Tables
                    //    {
                    //        u,
                    //        us
                    //    })
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        public void Insert()
        {
        }

        public void Fetch()
        { }

        public void Update()
        {
        }

        public void Delete()
        {
        }
    }
}