using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @author: Kinjal & Mayank
 * @date: June 08, 2016
 * @version: 0.0.1 - added SetActivePage method
 */

namespace Project1Part2
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Games":
                    Games.Attributes.Add("class", "active");
                    break;
                case "Contact":
                    contact.Attributes.Add("class", "active");
                    break;
                case "About Us":
                    about.Attributes.Add("class", "active");
                    break;
                case "Log IN":
                    login.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}