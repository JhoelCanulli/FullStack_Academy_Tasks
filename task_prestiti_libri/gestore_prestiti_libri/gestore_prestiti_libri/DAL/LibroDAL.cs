using gestore_prestiti_libri.Models;
using gestore_prestiti_libri.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestore_prestiti_libri.DAL
{
    internal class LibroDAL : IDal<Libro>
    {
        private static LibroDAL? istanza;

        public static LibroDAL getIstanza()
        {
            if(istanza == null)
                istanza = new LibroDAL();

            return istanza;
        }

        private LibroDAL() { }   

        public bool Delete(Libro t)
        {
            throw new NotImplementedException();
        }

        public List<Libro> GetAll()
        {
            throw new NotImplementedException();
        }

        public Libro? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Libro t)
        {
            bool risultato = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "";

                try
                {
                    con.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
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
            }

            return risultato;
        }

        public bool Update(Libro t)
        {
            throw new NotImplementedException();
        }
    }
}
