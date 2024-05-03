using ORM_eventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_eventi.DAL
{
    internal class PartecipanteDAL : IDAL
    {
        public void create()
        {
            Partecipante p1 = new Partecipante()
            {
                PartecipanteId = 159,
                Nome = "Muzio Scevola",
                Contatto = "M.Scevola@gmail.com",
                CodiceBiglietto = "ABC111",
                Deleted = null,
            };

            Partecipante p2 = new Partecipante()
            {
                PartecipanteId = 579,
                Nome = "Carola Alorac ",
                Contatto = "carol@lorac.com",
                CodiceBiglietto = "ABC112",
                Deleted = null,
            };
            using (var ctx = new DdlEventiContext())
            {
                try
                {
                    ctx.Partecipantes.Add(p1);
                    ctx.Partecipantes.Add(p2);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            
        }

        public void delete()
        {
            throw new NotImplementedException();
        }

        public void read()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
