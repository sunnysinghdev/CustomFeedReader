using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeed
{
    class TPLib
    {
        public List<TPObject> GetTPData(string str)
        {
            List<TPObject> li = new List<TPObject>();
            str = str.Substring(str.IndexOf(TPSyntax.START)+ TPSyntax.START.Length, str.IndexOf(TPSyntax.CLOSE)- str.IndexOf(TPSyntax.START));
            Debug.WriteLine(str);
            string[] Articles = str.Split(new string[] { TPSyntax.SPLITTER }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string atricle in Articles) {
                var ob = GetTPObject(atricle);
                if (ob.isNull)
                    continue;
                li.Add(GetTPObject(atricle));
            }

            return li;

        }
        private TPObject GetTPObject(string article)
        {

            TPObject tp = new TPObject();
            ArticleFilter ar = new ArticleFilter(article);

            tp.Title = ar.GetAttributeText(TPSyntax.TITLE);
            tp.Heading = ar.GetAttributeText(TPSyntax.HEADER);
            tp.Description = ar.GetAttributeText(TPSyntax.DESCRIPTION);
            tp.Story = ar.GetAttributeText(TPSyntax.STORY);
            string url = ar.GetAttributeText(TPSyntax.IMG);
            url = String.IsNullOrEmpty(url) ? "ms-appx:///Assets/StoreLogo.png" : url;
            tp.ImgUrl = new Uri( url, UriKind.Absolute);
            tp.Nav = ar.GetAttributeText(TPSyntax.NAV);
            tp.isNull = String.IsNullOrEmpty(tp.Title) ? true : false;
            Debug.WriteLine(tp.ToString());

            return tp;
        }
       
    }
    class ArticleFilter {
        string article = "";
        
        public ArticleFilter(string line) {
            article = line;
        }
        public string GetAttributeText(string attr)
        {
            try
            {
                int index = article.IndexOf(attr) + attr.Length;
                int length = article.IndexOf(TPSyntax.END) - article.IndexOf(attr) - attr.Length;
                string line = article.Substring(index, length);
                article = article.Substring(article.IndexOf(TPSyntax.END) + TPSyntax.END.Length);
                return line;
            }
            catch (Exception) {
                return null;
            }
        }

    }
    class TPObject {
        public string Title { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public Uri ImgUrl { get; set; }
        public string Nav { get; set; }
        public bool isNull { get; set; }
        public override string ToString()
        {
            return "Title = "+Title+"\n"+
                "Heading = " + Heading + "\n"+
                "Description = "+Description + "\n"+
                "Story = "+Story+"\n"+
                "ImgUrl = "+ImgUrl + "\n"+
                "Nav = " + Title + "\n";
        }

    }
    class TPSyntax
    {
        public static string START = "#TPSTART#";
        public static string CLOSE = "#TPEND#";
        public static string TITLE = "#T#";
        public static string HEADER = "#H#";
        public static string DESCRIPTION = "#D#";
        public static string STORY = "#S#";
        public static string IMG = "#IURL#";
        public static string NAV = "#NAV#";
        public static string END = "#E#";
        public static string SPLITTER = "#NEXT#";

    }
}
