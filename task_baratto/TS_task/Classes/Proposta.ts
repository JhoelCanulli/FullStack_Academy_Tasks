import Guid from './Guid';
import Utente from './Utente';
import Oggetto from './Oggetto';

class Proposta{

    private codice: String = Guid.newGuid();
    private ute: Utente[];
    private ogg: Oggetto[];

    constructor(ute: Utente[], ogg: Oggetto[]){
        this.ute = ute;
        this.ogg = ogg;
    }

    public getUtenti(): Utente[] {
        return this.ute;
    }
    
    public getCodice() : String{
        return this.codice;
    }
    
    public getOggetti() : Oggetto[]{
        return this.ogg;
    }

    public mostraProposta(): string {
        let infoUtenti = this.ute.map(utente => utente.mostraUtente());
        let infoOggetti = this.ogg.map(oggetto => oggetto.mostraOggetto());
        return `Proposta:   \nCodice: ${this.codice} 
                            \nUtenti: ${infoUtenti} 
                            \nOggetti:${infoOggetti}`;
    }

    static creaProposta(ute: Utente[], ogg: Oggetto[]): Proposta {
        const proposta = new Proposta(ute, ogg);
        console.log(`Proposta codice: ${proposta.codice} creata.`);
        return proposta;
    }
}
export default Proposta;