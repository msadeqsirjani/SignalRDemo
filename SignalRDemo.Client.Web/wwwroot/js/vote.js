"use strict";

let pieVotes = document.getElementById("pieVotes");
let baconVotes = document.getElementById("baconVotes");

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/vote")
    .build();

connection.on("UpdateVotes", (votes) => {
    pieVotes.innerText = votes.pie;
    baconVotes.innerText = votes.bacon;
});

function successToConnect() {
    console.log("Successfully connected to hub");

    connection.invoke("GetCurrentVotes").then((votes) => {
        pieVotes.innerText = votes.pie;
        baconVotes.innerText = votes.bacon;
    });
}

function failureToConnect() {
    console.log("Unfortunately couldn't connect to hub");
}

connection.start()
    .then(successToConnect)
    .catch(failureToConnect);