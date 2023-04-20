using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal static class VideogameManager
    {
        private static string stringaConnessione = "Data Source=localhost;Initial Catalog=Esercizio;Integrated Security=True;Pooling=False";
        public static int InserisciVideogame(string nome, string descrizione, DateTime uscita, int softwareHouse) 
        {
            int a;
            string query = "INSERT INTO videogames(name, overview, release_date, software_house_id) VALUES (@nome, @descrizione, @uscita, @softwareHouse)";
            using (SqlConnection conn = new SqlConnection(stringaConnessione))
            {
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@nome", nome));
                cmd.Parameters.Add(new SqlParameter("@descrizione", descrizione));
                cmd.Parameters.Add(new SqlParameter("@uscita", uscita));
                cmd.Parameters.Add(new SqlParameter("@softwareHouse", softwareHouse));
                a = cmd.ExecuteNonQuery();
            }
            return a;
        }
    }
}
