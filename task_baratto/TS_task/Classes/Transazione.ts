import Guid from './Guid';
import Oggetto from './Oggetto';
import Proposta from './Proposta';

class Transazione{

    private codice: String = Guid.newGuid();
    private pro: Proposta[] | undefined;

    constructor(){
    }

    public addProposta(objPro: Proposta) : void{
        if(!this.pro)
            this.pro = new Array();

        this.pro.push(objPro);
    }

    public effettuaTransazione(proposta: Proposta): void {
        this.addProposta(proposta);
        if (proposta.getUtenti().length >= 2) {

            const nominativoUtente1 = proposta.getUtenti()[0].getNominativo();
            const nominativoUtente2 = proposta.getUtenti()[1].getNominativo();
            
            proposta.getOggetti().forEach(oggetto => {
                proposta.getUtenti().forEach(utente => {
                    utente.rimuoviOggetto(oggetto.getCodice());
                });
            });
        
            console.log(`Transazione completata tra utente 1: ${nominativoUtente1} e utente 2: ${nominativoUtente2}`);
        } else {
            console.log("transazione fallita per numero insufficiente di utenti");
        }
    }

    public annullaTransazione(codiceProposta: String): void {
        if (!this.pro || this.pro.length == 0) {
            console.log("non ci sono oggetti proposti");
            return;
        }
        
        let proposteRimaste: Proposta[] = new Array();
        for (let i = 0; i < this.pro.length; i++) {
            if (this.pro[i].getCodice() != codiceProposta) {
                proposteRimaste.push(this.pro[i]);
            }
        }
        
        this.pro = proposteRimaste;
        console.log(`transazione della proposta codide: ${codiceProposta} annullata.`);
    }
}

export default Transazione;