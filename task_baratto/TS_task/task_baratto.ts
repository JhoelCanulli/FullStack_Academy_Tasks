class Utente{
    private codice: string = Guid.newGuid();
    private nominativo: string | undefined;

    constructor(nominativo?: string){
        this.nominativo = nominativo;
    }
    public stampaPer(){
        return `Persona: ${this.codice} ${this.nominativo}`;
    }


}

class Oggetto{
    private codice: string = Guid.newGuid();
    private nome: string | undefined;
    private descrizione: string | undefined;

    constructor(nome?: string, descrizione?: string){
        this.nome = nome;
        this.descrizione = descrizione;
    }
    public stampaOgg(){
        return `Oggetto: ${this.codice} ${this.nome} ${this.descrizione}`;
    }
}

class Proposta{

    private codice: String = Guid.newGuid();
    private descrizione: string | undefined;
    private ute: Utente[] | undefined;
    private ogg: Oggetto[] | undefined;

    constructor(descrizione?: string, ute?: Utente[], ogg?: Oggetto[]){
        this.descrizione = descrizione;
        this.ute = ute;
        this.ogg = ogg;
    }

    //TO DO : public mostraOggettiProposti()
}

class Transazione{

    private codice: String = Guid.newGuid();
    private ogg: Oggetto[] | undefined;
    private pro: Proposta[] | undefined;

    constructor(){
    }

    public addProposta(objPro: Proposta) : void{
        if(!this.pro)
            this.pro = new Array();

        this.pro.push(objPro);
    }
}



let pe = new Persona("Marco Ocram");
let og_uno = new Oggetto("Pipa", "di legno");
let og_due = new Oggetto("Arpa", "per musicanti di altri tempi");
let og_tre = new Oggetto("Mouse", "da Gamerone");
let tr;
tr = new Transazione().addOggetto(og_uno);
tr = new Transazione().addOggetto(og_due);
tr = new Transazione().addOggetto(og_tre);

pe.stampaPer();

tr.forEach(el => {
    el.stampaOgg();
});