let list = [];

function addTicketToList(r, p) {

    let Ticketlist = document.getElementById("TicketList");
    let element = document.createElement("li");
    element.id = "row:"+r + "," + "place:" +p;
    element.innerHTML = "Rząd:" + r + " Miejsce:" + p;
    Ticketlist.appendChild(element);
}
function deleteTicketFromList(r,p) {

    let list = document.getElementById("TicketList");

    let listItems = list.getElementsByTagName('li');

    for (let i = 0; i < listItems.length; i++) {
        if (listItems[i].id == "row:" + r + "," + "place:" + p) {

            listItems[i].remove();

        }
    }

}

function selectSit(r, p) {
    let btn = document.getElementById("purscheButton")
         
  

    let element = document.getElementById("r:" + r + ",p:" + p);

    let seat = { row: r , place: p };

    if (element.classList.contains("avaibleSit")) {
        element.classList.remove("avaibleSit");

        addTicketToList(r, p);


        list.push(seat);

    } else {
        element.classList.add("avaibleSit");
        deleteTicketFromList(r, p);

        let indexToRemove = list.findIndex((item) => item.row === r && item.place === p);

        if (indexToRemove !== -1) {
            list.splice(indexToRemove, 1);
        }
    }
   

    if (list.length > 0) {
        btn.disabled = false;
    } else {
        btn.disabled = true;
    }
}

function pursche() {

    
    console.log("test"+ JSON.stringify(list));
    let json = JSON.stringify(list);

    $.ajax({
        url: '/Ticket/TicketInfo/' + id,
        type: 'POST',
        data: json,
        contentType: 'application/json',
        success: function (result) {
           
            $('body').html(result);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}