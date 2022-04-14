let members = [];
let connection = null;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:41126/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PartyMemberCreated", (user, message) => {
        getdata();
    });

    connection.on("PartyMemberDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });

    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:41126/partymember').then(x => x.json()).then(y => {
        members = y;
        //console.log(members);
        display();
    });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    members.forEach(x => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + x.memberID + "</td><td>" + x.lastName + "</td><td>" + x.age + "</td><td>" + x.partyID +
        "</td><td>" + `<button type="button" onclick="remove(${x.memberID})">Delete</button>` + "</td></tr>";
        console.log(x.lastName);
    });
}

function remove(id) {
    fetch('http://localhost:41126/partymember/' + id, {
        method: 'delete',
        headers: { 'content-type': 'application/json', },
        body: null}).then(response => response).then(data => { console.log('success:', data); getdata(); }).catch((error) => { console.error('error:', error); });
}

function create() {
    let name = document.getElementById('membername').value;
    let age = document.getElementById('memberage').value;
    let partyid = document.getElementById('partyid').value;

    fetch('http://localhost:41126/partymember', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ lastName: name, age: age, partyID: partyid }),
    }).then(response => response).then(data => { console.log('Success:', data); getdata(); }).catch((error) => { console.error('Error:', error); });
}