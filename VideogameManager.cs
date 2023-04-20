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
            string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@nome, @descrizione, @uscita, @softwareHouse)";
            using SqlConnection conn = new SqlConnection(stringaConnessione);
            
            using SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@nome", nome));
            cmd.Parameters.Add(new SqlParameter("@descrizione", descrizione));
            cmd.Parameters.Add(new SqlParameter("@uscita", uscita));
            cmd.Parameters.Add(new SqlParameter("@softwareHouse", softwareHouse)); 
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Non è stato possibile salvare il videogioco");
            }
        }

        public static Videogame CercaVideogameId(int n)
        {
            string query = "SELECT * FROM videogames WHERE id = @id";
            using SqlConnection conn = new SqlConnection(stringaConnessione);
            using SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@id", n));
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            try
            {
                return new Videogame((string)r["name"], (string)r["overview"], (DateTime)r["release_date"], (long)r["software_house_id"]);
            }
            catch
            {
                throw new Exception("Videogioco non trovato");
            }
        }
        public static List<Videogame> CercaVideogameNome(string s)
        {
            s = "%" + s + "%";
            string query = "SELECT * FROM videogames WHERE name LIKE @name";
            using SqlConnection conn = new SqlConnection(stringaConnessione);
            using SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@name", s));
            SqlDataReader r = cmd.ExecuteReader();
            try
            {   List<Videogame> list = new List<Videogame>();
                while(r.Read())
                    list.Add(new Videogame((string)r["name"], (string)r["overview"], (DateTime)r["release_date"], (long)r["software_house_id"]));
                return list;
            }
            catch
            {
                throw new Exception("Videogioco non trovato");
            }
        }

        public static int CancellaVideogame(int id)
        {
            string query = "DELETE FROM videogames WHERE id = @id";
            using SqlConnection conn = new SqlConnection(stringaConnessione);
            using SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Impossibile cancellare il videogioco");
            }
        }
    }
}
