import Guid from './Guid';

class Oggetto{
    private codice: string;
    private nome: string;
    private descrizione?: string;

    constructor(nome: string, descrizione?: string){
        this.nome = nome;
        this.descrizione = descrizione;
        if(nome != undefined || descrizione != undefined) this.codice = Guid.newGuid();
    }

    public getCodice() : string{
        return this.codice;
    }

    public mostraOggetto(){
        return `Oggetto:
                \ncodice :${this.codice} 
                \nnome :${this.nome} 
                \ndescrizione :${this.descrizione}`;
    }
}

export default Oggetto;