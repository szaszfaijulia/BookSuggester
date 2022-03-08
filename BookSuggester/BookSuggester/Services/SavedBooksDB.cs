using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSuggester.Services
{
    class SavedBooksDB //adatbázis elérés, System.Data.SQLite -nél (nem ezt használom!)
    {
        /*private SQLiteConnection con = new SQLiteConnection("data source=SavedBooks.db");

        public SQLiteConnection GetConnection()
        {
            return con;
        }

        public void Openconnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void Closeconnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }*/
    }
}
