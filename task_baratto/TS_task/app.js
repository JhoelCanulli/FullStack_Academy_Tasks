"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Oggetto_1 = require("./Classes/Oggetto");
var Utente_1 = require("./Classes/Utente");
var Proposta_1 = require("./Classes/Proposta");
var Transazione_1 = require("./Classes/Transazione");
var oggetti = [
    new Oggetto_1.default("Pipa", "di legno"),
    new Oggetto_1.default("Arpa", "per musicanti di altri tempi"),
    new Oggetto_1.default("Mouse", "da Gamer"),
];
oggetti.forEach(function (oggetto) { return console.log(oggetto.mostraOggetto()); });
var utente1 = new Utente_1.default("Marco Ocram");
var utente2 = new Utente_1.default("Baldo Odlab");
utente1.proponiOggetto(oggetti[0]);
utente2.proponiOggetto(oggetti[2]);
var proposta = Proposta_1.default.creaProposta([utente1, utente2], oggetti);
var transazione = new Transazione_1.default();
transazione.effettuaTransazione(proposta);
oggetti.forEach(function (oggetto) { return console.log(oggetto.mostraOggetto()); });
