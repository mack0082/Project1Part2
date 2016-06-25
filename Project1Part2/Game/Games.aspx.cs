using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Project1Part2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Project1Part2
{
    public partial class Games : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the Game grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "GameID"; // default sort column
                Session["SortDirection"] = "ASC";
                // Get the Game data
                this.GetGames();
            }
        }

        private void GetGames()
        {
            // connect to Game
            using (GameConnection db = new GameConnection())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Game Table 
                var Games = (from allGames in db.Games
                             select allGames);

                // bind the result to the GridView
                GameGridView.DataSource = Games.AsQueryable().OrderBy(SortString).ToList();
                GameGridView.DataBind();
            }
        }



        protected void GameGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected GameId
            int GameID = Convert.ToInt32(GameGridView.DataKeys[selectedRow].Values["GameID"]);

            // use Game Connection to find the selected Game in the DB and remove it
            using (GameConnection db = new GameConnection())
            {
                // create object of the Game Class and store the query string inside of it
                Game deletedGame = (from gameRecords in db.Games
                                    where gameRecords.GameID == GameID
                                    select gameRecords).FirstOrDefault();

                // remove the selected game from the db
                db.Games.Remove(deletedGame);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetGames();
            }
        }

        protected void GameGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            GameGridView.PageIndex = e.NewPageIndex;

            // refresh the grid
            this.GetGames();
        }

        protected void GameGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sorty by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the Grid
            this.GetGames();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void GameGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < GameGridView.Columns.Count - 1; index++)
                    {
                        if (GameGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the new Page size
            GameGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the grid
            this.GetGames();
        }
    }
}