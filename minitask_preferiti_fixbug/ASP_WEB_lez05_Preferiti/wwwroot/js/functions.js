function elimina(varCodice) {
    $.ajax(
        {
            url: "/Film/Elimina/" + varCodice,
            type: "DELETE",
            success: function () {
                window.location.reload();
            },
            error: function (errore) {
                alert(errore)
            }
        }
    )
}

function preferiti(varCodice){
    $.ajax(
        {
            url: "/Film/Aggiungi/" + varCodice,
            type: "GET",
            success: function () {
                window.location.reload();
            },
            error: function (errore) {
                alert(errore)
            }
        }
    )
}