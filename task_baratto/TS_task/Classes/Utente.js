"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Guid_1 = require("./Guid");
var Utente = /** @class */ (function () {
    function Utente(nominativo, oggetti) {
        this.codice = Guid_1.default.newGuid();
        this.oggetti = new Array();
        this.nominativo = nominativo;
        if (oggetti)
            this.oggetti = oggetti;
    }
    Utente.prototype.getNominativo = function () {
        return this.nominativo;
    };
    Utente.prototype.proponiOggetto = function (oggetto) {
        this.oggetti.push(oggetto);
    };
    Utente.prototype.rimuoviOggetto = function (codiceOggetto) {
        this.oggetti = this.oggetti.filter(function (oggetto) { return oggetto.getCodice() !== codiceOggetto; });
    };
    Utente.prototype.mostraUtente = function () {
        var infoOggetti;
        if (this.oggetti.length > 0) {
            infoOggetti = this.oggetti.map(function (oggetto) { return oggetto.mostraOggetto(); });
        }
        else {
            infoOggetti = "Nessun oggetto";
        }
        return "Utente: \nCodice: ".concat(this.codice, " \nNominativo: ").concat(this.nominativo, " \nOggetti:\n").concat(infoOggetti);
    };
    return Utente;
}());
exports.default = Utente;
