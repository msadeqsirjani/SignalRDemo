"use strict";

var body = document.getElementsByTagName("body")[0];
var btnRed = document.getElementById("btnRed");
var btnGreen = document.getElementById("btnGreen");
var btnBlue = document.getElementById("btnBlue");

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/background")
    .build();

connection.on("ChangeBackgroundColor", function (color) {
    body.style.backgroundColor = color;
});

function onRed(){
    connection.invoke("NotifyChangingBackgroundColor", "red");
}

function onGreen(){
    connection.invoke("NotifyChangingBackgroundColor", "green");
}

function onBlue(){
    connection.invoke("NotifyChangingBackgroundColor", "blue");
}

btnRed.onclick = onRed;
btnGreen.onclick = onGreen;
btnBlue.onclick = onBlue;

function successToConnect() {
    console.log("Successfully connected to hub");
}

function failureToConnect() {
    console.log("Unfortunately couldn't connect to hub");
}

connection.start()
    .then(successToConnect)
    .catch(failureToConnect);