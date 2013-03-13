using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class AddTalent : System.Web.UI.Page
    {
        // private DbSet<TalentSpell> mTalentSpells;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGrid();
                // Test entity framework!!! gsdfgdfsgfds
                //var coo = context.AttributeTypes.Select(f => f.Name).ToList();

                    

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

        private void FillGrid()
        {
            using (var context = new BlackCrusadeEntities())
            {
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
                                  AttributeName = A.Name,
                                  AttributeId = A.Id
                              })
                                     .ToList();

                if (joined.Count > 0)
                {
                    NewGridView.DataSource = joined;
                    NewGridView.DataBind();
                }
                else
                {
                    //TODO: handle case where there are no records
                    //dtCustomer.Rows.Add(dtCustomer.NewRow());
                    //GridView1.DataSource = dtCustomer;
                    //GridView1.DataBind();

                    //int TotalColumns = GridView1.Rows[0].Cells.Count;
                    //GridView1.Rows[0].Cells.Clear();
                    //GridView1.Rows[0].Cells.Add(new TableCell());
                    //GridView1.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    //GridView1.Rows[0].Cells[0].Text = "No Record Found"; 
                    throw new Exception("I didn't handle the zero record case");
                }
            }
        }

        protected void NewGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtTalentName = (TextBox)NewGridView.FooterRow.FindControl("txtNewTalentName");
                TextBox txtTalentDescription = (TextBox)NewGridView.FooterRow.FindControl("txtNewDescription");
                TextBox txtTier = (TextBox)NewGridView.FooterRow.FindControl("txtNewTier");
                TextBox txtCost = (TextBox)NewGridView.FooterRow.FindControl("txtNewCost");
                DropDownList ddlGodName = (DropDownList)NewGridView.FooterRow.FindControl("ddlNewGodName");
                DropDownList ddlAttributeName = (DropDownList)NewGridView.FooterRow.FindControl("ddlNewAttributeName");
                CheckBox chkWasRevised = (CheckBox)NewGridView.FooterRow.FindControl("chkNewWasRevised");

                using (var context = new BlackCrusadeEntities())
                {
                    context.TalentSpells.Add(new TalentSpell()
                    {
                        Revised = false,
                        WhichGod = Convert.ToInt32(ddlGodName.SelectedItem.Value),
                        Name = txtTalentName.Text,
                        Description = txtTalentDescription.Text,
                        Tier = Convert.ToInt32(txtTier.Text),
                        Cost = Convert.ToInt32(txtCost.Text),
                        AttributeType = Convert.ToInt32(ddlAttributeName.SelectedItem.Value)
                    });

                    context.SaveChanges();

                    FillGrid();
                }
            }
        }

        protected void NewGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            NewGridView.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void NewGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            NewGridView.EditIndex = -1;
            FillGrid();
        }

        protected void NewGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtTalentName = (TextBox)NewGridView.Rows[e.RowIndex].FindControl("txtTalentName");
            TextBox txtTalentDescription = (TextBox)NewGridView.Rows[e.RowIndex].FindControl("txtDescription");
            TextBox txtTier = (TextBox)NewGridView.Rows[e.RowIndex].FindControl("txtTier");
            TextBox txtCost = (TextBox)NewGridView.Rows[e.RowIndex].FindControl("txtCost");
            DropDownList ddlGodName = (DropDownList)NewGridView.Rows[e.RowIndex].FindControl("ddlGodName");
            DropDownList ddlAttributeName = (DropDownList)NewGridView.Rows[e.RowIndex].FindControl("ddlAttributeName");

            using (var context = new BlackCrusadeEntities())
            {
                var id = Convert.ToInt32(NewGridView.DataKeys[e.RowIndex].Values[0].ToString());
                var talentSpell = context.TalentSpells.FirstOrDefault(t => t.Id == (id));

                talentSpell.Name = txtTalentName.Text;
                talentSpell.Description = txtTalentDescription.Text;
                talentSpell.Tier = Convert.ToInt32(txtTier.Text);
                talentSpell.Cost = Convert.ToInt32(txtCost.Text);
                talentSpell.WhichGod = Convert.ToInt32(ddlGodName.SelectedItem.Value);
                talentSpell.AttributeType = Convert.ToInt32(ddlAttributeName.SelectedItem.Value);
                talentSpell.Revised = true;

                context.SaveChanges();

                NewGridView.EditIndex = -1;
                FillGrid();
            }
        }

        protected void NewGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var context = new BlackCrusadeEntities())
            {
                var index = NewGridView.DataKeys[e.RowIndex].Values[0].ToString();

                //context.TalentSpells.
            }
        }

        protected void NewGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            using (var context = new BlackCrusadeEntities())
            {
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
                                  AttributeName = A.Name,
                                  AttributeId = A.Id
                              });

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlGodName = e.Row.FindControl("ddlGodName") as DropDownList;

                    if (ddlGodName != null)
                    {
                        int id = Convert.ToInt32(NewGridView.DataKeys[e.Row.RowIndex].Values[0].ToString());
                        var talentSpell = joined.FirstOrDefault(j => j.Id == id);
                        ddlGodName.DataValueField = "Id";
                        ddlGodName.DataTextField = "Name";
                        ddlGodName.DataSource = context.BlackCrusadeGods.ToList();
                        ddlGodName.DataBind();
                        ddlGodName.SelectedValue = talentSpell.GodId.ToString();
                    }

                    DropDownList ddlAttributeName = e.Row.FindControl("ddlAttributeName") as DropDownList;

                    if (ddlAttributeName != null)
                    {
                        int id = Convert.ToInt32(NewGridView.DataKeys[e.Row.RowIndex].Values[0].ToString());
                        var talentSpell = joined.FirstOrDefault(j => j.Id == id);
                        ddlAttributeName.DataValueField = "Id";
                        ddlAttributeName.DataTextField = "Name";
                        ddlAttributeName.DataSource = context.AttributeTypes.ToList();
                        ddlAttributeName.DataBind();
                        ddlAttributeName.SelectedValue = talentSpell.AttributeId.ToString();
                    }
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList ddlNewGodName = e.Row.FindControl("ddlNewGodName") as DropDownList;
                    ddlNewGodName.DataValueField = "Id";
                    ddlNewGodName.DataTextField = "Name";
                    ddlNewGodName.DataSource = context.BlackCrusadeGods.ToList(); ;
                    ddlNewGodName.DataBind();

                    DropDownList ddlNewAttributeName = e.Row.FindControl("ddlNewAttributeName") as DropDownList;
                    ddlNewAttributeName.DataValueField = "Id";
                    ddlNewAttributeName.DataTextField = "Name";
                    ddlNewAttributeName.DataSource = context.AttributeTypes.ToList();
                    ddlNewAttributeName.DataBind();
                }
            }
        }
    }
}