using System;

namespace BookSuggester.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public int AuthorID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Subject { get; set; }
        public int PubDate { get; set; }
        //public bool IsReaded { get; set; }
        //public bool IsSaved { get; set; }
    }
}