"use strict";

let btnGetOne = document.getElementById("btnGetOne");
let btnGetTen = document.getElementById("btnGetTen");
let btnGetOneThousand = document.getElementById("btnGetOneThousand");
let userJson = document.getElementById("userJson");

function receiveUsers(users) {
    userJson.value = JSON.stringify(users, null, 2);
}
function clear() {
    userJson.value = "Loading...";
}

btnGetOne.addEventListener("click", () => { clear(); connection.invoke("GetUsers", 1).then(receiveUsers); });
btnGetTen.addEventListener("click", () => { clear(); connection.invoke("GetUsers", 10).then(receiveUsers); });
btnGetOneThousand.addEventListener("click", () => { clear(); connection.invoke("GetUsers", 1000).then(receiveUsers); });

var connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Trace)
    .withUrl("/hubs/user")
    .build();

function successToConnect() {
    console.log("Successfully connected to hub");
}

function failureToConnect() {
    console.log("Unfortunately couldn't connect to hub");
}

connection.start()
    .then(successToConnect)
    .catch(failureToConnect);