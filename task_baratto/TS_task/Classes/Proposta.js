"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Guid_1 = require("./Guid");
var Proposta = /** @class */ (function () {
    function Proposta(ute, ogg) {
        this.codice = Guid_1.default.newGuid();
        this.ute = ute;
        this.ogg = ogg;
    }
    Proposta.prototype.getUtenti = function () {
        return this.ute;
    };
    Proposta.prototype.getCodice = function () {
        return this.codice;
    };
    Proposta.prototype.getOggetti = function () {
        return this.ogg;
    };
    Proposta.prototype.mostraProposta = function () {
        var infoUtenti = this.ute.map(function (utente) { return utente.mostraUtente(); });
        var infoOggetti = this.ogg.map(function (oggetto) { return oggetto.mostraOggetto(); });
        return "Proposta:   \nCodice: ".concat(this.codice, " \n                            \nUtenti: ").concat(infoUtenti, " \n                            \nOggetti:").concat(infoOggetti);
    };
    Proposta.creaProposta = function (ute, ogg) {
        var proposta = new Proposta(ute, ogg);
        console.log("Proposta codice: ".concat(proposta.codice, " creata."));
        return proposta;
    };
    return Proposta;
}());
exports.default = Proposta;
