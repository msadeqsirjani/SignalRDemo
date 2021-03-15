"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/account")
    .build();

let btn = document.getElementById("btnGetFullName");

btn.addEventListener("click",
    function (evt) {
        const forename = (document.getElementById("inputForename")).value;
        const surname = (document.getElementById("inputSurname")).value;

        connection.invoke("JoinUser", forename, surname);
    });


connection.on("Introduce",
    function(fullname) {
        alert(fullname);
    });


function successToConnect() {
    console.log("Successfully connected to hub");
}

function failureToConnect() {
    console.log("Unfortunatlly couldn't connect to hub");
}

connection.start()
    .then(successToConnect)
    .catch(failureToConnect);