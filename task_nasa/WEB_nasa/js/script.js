function search() {
    const searchTerm = document.getElementById('searchTerm').value;
    const searchType = document.getElementById('searchType').value;
    let url;

    switch(searchType) {
        case 'corpo':
            url = `http://localhost:5086/api/corpo/${searchTerm}`;
            break;
        case 'sistema':
            url = `http://localhost:5086/api/sistema/${searchTerm}`;
            break;
        // Aggiungi qui i casi per 'scopritore' e 'tipologia' una volta che hai gli endpoint specifici
        default:
            console.error('Tipo di ricerca non supportato');
            return;
    }

    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('Errore nella richiesta');
            }
            return response.json();
        })
        .then(data => {
            displayResults(data);
        })
        .catch(error => {
            console.error(error);
        });
}

function displayResults(data) {
    const resultsContainer = document.getElementById('results');
    resultsContainer.innerHTML = ''; // Pulisce i risultati precedenti

    // Esempio di visualizzazione, da personalizzare in base alla struttura dei tuoi dati
    const content = document.createElement('pre');
    content.textContent = JSON.stringify(data, null, 2);
    resultsContainer.appendChild(content);
}
