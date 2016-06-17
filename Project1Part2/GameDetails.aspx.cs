﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Project1Part2.Models;
using System.Web.ModelBinding;

namespace Project1Part2
{
    public partial class GameDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGames();
            }
        }

        private void GetGames()
        {
            // populate teh form with existing data from the database
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);

            // connect to the EF DB
            using (GameConnection db = new GameConnection())
            {
                // populate a student object instance with the StudentID from the URL Parameter
                Game updatedGame = (from Game in db.Games
                                    where Game.GameID == GameID
                                    select Game).FirstOrDefault();

                // map the student properties to the form controls
                if (updatedGame != null)
                {


                    GameDateTextBox.Text = updatedGame.GameDate.ToString("yyyy-MM-dd");
                    GameNameTextBox.Text = updatedGame.GameName;
                    DescriptionTextBox.Text = updatedGame.Description;
                    ScoreOfTeamATextBox.Text = updatedGame.ScoreOfTeamA.ToString();
                    ScoreOfTeamBTextBox.Text = updatedGame.ScoreOfTeamB.ToString();
                    WinningTeamTextBox.Text = updatedGame.WinningTeam;
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (GameConnection db = new GameConnection())
            {
                // use the Student model to create a new student object and
                // save a new record
                Game newGame = new Game();

                int GameID = 0;

                if (Request.QueryString.Count > 0) // our URL has a StudentID in it
                {
                    // get the id from the URL
                    GameID = Convert.ToInt32(Request.QueryString["GameID"]);

                    // get the current student from EF DB
                    newGame = (from game in db.Games
                               where game.GameID == GameID
                               select game).FirstOrDefault();
                }

                // add form data to the new student record
                newGame.GameDate = Convert.ToDateTime(GameDateTextBox.Text);
                newGame.GameName = GameNameTextBox.Text;
                newGame.Description = DescriptionTextBox.Text;
                newGame.ScoreOfTeamA = Convert.ToInt32(ScoreOfTeamATextBox.Text);
                newGame.ScoreOfTeamB = Convert.ToInt32(ScoreOfTeamBTextBox.Text);
                newGame.WinningTeam = WinningTeamTextBox.Text;
                // use LINQ to ADO.NET to add / insert new student into the database

                if (GameID == 0)
                {
                    db.Games.Add(newGame);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Games.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Students page
            Response.Redirect("~/Game.aspx");
        }
    }
}