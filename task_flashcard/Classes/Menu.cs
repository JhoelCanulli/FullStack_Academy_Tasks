using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcard_colloquio.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Menu
    {
        private List<Domanda> domande;
        private double punteggio;
        private Risposte risposte;

        public Menu()
        {
            domande = new List<Domanda>
        {   /* DATABASE */
            new Domanda(1, "\nQuali sono le caratteristiche principali di SQL Server?", "Database"),
            new Domanda(2, "\nCome creare un nuovo database in SQL Server?", "Database"),
            new Domanda(3, "\nIl linguaggio SQL è divisibile in quali sottoinsiemi funzionali?", "Database"),
            new Domanda(4, "\nCome creare una nuova tabella in un database SQL Server?", "Database"),
            new Domanda(5, "\nQuali sono i tipi più comuni utilizzati in SQL Server?", "Database"),
            new Domanda(6, "\nCome inserire i dati in una tabella SQL Server utilizzando la query INSERT?", "Database"),
            new Domanda(7, "\nCome modificare i dati esistenti in una tabella SQL utilizzando la query UPDATE?", "Database"),
            new Domanda(8, "\nCome modificare i dati da una tabella SQL Server utilizzando la query DELETE?", "Database"),
            new Domanda(9, "\nCome utilizzare la clausola WHERE per filtrare i risultati di una query SELECT?", "Database"),
            new Domanda(10, "\nQual è la differenza tra INNER JOIN, LEFT JOIN e RIGHT JOIN in SQL Server?", "Database"),
            new Domanda(11, "\nQuali sono le funzioni di aggregazione comuni in SQL Server e come utilizzarle?", "Database"),
            new Domanda(12, "\nCome utilizzare la clausola HAVING per filtrare i risultati di una query dopo aver utilizzato GROUP BY?", "Database"),
            new Domanda(13, "\nQual è lo scopo delle chiavi primarie e delle chiavi esterne?", "Database"),
            new Domanda(14, "\nCos'è l'indice in SQL Server e perché è importante?", "Database"),
            new Domanda(15, "\nCos'è la normalizzazione del database e perché è importante?", "Database"),
            new Domanda(16, "\nCos'è una transazione in SQL Server e quali sono le proprietà ACID?", "Database"),
            new Domanda(17, "\nCome utilizzare le istruzioni COMMIT e ROLLBACK per gestire le transazioni?", "Database"),
            new Domanda(18, "\nQual è lo scopo dei trigger in SQL Server e come crearne uno?", "Database"),
            new Domanda(19, "\nCos'è una stored procedure in SQL Server e come crearla?", "Database"),
            new Domanda(20, "\nQual è la differenza tra una stored procedure e una funzione in SQL Server?", "Database"),
            new Domanda(21, "\nTipicamente quante tabelle ci sono in una relazione many-to-many?", "Database"),
            new Domanda(22, "\nTipicamente quante tabelle ci sono in una relazione one-to-one?", "Database"),

            /* OOP */
            new Domanda(1, "\nCos'è l'OOP e quali sono i suoi principi fondamentali?", "OOP"),
            new Domanda(2, "\nQuali sono le differenze tra l'OOP e la programmazione procedurale?", "OOP"),
            new Domanda(3, "\nCos'è una classe in OOP e quali sono i suoi componenti?", "OOP"),
            new Domanda(4, "\nQual è la differenza tra una classe ed un oggetto?", "OOP"),
            new Domanda(5, "\nQual è il concetto di incapsulamento in OOP?", "OOP"),
            new Domanda(6, "\nCos'è l'ereditarietà in OOP e come funziona?", "OOP"),
            new Domanda(7, "\nQual'è il concetto di polimorfismo in OOP?", "OOP"),
            new Domanda(8, "\nCos'è una relazione di composizione in OOP?", "OOP"),
            new Domanda(9, "\nQual'è la differenza tra una relazione di composizione ed una relazione di aggregazione in OOP?", "OOP"),
            new Domanda(10, "\nQual'è il concetto di interfaccia in OOP e perchè è importante?", "OOP"),
            new Domanda(11, "\nQuali sono i vantaggi dell'OOP rispetto ad altri paradigmi di programmazione?", "OOP"),
            new Domanda(12, "\nQuali sono le differenze tra un linguaggio di programmazione orientato agli oggetti ed uno non orientato agli oggetti?", "OOP"),
            new Domanda(13, "\nQual'è la differenza tra un'interfaccia ed una classe astratta in OOP?", "OOP"),
            new Domanda(14, "\nUna classe astratta è implementabile da una sottoclasse?", "OOP"),
            new Domanda(15, "\nCome si utilizza il concetto di polimorfismo in OOP per scrivere codice più modulare e flessibile?", "OOP"),
            new Domanda(16, "\nCome si può implementare una relazione di ereditarietà in OOP?", "OOP"),
            new Domanda(17, "\nCos'è un costruttore in OOP e quando viene chiamato?", "OOP"),
            new Domanda(18, "\nQuali sono i tipi di accesso in OOP e qual'è la loro importanza?", "OOP"),
            new Domanda(19, "\nCos'è il polimorfismo in OOP?", "OOP"),
            new Domanda(20, "\nQual'è la differenza tra un metodo statico ed un metodo di istanza in OOP?", "OOP"),
            new Domanda(21, "\nQual'è la differenza tra un'istanza di una classe ed una variabile locale?", "OOP"),
            new Domanda(22, "\nCos'è un'eccezione in OOP e come gestirla?", "OOP"),
            new Domanda(23, "\nCome si utilizza l'ereditarietà multipla in OOP e quali sono le sue potenziali problematiche?", "OOP"),
            new Domanda(24, "\nCome si utilizza la parola chiave \"super\" in OOP ed in quali situazioni potrebbe essere necessario?", "OOP"),
            new Domanda(25, "\nCome si utilizza la parola chiave \"this\" in OOP ed in quali situazioni potrebbe essere necessario?", "OOP"),
            new Domanda(26, "\nQual'è il concetto di binding in OOP e quali sono i suoi tipi?", "OOP"),
            new Domanda(27, "\nQual'è il concetto di garbage collection in OOP e come funziona?", "OOP"),

        };
            punteggio = 0;
            risposte = new Risposte();

        }

        public void MostraMenu()
        {
            bool q = false;
            do
            {
                Console.WriteLine("Scegli il genere delle domande:");
                Console.WriteLine("1. Database");
                Console.WriteLine("2. OOP");
                Console.WriteLine("r. Tutte Random");
                Console.WriteLine("q. Esci dal programma");
                Console.Write("> ");
                string? scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AvviaQuiz("Database");
                        break;
                    case "2":
                        AvviaQuiz("OOP");
                        break;
                    case "r":
                    case "R":
                        AvviaQuiz(null); // null per indicare tutte le domande in modo random
                        break;
                    case "q":
                    case "Q":
                        q = true;
                        break;
                    default:
                        Console.WriteLine("\nScelta non valida.");
                        break;
                }
            } while (!q);
            
            Console.WriteLine($"\npunteggio finale : {punteggio}");
        }

        private void AvviaQuiz(string? genere)
        {
            List<Domanda> domandeFiltrate;
            bool carattereCorretto;

            if (string.IsNullOrEmpty(genere))
            {
                // genere non scelto -> tutte le domande di tutti i generi in modo randomico
                domandeFiltrate = domande.OrderBy(x => Guid.NewGuid()).ToList();
            }
            else
            {
                // genere scelto
                domandeFiltrate = domande.Where(d => d.Genere == genere).ToList();
            }

            foreach (Domanda domanda in domandeFiltrate)
            {
                Console.WriteLine(domanda.Testo);
                Console.WriteLine("\n[ Digita qualsiasi tasto per visualizzare la risposta ]\n");
                Console.ReadKey();

                carattereCorretto = false;
                Console.WriteLine($"Risposta : {risposte.OttieniRisposta(domanda.Id, domanda.Genere)}");
                while (!carattereCorretto)
                {
                    Console.Write("\nHai risposto correttamente? (s/n):\n> ");
                    string? risposta = Console.ReadLine().Trim().ToLower();
                    Console.WriteLine("");

                    if (risposta == "s") {
                        punteggio += 1;
                        carattereCorretto = true;
                    }
                    else if (risposta == "n") {
                        punteggio -= 0.5;
                        carattereCorretto = true;
                    }
                    else
                    {
                        Console.WriteLine("\nerrore : carattere non definito!");
                    }
                }

                Console.WriteLine($"Punteggio attuale : + {punteggio}");
                Console.Write("\n[ premi invio per continuare, altrimenti per tornare al menu principale (m) o uscire (q) ]\n> ");
                string? azione = Console.ReadLine().Trim().ToLower();

                if (azione == "m")
                {
                    MostraMenu(); 
                    return; 
                }
                else if (azione == "q")
                {
                    Environment.Exit(0);
                }
            }
        }
    }

}
