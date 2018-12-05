using System;
using System.Web.UI;

namespace Lab4Website
{
    public partial class Statistics : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OriginalTextbox.Text = "Καλησπέρα";

                //For not postbacks, update on page load.
                UpdateClickInfo();
            }
        }

        protected void CopyText_Click(object sender, EventArgs e)
        {
            CopiedTextbox.Text = OriginalTextbox.Text;
            Application["ButtonClicks"] = Convert.ToInt32(Application["ButtonClicks"]) + 1;
            Session["ButtonClicks"] = Convert.ToInt32(Session["ButtonClicks"]) + 1;

            //Update new numbers on postback.
            UpdateClickInfo();
        }

        private void UpdateClickInfo()
        {
            CurrentUsersLabel.Text = string.Format(
                            "Αυτή την στιγμή χρησιμοποιούν τον ιστότοπο {0} χρήστ{1}.",
                            Application["UserCount"].ToString(),
                            Application["UserCount"].ToString() == "1" ? "ης" : "ες");

            int previousClicks = Convert.ToInt32(Application["ButtonClicks"]) - Convert.ToInt32(Session["ButtonClicks"]);

            PreviousClicksLabel.Text = string.Format(
                "Κλικ από άλλους χρήστες: {0}",
                previousClicks);

            CurrentClicksLabel.Text = string.Format(
                "Κλικ που έχεις κάνει εσύ: {0}",
                Session["ButtonClicks"].ToString());

            TotalClicksLabel.Text = string.Format(
                "Τρέχοντα κλικ: {0}",
                Application["ButtonClicks"].ToString());
        }
    }
}