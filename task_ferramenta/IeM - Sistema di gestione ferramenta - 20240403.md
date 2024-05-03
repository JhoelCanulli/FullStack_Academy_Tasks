# Il sistema di gestione della ferramenta

Creare un sistema di gestione della ferramenta in grado di gestire prodotti caratterizzati almeno da:
- Codice (assegnato in automatico)
- Nome prodotto
- Descrizione
- Prezzo
- Quantità
- Categoria (univoca)
- Data di creazione

Il sistema dovrà essere in grado di:
- CRUD Prodotti
- Per lo stesso prodotto (identificato dal codice) aggiornare solo la quantità se inserito da zero
- Creare nella tabella dei pulsanti in grado di decrementare o incrementare la quantità (per ogni riga vicino al valore di quantità es: + 12 - )
- Creare una input che filtri dinamicamente tutti i risultati della tabella (suggerimento, non usare interval)
- All'inizio della tabella elencare il totale delle quantità per categoria