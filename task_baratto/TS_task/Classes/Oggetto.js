"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Guid_1 = require("./Guid");
var Oggetto = /** @class */ (function () {
    function Oggetto(nome, descrizione) {
        this.nome = nome;
        this.descrizione = descrizione;
        if (nome != undefined || descrizione != undefined)
            this.codice = Guid_1.default.newGuid();
    }
    Oggetto.prototype.getCodice = function () {
        return this.codice;
    };
    Oggetto.prototype.mostraOggetto = function () {
        return "Oggetto:\n                \ncodice :".concat(this.codice, " \n                \nnome :").concat(this.nome, " \n                \ndescrizione :").concat(this.descrizione);
    };
    return Oggetto;
}());
exports.default = Oggetto;
