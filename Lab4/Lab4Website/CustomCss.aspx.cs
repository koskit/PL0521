using System;
using System.Collections.Generic;

namespace Lab4Website
{
    public partial class CustomCss : System.Web.UI.Page
    {
        private List<string> Backgrounds = new List<string>()
        {
            "lightblueBackground",
            "rosybrownBackground",
            "darkcyanBackground"
        };

        private List<string> LetterStyles = new List<string>()
        {
            "boldLetters",
            "italicLetters"
        };

        private List<string> Boarders = new List<string>()
        {
            "boarderDotted",
            "boarderDouble"
        };

        private List<string> Fonts = new List<string>()
        {
            "arialFont",
            "newTimesRomanFont"
        };

        private List<string> Floats = new List<string>()
        {
            "floatLeft",
            "floatRight"
        };

        private int PossibleCombinations
        {
            get
            {
                return Backgrounds.Count *
                    LetterStyles.Count *
                    Boarders.Count *
                    Fonts.Count *
                    Floats.Count;
            }
        }

        private T GetRandomValueFrom<T>(List<T> list)
        {
            int index = new Random().Next(0, list.Count);
            return list[index];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string cssClass = string.Format("{0} {1} {2} {3} {4}",
                GetRandomValueFrom(Backgrounds),
                GetRandomValueFrom(LetterStyles),
                GetRandomValueFrom(Boarders),
                GetRandomValueFrom(Fonts),
                GetRandomValueFrom(Floats));
            luckyLabel.CssClass = cssClass;

            luckyInfo.Text = string.Format("Classes used \"{0}\" out of {1} possible combinations.",
                cssClass,
                PossibleCombinations);
        }
    }
}