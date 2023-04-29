let list = [];

function selectSit(r, p) {

    let element = { row: r, place: p };

    list.push(element);
}

function pursche() {

    fetch('/Ticket/TicketInfo', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(list)
    })
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error(error));
}