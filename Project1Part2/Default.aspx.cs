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
    public partial class Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the game grid
            if (!IsPostBack)
            {

                // Get the Game data
                this.GetGames();
            }
        }

        private void GetGames()
        {
            // connect to EF
            using (GameConnection db = new GameConnection())
            {
                //  string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Games Table
                var Games = (from allGames in db.Games
                             select allGames);

                // bind the result to the GridView
                GameGridView.DataSource = Games.AsQueryable().ToList();
                GameGridView.DataBind();
            }
        }
    }
}