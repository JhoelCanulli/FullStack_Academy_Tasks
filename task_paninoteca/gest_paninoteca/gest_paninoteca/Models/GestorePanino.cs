using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace gest_paninoteca.Models
{
    internal class GestorePanino 
    {
        private string connString = "Server=ACADEMY2024-05\\SQLEXPRESS;Database=acc_lez24_citta;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";

        public bool insert(Panino pan) {

            bool risultato = false;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Panino(nome, descrizione, prezzo, vegan) VALUES (@nome, @descrizione, @prezzo, @vegan)";
                cmd.Parameters.AddWithValue("@nome", pan.Nome);
                cmd.Parameters.AddWithValue("@descrizione", pan.Descrizione);
                cmd.Parameters.AddWithValue("@prezzo", pan.Prezzo);
                cmd.Parameters.AddWithValue("@vegan", pan.IsVegan);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return risultato;
            }
        }

        public List<Panino>? findAll()
        {
            List<Panino> elenco = new List<Panino>();
            using(SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT paninoID, nome, descrizione, prezzo, vegan FROM Panino";

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        elenco.Add(new Panino() {
                            ID = Convert.ToInt32(reader,)
                        });
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return null;
            }
        }

            
    }
}
