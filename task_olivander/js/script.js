function uniqueNumber() {
    var date = Date.now();
    if (date <= uniqueNumber.previous) {
        date = ++uniqueNumber.previous;
    } else {
        uniqueNumber.previous = date;
    }
    return date;
}

const stampa = () => {
    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );

    let stringaTabella = '';
    for(let [idx, item] of elenco.entries()){
        stringaTabella += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.cod}</td>
                <td>${item.mate}</td>
                <td>${item.nucl}</td>
                <td>${item.lungh}</td>
                <td>${item.resist}</td>
                <td>${item.mag}</td>
                <td>${item.cas}</td>
                <td class="text-right">
                    <button class="btn btn-outline-warning" onclick="modifica(${idx})">
                        <i class="fa-solid fa-pencil"></i>
                    </button>
                    <button class="btn btn-outline-danger" onclick="elimina(${idx})">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;
    }

    document.getElementById("corpo-tabella").innerHTML = stringaTabella;
}

const salva = () => {
    
    let mate = document.getElementById("input-materiale").value;
    let nucl = document.getElementById("input-nucleo").value;
    let lungh = document.getElementById("input-lunghezza").value;
    let resist = document.getElementById("input-resistenza").value;
    let mag = document.getElementById("input-mago").value;
    let cas = document.getElementById("select-casata").value;

    let ogg = {
        cod : uniqueNumber(),
        mate,
        nucl,
        lungh,
        resist,
        mag,
        cas,
    }

    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') ); //Prendo il vecchio elenco decodificato sotto forma di oggetto
    elenco.push(ogg);                                               //Aggiungo l'elemento al vecchio elenco
    localStorage.setItem('oggetti_olvd', JSON.stringify(elenco));    //Ricodifico l'elenco (sotto forma di stringa) per poterlo salvare nel Local Storage

    document.getElementById("input-codice").value = "";
    document.getElementById("input-materiale").value = "";
    document.getElementById("input-nucleo").value = "";
    document.getElementById("input-lunghezza").value = "";
    document.getElementById("input-resistenza").value = "";
    document.getElementById("input-mago").value = "";
    document.getElementById("select-casata").value = "";

    stampa();

    $("#modaleInserimento").modal("hide");
}

const elimina = (indice) => {
    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );
    elenco.splice(indice, 1);
    localStorage.setItem('oggetti_olvd', JSON.stringify(elenco));

    stampa();
}

const modifica = (indice) => {

    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );
    console.log(elenco[indice])

    document.getElementById("update-codice").value = elenco[indice].cod;
    document.getElementById("update-materiale").value = elenco[indice].mate;
    document.getElementById("update-nucleo").value = elenco[indice].nucl;
    document.getElementById("update-lunghezza").value = elenco[indice].lungh;
    document.getElementById("update-resistenza").value = elenco[indice].resist;
    document.getElementById("update-mago").value = elenco[indice].mag;
    document.getElementById("update-casata").value = elenco[indice].cas;

    $("#modaleModifica").data("identificativo", indice)

    $("#modaleModifica").modal("show");
}

const update = () => {
    
    let mate = document.getElementById("update-materiale").value;
    let nucl = document.getElementById("update-nucleo").value;
    let lungh = document.getElementById("update-lunghezza").value;
    let resist = document.getElementById("update-resistenza").value;
    let mag = document.getElementById("update-mago").value;
    let cas = document.getElementById("update-casata").value;

    let ogg = {
        cod : uniqueNumber(),
        mate,
        nucl,
        lungh,
        resist,
        mag,
        cas,
    }

    let indice = $("#modaleModifica").data("identificativo")

    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );
    elenco[indice] = ogg;
    localStorage.setItem('oggetti_olvd', JSON.stringify(elenco));

    $("#modaleModifica").modal("hide");
}



//Creazione elenco se non esiste
let elencoString = localStorage.getItem('oggetti_olvd');
if(!elencoString)
    localStorage.setItem('oggetti_olvd', JSON.stringify([]) );

setInterval(() => {
    stampa(); 
}, 1000);

stampa(); 