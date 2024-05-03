import Guid from './Guid';
import Oggetto from './Oggetto';

class Utente{
    private codice: string = Guid.newGuid();
    private nominativo: string | undefined;
    private oggetti: Oggetto[] = new Array();

    constructor(nominativo?: string, oggetti?: Oggetto[]){
        this.nominativo = nominativo;
        if (oggetti) this.oggetti = oggetti;
    }

    public getNominativo(): string | undefined {
        return this.nominativo;
    }

    public proponiOggetto(oggetto: Oggetto): void {
        this.oggetti.push(oggetto);
    }

    public rimuoviOggetto(codiceOggetto: string): void {
        // TO DO
    }

    public mostraUtente(): string {
        let infoOggetti;
        if (this.oggetti.length > 0) {
            infoOggetti = this.oggetti.map(oggetto => oggetto.mostraOggetto());
        } else {
            infoOggetti = "Nessun oggetto";
        }

        return `Utente: \nCodice: ${this.codice} \nNominativo: ${this.nominativo} \nOggetti:\n${infoOggetti}`;
    }    
}

export default Utente;