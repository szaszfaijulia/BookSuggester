using SQLite;
using System;

namespace BookSuggester.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Subject { get; set; }
        public int PubDate { get; set; }
        public string Image { get; set; }
        public bool IsReaded { get; set; } //olvasott oldalra
        public bool IsInProgress { get; set; } //kezdőlapon lévő listába
        public bool IsSaved { get; set; } //mentett oldalra         //nem kell, mert külön lesznek tárolva (?)
        //public DateTime 
    }
}