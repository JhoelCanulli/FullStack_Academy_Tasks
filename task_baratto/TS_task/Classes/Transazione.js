"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Guid_1 = require("./Guid");
var Transazione = /** @class */ (function () {
    function Transazione() {
        this.codice = Guid_1.default.newGuid();
    }
    Transazione.prototype.addProposta = function (objPro) {
        if (!this.pro)
            this.pro = new Array();
        this.pro.push(objPro);
    };
    Transazione.prototype.effettuaTransazione = function (proposta) {
        this.addProposta(proposta);
        if (proposta.getUtenti().length >= 2) {
            var nominativoUtente1 = proposta.getUtenti()[0].getNominativo();
            var nominativoUtente2 = proposta.getUtenti()[1].getNominativo();
            proposta.getOggetti().forEach(function (oggetto) {
                proposta.getUtenti().forEach(function (utente) {
                    utente.rimuoviOggetto(oggetto.getCodice());
                });
            });
            console.log("Transazione completata tra utente 1: ".concat(nominativoUtente1, " e utente 2: ").concat(nominativoUtente2));
        }
        else {
            console.log("transazione fallita per numero insufficiente di utenti");
        }
    };
    Transazione.prototype.annullaTransazione = function (codiceProposta) {
        if (!this.pro || this.pro.length == 0) {
            console.log("non ci sono oggetti proposti");
            return;
        }
        var proposteRimaste = new Array();
        for (var i = 0; i < this.pro.length; i++) {
            if (this.pro[i].getCodice() != codiceProposta) {
                proposteRimaste.push(this.pro[i]);
            }
        }
        this.pro = proposteRimaste;
        console.log("transazione della proposta codide: ".concat(codiceProposta, " annullata."));
    };
    return Transazione;
}());
exports.default = Transazione;
