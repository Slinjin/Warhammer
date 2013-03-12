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
                                  AttributeName = A.Name
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
                TextBox txtTalentName = (TextBox)NewGridView.FooterRow.FindControl("txtTalentName");
                TextBox txtTalentDescription = (TextBox)NewGridView.FooterRow.FindControl("txtTalentDescription");
                TextBox txtTier = (TextBox)NewGridView.FooterRow.FindControl("txtTier");
                TextBox txtCost = (TextBox)NewGridView.FooterRow.FindControl("txtCost");
                TextBox txtGodName = (TextBox)NewGridView.FooterRow.FindControl("txtGodName");
                TextBox txtAttributeName = (TextBox)NewGridView.FooterRow.FindControl("txtAttributeName");
                CheckBox chkWasRevised = (CheckBox)NewGridView.FooterRow.FindControl("chkWasRevised");

                using (var context = new BlackCrusadeEntities())
                {
                    context.TalentSpells.Add(new TalentSpell()
                    {
                        //GodId = T.WhichGod,
                        //Id = T.Id,
                        //TalentName = T.Name,
                        //TalentDescription = T.Description,
                        //WasRevised = T.Revised,
                        //Tier = T.Tier,
                        //Cost = T.Cost,
                        //GodName = G.Name,
                        //AttributeName = A.Name
                        WhichGod = 1,
                        Name = txtTalentName.Text,
                        Description = txtTalentDescription.Text,
                        Tier = 333,
                        Cost = 555



                    });

                    context.SaveChanges();
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
            TextBox txtGodName = (TextBox)NewGridView.Rows[e.RowIndex].FindControl("txtGodName");
            TextBox txtAttributeName = (TextBox)NewGridView.Rows[e.RowIndex].FindControl("txtAttributeName");
            CheckBox chkWasRevised = (CheckBox)NewGridView.Rows[e.RowIndex].FindControl("chkWasRevised");

            using (var context = new BlackCrusadeEntities())
            {
                var id = Convert.ToInt32(NewGridView.DataKeys[e.RowIndex].Values[0].ToString());
                var talentSpell = context.TalentSpells.FirstOrDefault(t => t.Id == (id));

                talentSpell.Name = txtTalentName.Text;
                talentSpell.Description = txtTalentDescription.Text;
                talentSpell.Tier = Convert.ToInt32(txtTier.Text);
                talentSpell.Cost = Convert.ToInt32(txtTier.Text);
                //talentSpell.WhichGod = txtGodName
                //talentSpell.AttributeType = txtAttributeName
                talentSpell.Revised = chkWasRevised.Checked;
                //context.TalentSpells.Add(new TalentSpell()
                //{
                //    //GodId = T.WhichGod,
                //    //Id = T.Id,
                //    //TalentName = T.Name,
                //    //TalentDescription = T.Description,
                //    //WasRevised = T.Revised,
                //    //Tier = T.Tier,
                //    //Cost = T.Cost,
                //    //GodName = G.Name,
                //    //AttributeName = A.Name
                //    WhichGod = 1,
                //    Name = txtTalentName.Text,
                //    Description = txtTalentDescription.Text,
                //    Tier = 333,
                //    Cost = 555
                    


                //});

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
    }
}