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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillTalentSpellsGrid();
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

        private void FillTalentSpellsGrid()
        {
            using (var context = new BlackCrusadeEntities())
            {
                var joined = (from T in context.TalentSpells
                              from G in context.BlackCrusadeGods
                              from A in context.AttributeTypes
                              from B in context.Booksources
                              where T.WhichGod == G.Id
                              where T.AttributeType == A.Id
                              where T.Booksource == B.Id
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
                                  AttributeId = A.Id,
                                  BooksourceId = T.Booksource,
                                  BooksourceName = B.Name
                              })
                                     .ToList();

                if (joined.Count > 0)
                {
                    gvTalentSpells.DataSource = joined;
                    gvTalentSpells.DataBind();
                }
                else
                {
                    var emptyObject = new
                    {
                        Id = 0,
                        GodId = 0,
                        TalentName = "0",
                        TalentDescription = "0",
                        WasRevised = false,
                        Tier = 0,
                        Cost = 0,
                        GodName = "0",
                        AttributeName = "0",
                        AttributeId = 0,
                        BooksourceId = 0,
                        BooksourceName = "0"
                    };

                    gvTalentSpells.DataSource = new[] { emptyObject };
                    gvTalentSpells.DataBind();

                    int totalColumns = gvTalentSpells.Rows[0].Cells.Count;
                    gvTalentSpells.Rows[0].Cells.Clear();
                    gvTalentSpells.Rows[0].Cells.Add(new TableCell());
                    gvTalentSpells.Rows[0].Cells[0].ColumnSpan = totalColumns;
                    gvTalentSpells.Rows[0].Cells[0].Text = "No Record Found"; 
                }
            }
        }

        private void FillPrerequisiteGrid(int TalentSpellsId)
        {
            using (var context = new BlackCrusadeEntities())
            {
                var prerequisites = (from T in context.Prerequisites
                                     from A in context.AttributeTypes
                                     where T.AttributeType == A.Id && T.TalentSpellId == TalentSpellsId
                              select new
                              {
                                  TalentSpellId = T.TalentSpellId,
                                  Id = T.Id,
                                  AttributeName = A.Name,
                                  AttributeId = A.Id,
                                  Cost = T.Cost
                              })
                                     .ToList();

                if (prerequisites.Count > 0)
                {
                    gvPrerequisites.DataSource = prerequisites;
                    gvPrerequisites.DataBind();
                }
                else
                {
                    var emptyObject = new
                    {
                        TalentSpellId = 0,
                        Id = 0,
                        AttributeName = "0",
                        AttributeId = 0,
                        Cost = 0
                    };

                    gvPrerequisites.DataSource = new[] { emptyObject };
                    gvPrerequisites.DataBind();

                    int totalColumns = gvPrerequisites.Rows[0].Cells.Count;
                    gvPrerequisites.Rows[0].Cells.Clear();
                    gvPrerequisites.Rows[0].Cells.Add(new TableCell());
                    gvPrerequisites.Rows[0].Cells[0].ColumnSpan = totalColumns;
                    gvPrerequisites.Rows[0].Cells[0].Text = "No Record Found"; 
                }
            }
        }

        protected void gvTalentSpells_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtTalentName = (TextBox)gvTalentSpells.FooterRow.FindControl("txtNewTalentName");
                TextBox txtTalentDescription = (TextBox)gvTalentSpells.FooterRow.FindControl("txtNewDescription");
                TextBox txtTier = (TextBox)gvTalentSpells.FooterRow.FindControl("txtNewTier");
                TextBox txtCost = (TextBox)gvTalentSpells.FooterRow.FindControl("txtNewCost");
                DropDownList ddlGodName = (DropDownList)gvTalentSpells.FooterRow.FindControl("ddlNewGodName");
                DropDownList ddlAttributeName = (DropDownList)gvTalentSpells.FooterRow.FindControl("ddlNewAttributeName");
                DropDownList ddlBooksourceName = (DropDownList)gvTalentSpells.FooterRow.FindControl("ddlNewBooksourceName");
                CheckBox chkWasRevised = (CheckBox)gvTalentSpells.FooterRow.FindControl("chkNewWasRevised");

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
                        AttributeType = Convert.ToInt32(ddlAttributeName.SelectedItem.Value),
                        Booksource = Convert.ToInt32(ddlBooksourceName.SelectedItem.Value)
                    });

                    context.SaveChanges();

                    FillTalentSpellsGrid();
                }
            }
            else if (e.CommandName.Equals("Select"))
            {
           		var id = gvTalentSpells.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0];
                gvTalentSpells.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                FillPrerequisiteGrid(Convert.ToInt32(id));
            }
        }

        protected void gvPrerequisites_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtNewTalentSpellsId = (TextBox)gvPrerequisites.FooterRow.FindControl("txtNewTalentSpellId");
                DropDownList ddlAttributeName = (DropDownList)gvPrerequisites.FooterRow.FindControl("ddlNewAttributeName");
                TextBox txtCost = (TextBox)gvPrerequisites.FooterRow.FindControl("txtNewCost");

                using (var context = new BlackCrusadeEntities())
                {
                    context.Prerequisites.Add(new Prerequisite()
                    {
                        TalentSpellId = Convert.ToInt32(txtNewTalentSpellsId.Text),
                        Cost = Convert.ToInt32(txtCost.Text),
                        AttributeType = Convert.ToInt32(ddlAttributeName.SelectedItem.Value)
                    });

                    context.SaveChanges();

                    var id = Convert.ToInt32(gvTalentSpells.DataKeys[gvTalentSpells.SelectedIndex].Value);
                    FillPrerequisiteGrid(id);
                }
            }
        }

        protected void gvTalentSpells_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTalentSpells.EditIndex = e.NewEditIndex;
            FillTalentSpellsGrid();
        }
        
        protected void gvPrerequisites_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPrerequisites.EditIndex = e.NewEditIndex;
            FillPrerequisiteGrid(Convert.ToInt32(gvTalentSpells.DataKeys[gvTalentSpells.SelectedIndex].Value));
        }

        protected void gvTalentSpells_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTalentSpells.EditIndex = -1;
            FillTalentSpellsGrid();
        }

        protected void gvPrerequisites_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPrerequisites.EditIndex = -1;
            FillPrerequisiteGrid(Convert.ToInt32(gvTalentSpells.DataKeys[gvTalentSpells.SelectedIndex].Value));
        }

        protected void gvTalentSpells_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtTalentName = (TextBox)gvTalentSpells.Rows[e.RowIndex].FindControl("txtTalentName");
            TextBox txtTalentDescription = (TextBox)gvTalentSpells.Rows[e.RowIndex].FindControl("txtDescription");
            TextBox txtTier = (TextBox)gvTalentSpells.Rows[e.RowIndex].FindControl("txtTier");
            TextBox txtCost = (TextBox)gvTalentSpells.Rows[e.RowIndex].FindControl("txtCost");
            DropDownList ddlGodName = (DropDownList)gvTalentSpells.Rows[e.RowIndex].FindControl("ddlGodName");
            DropDownList ddlAttributeName = (DropDownList)gvTalentSpells.Rows[e.RowIndex].FindControl("ddlAttributeName");
            DropDownList ddlBooksourceName = (DropDownList)gvTalentSpells.Rows[e.RowIndex].FindControl("ddlBooksourceName");

            using (var context = new BlackCrusadeEntities())
            {
                var id = Convert.ToInt32(gvTalentSpells.DataKeys[e.RowIndex].Values[0].ToString());
                var talentSpell = context.TalentSpells.FirstOrDefault(t => t.Id == (id));

                talentSpell.Name = txtTalentName.Text;
                talentSpell.Description = txtTalentDescription.Text;
                talentSpell.Tier = Convert.ToInt32(txtTier.Text);
                talentSpell.Cost = Convert.ToInt32(txtCost.Text);
                talentSpell.WhichGod = Convert.ToInt32(ddlGodName.SelectedItem.Value);
                talentSpell.AttributeType = Convert.ToInt32(ddlAttributeName.SelectedItem.Value);
                talentSpell.Revised = true;
                talentSpell.Booksource = Convert.ToInt32(ddlBooksourceName.SelectedItem.Value);
                context.SaveChanges();

                gvTalentSpells.EditIndex = -1;
                FillTalentSpellsGrid();
            }
        }

        protected void gvPrerequisites_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtTalentSpellId = (TextBox)gvPrerequisites.Rows[e.RowIndex].FindControl("txtTalentSpellId");
            DropDownList ddlAttributeName = (DropDownList)gvPrerequisites.Rows[e.RowIndex].FindControl("ddlAttributeName");
            TextBox txtCost = (TextBox)gvPrerequisites.Rows[e.RowIndex].FindControl("txtCost");

            using (var context = new BlackCrusadeEntities())
            {
                var id = Convert.ToInt32(gvPrerequisites.DataKeys[e.RowIndex].Values[0].ToString());
                var prerequisite = context.Prerequisites.FirstOrDefault(p => p.Id == (id));

                prerequisite.TalentSpellId = Convert.ToInt32(txtTalentSpellId.Text);
                prerequisite.AttributeType = Convert.ToInt32(ddlAttributeName.SelectedValue);
                prerequisite.Cost = Convert.ToInt32(txtCost.Text);

                context.SaveChanges();

                gvPrerequisites.EditIndex = -1;
                FillPrerequisiteGrid(Convert.ToInt32(gvTalentSpells.DataKeys[gvTalentSpells.SelectedIndex].Value));
            }
        }

        protected void gvTalentSpells_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var context = new BlackCrusadeEntities())
            {
                var id = Convert.ToInt32(gvTalentSpells.DataKeys[e.RowIndex].Values[0].ToString());

                var talentSpell = context.TalentSpells.FirstOrDefault(t => t.Id == id);

                context.TalentSpells.Remove(talentSpell);

                var prerequisites = context.Prerequisites.Where(p => p.TalentSpellId == id).ToList();
                prerequisites.ForEach(p => context.Prerequisites.Remove(p));
                context.SaveChanges();

                FillTalentSpellsGrid();
            }
        }

        protected void gvPrerequisites_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvTalentSpells_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            using (var context = new BlackCrusadeEntities())
            {
                var joined = (from T in context.TalentSpells
                              from G in context.BlackCrusadeGods
                              from A in context.AttributeTypes
                              from B in context.Booksources
                              where T.WhichGod == G.Id
                              where T.AttributeType == A.Id
                              where T.Booksource == B.Id
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
                                  AttributeId = A.Id,
                                  BooksourceId = T.Booksource,
                                  BooksourceName = B.Name
                              })
                                     .ToList();

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlGodName = e.Row.FindControl("ddlGodName") as DropDownList;

                    if (ddlGodName != null)
                    {
                        int id = Convert.ToInt32(gvTalentSpells.DataKeys[e.Row.RowIndex].Values[0].ToString());
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
                        int id = Convert.ToInt32(gvTalentSpells.DataKeys[e.Row.RowIndex].Values[0].ToString());
                        var talentSpell = joined.FirstOrDefault(j => j.Id == id);
                        ddlAttributeName.DataValueField = "Id";
                        ddlAttributeName.DataTextField = "Name";
                        ddlAttributeName.DataSource = context.AttributeTypes.ToList();
                        ddlAttributeName.DataBind();
                        ddlAttributeName.SelectedValue = talentSpell.AttributeId.ToString();
                    }

                    DropDownList ddlBooksourceName = e.Row.FindControl("ddlBooksourceName") as DropDownList;

                    if (ddlBooksourceName != null)
                    {
                        int id = Convert.ToInt32(gvTalentSpells.DataKeys[e.Row.RowIndex].Values[0].ToString());
                        var talentSpell = joined.FirstOrDefault(j => j.Id == id);
                        ddlBooksourceName.DataValueField = "Id";
                        ddlBooksourceName.DataTextField = "Name";
                        ddlBooksourceName.DataSource = context.BlackCrusadeGods.ToList();
                        ddlBooksourceName.DataBind();
                        ddlBooksourceName.SelectedValue = talentSpell.GodId.ToString();
                    }
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList ddlNewGodName = e.Row.FindControl("ddlNewGodName") as DropDownList;
                    ddlNewGodName.DataValueField = "Id";
                    ddlNewGodName.DataTextField = "Name";
                    ddlNewGodName.DataSource = context.BlackCrusadeGods.ToList();
                    ddlNewGodName.DataBind();

                    DropDownList ddlNewAttributeName = e.Row.FindControl("ddlNewAttributeName") as DropDownList;
                    ddlNewAttributeName.DataValueField = "Id";
                    ddlNewAttributeName.DataTextField = "Name";
                    ddlNewAttributeName.DataSource = context.AttributeTypes.ToList();
                    ddlNewAttributeName.DataBind();

                    DropDownList ddlBooksourceName = e.Row.FindControl("ddlNewBooksourceName") as DropDownList;
                    ddlBooksourceName.DataValueField = "Id";
                    ddlBooksourceName.DataTextField = "Name";
                    ddlBooksourceName.DataSource = context.Booksources.ToList();
                    ddlBooksourceName.DataBind();
                }
            }
        }

        protected void gvPrerequisites_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            using (var context = new BlackCrusadeEntities())
            {
                var prerequisites = (from T in context.Prerequisites
                                     from A in context.AttributeTypes
                                     where T.AttributeType == A.Id
                                     select new
                                     {
                                         TalentSpellId = T.TalentSpellId,
                                         Id = T.Id,
                                         AttributeName = A.Name,
                                         AttributeId = A.Id,
                                         Cost = T.Cost
                                     })
                                     .ToList();

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlAttributeName = e.Row.FindControl("ddlAttributeName") as DropDownList;

                    if (ddlAttributeName != null)
                    {
                        int id = Convert.ToInt32(gvPrerequisites.DataKeys[e.Row.RowIndex].Values[0].ToString());
                        // might be problem here. what if there is more than one result???
                        var prerequisite = prerequisites.FirstOrDefault(j => j.Id == id);
                        ddlAttributeName.DataValueField = "Id";
                        ddlAttributeName.DataTextField = "Name";
                        ddlAttributeName.DataSource = context.AttributeTypes.ToList();
                        ddlAttributeName.DataBind();
                        ddlAttributeName.SelectedValue = prerequisite.AttributeId.ToString();
                    }
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList ddlNewAttributeName = e.Row.FindControl("ddlNewAttributeName") as DropDownList;
                    ddlNewAttributeName.DataValueField = "Id";
                    ddlNewAttributeName.DataTextField = "Name";
                    ddlNewAttributeName.DataSource = context.AttributeTypes.ToList();
                    ddlNewAttributeName.DataBind();

                    var txtTalentSpellId = e.Row.FindControl("txtNewTalentSpellId") as TextBox;

                    if (txtTalentSpellId != null)
                    {
                        var id = gvTalentSpells.DataKeys[gvTalentSpells.SelectedIndex].Value;
                        txtTalentSpellId.Text = id.ToString();
                    }
                }
            }
        }
    }
}