import Oggetto from './Classes/Oggetto';
import Utente from './Classes/Utente';
import Proposta from './Classes/Proposta';
import Transazione from './Classes/Transazione';

let oggetti = [
    new Oggetto("Pipa", "di legno"),
    new Oggetto("Arpa", "per musicanti di altri tempi"),
    new Oggetto("Mouse", "da Gamer"),
];

oggetti.forEach(oggetto => console.log(oggetto.mostraOggetto()));

let utente1 = new Utente("Marco Ocram");
let utente2 = new Utente("Baldo Odlab");

utente1.proponiOggetto(oggetti[0]); 
utente2.proponiOggetto(oggetti[2]); 

let proposta = Proposta.creaProposta([utente1, utente2], oggetti);

let transazione = new Transazione();
transazione.effettuaTransazione(proposta);

oggetti.forEach(oggetto => console.log(oggetto.mostraOggetto()));
