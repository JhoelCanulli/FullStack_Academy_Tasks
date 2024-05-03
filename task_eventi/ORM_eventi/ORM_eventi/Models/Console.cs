using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_eventi.Models
{
    internal class Console
    {
        void inserisciDati()
        {
            System.Console.WriteLine("Inserisci il nome dell'evento: ");
            string? inputNome = System.Console.ReadLine();
            System.Console.WriteLine("Inserisci la descrizione dell'evento: ");
            string? inputDescrizione = System.Console.ReadLine();
            System.Console.WriteLine("Inserisci la capacità del tuo evento: ");
            int inputCapacita = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Inserisci la data: ");
            DateTime inputData = DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Inserisci il luogo: ");
            string? inputLuogo = System.Console.ReadLine();
            
            //TO DO : richiamo EventoDAL passandogli i parametri
            // altrimenti
            /*
            Evento e = new Evento()
            {
                Nome = inputNome,
                Descrizione = inputDescrizione,
                Capacita = inputCapacita,
                DataOra = inputData,
                Luogo = inputLuogo
            };
            */
        }
    }
}
