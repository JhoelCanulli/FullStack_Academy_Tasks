using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ORM_eventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_eventi.DAL
{
    internal class EventoDAL : IDAL
    {
        public void create()
        {

            Evento ev1 = new Evento()
            {
                EventoId = 1,
                Nome = "evento 1",
                Descrizione = "serata metal al clavicembalo",
                Capacita = 500,
                DataOra = Convert.ToDateTime("2024-03-15 20:00:00"),
                Luogo = "via Greve, 23, Roma"
            };

            Evento ev2 = new Evento()
            {
                EventoId = 2,
                Nome = "evento 2",
                Descrizione = "concerto di Anna Plank",
                Capacita = 50,
                DataOra = Convert.ToDateTime("2025-03-15 20:00:00"),
                Luogo = "viale della ginnastica, 23, Torino"
            };

            Evento ev3 = new Evento()
            {
                EventoId = 3,
                Nome = "evento 3",
                Descrizione = "serata Jazz",
                Capacita = 5,
                DataOra = Convert.ToDateTime("2024-03-17 20:00:00"),
                Luogo = "via Greve, 23, Roma"
            };

            using (var ctx = new DdlEventiContext())
            {
                try
                {
                    ctx.Eventos.Add(ev1);
                    ctx.Eventos.Add(ev2);
                    ctx.Eventos.Add(ev3);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        public void read()
        {
            ICollection<Evento> prova = new List<Evento>();

            using (var ctx = new DdlEventiContext())
            {
                try
                {
                    Evento temp1 = ctx.Eventos.Single(p => p.EventoId == 1);
                    Evento temp2 = ctx.Eventos.Single(p => p.EventoId == 2);
                    Evento temp3 = ctx.Eventos.Single(p => p.EventoId == 3);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        public void delete()
        {
            throw new NotImplementedException();
        }

        
        
    }
}
