"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Utente = void 0;
var Guid = /** @class */ (function () {
    function Guid() {
    }
    Guid.newGuid = function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    };
    return Guid;
}());
exports.default = Guid;
var Utente = /** @class */ (function () {
    function Utente(nominativo) {
        this.codice = Guid.newGuid();
        this.nominativo = nominativo;
    }
    Utente.prototype.getCodice = function () {
        return this.codice;
    };
    Utente.prototype.stampaUte = function () {
        return "Persona: ".concat(this.codice, " ").concat(this.nominativo);
    };
    Utente.prototype.visualizzaOggettiDiUtente = function (cod) {
        if (cod == this.codice) {
            for (;;)
                ;
        }
    };
    return Utente;
}());
exports.Utente = Utente;
