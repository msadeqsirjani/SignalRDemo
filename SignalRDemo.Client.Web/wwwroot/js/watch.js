"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/watch")
    .build();

connection.on("View", function (viewer) {
    console.log(viewer);
    document.getElementById("viewer").innerText = viewer.toString();
});

function successToConnect() {
    console.log("Successfully connected to hub");
}

function failureToConnect() {
    console.log("Unfortunately couldn't connect to hub");
}

connection.start()
    .then(successToConnect)
    .catch(failureToConnect);