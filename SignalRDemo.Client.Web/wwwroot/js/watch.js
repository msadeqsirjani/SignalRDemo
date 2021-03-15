"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/watch")
    .build();

connection.on("View", function (viewer) {
    document.getElementById("viewer").innerText = viewer;
});

function notify() {
    connection.send("Watch");
}

function successToConnect() {
    console.log("Successfully connected to hub");

    notify();
}

function failureToConnect() {
    console.log("Unfortunately couldn't connect to hub");
}

connection.start()
    .then(successToConnect)
    .catch(failureToConnect);