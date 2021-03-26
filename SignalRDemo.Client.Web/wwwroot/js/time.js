"use strict";

let currentTime = document.getElementById("currentTime");

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/time")
    .build();

connection.on("UpdateCurrentTime",
    value => {
        currentTime.innerText = value;
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