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
        private Boolean flag = false;
        private DateTime baseDate = DateTime.Now;
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
                if (flag == false)
                {
                    baseDate = DateTime.Today;
                }
                
                var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
                var lastWeekStart = thisWeekStart.AddDays(-7);
                var nextWeekStart = thisWeekStart.AddDays(7);
                PreviousWeekButton.CommandArgument = lastWeekStart.ToString();
                NextWeekButton.CommandArgument = nextWeekStart.ToString();
                // query the Games Table
                var Games = (from allGames in db.Games
                             where allGames.GameDate>=thisWeekStart
                             && allGames.GameDate<=thisWeekEnd
                             select allGames);

                // bind the result to the GridView
                GameGridView.DataSource = Games.AsQueryable().ToList();
                GameGridView.DataBind();
                flag = false;
            }
        }

        protected void PreviousWeekButton_Click(object sender, EventArgs e)
        {
            flag = true;
           baseDate=Convert.ToDateTime(PreviousWeekButton.CommandArgument);
            GetGames();
           
        }

        protected void NextWeekButton_Click(object sender, EventArgs e)
        {
            flag = true;
            baseDate = Convert.ToDateTime(NextWeekButton.CommandArgument);
            GetGames();
        }
    }
}