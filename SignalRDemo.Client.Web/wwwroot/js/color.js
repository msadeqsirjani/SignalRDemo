"use strict";

let btnJoinYellow = document.getElementById("btnJoinYellow");
let btnJoinBlue = document.getElementById("btnJoinBlue");
let btnJoinOrange = document.getElementById("btnJoinOrange");
let btnRemoveYellow = document.getElementById("btnRemoveYellow");
let btnRemoveBlue = document.getElementById("btnRemoveBlue");
let btnRemoveOrange = document.getElementById("btnRemoveOrange");
let btnTriggerYellow = document.getElementById("btnTriggerYellow");
let btnTriggerBlue = document.getElementById("btnTriggerBlue");
let btnTriggerOrange = document.getElementById("btnTriggerOrange");


var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/color")
    .build();

btnJoinYellow.addEventListener("click", () => { connection.invoke("JoinGroup", "Yellow"); });
btnJoinBlue.addEventListener("click", () => { connection.invoke("JoinGroup", "Blue"); });
btnJoinOrange.addEventListener("click", () => { connection.invoke("JoinGroup", "Orange"); });

btnRemoveYellow.addEventListener("click", () => { connection.invoke("RemoveGroup", "Yellow"); });
btnRemoveBlue.addEventListener("click", () => { connection.invoke("RemoveGroup", "Blue"); });
btnRemoveOrange.addEventListener("click", () => { connection.invoke("RemoveGroup", "Orange"); });

btnTriggerYellow.addEventListener("click", () => { connection.invoke("TriggerGroup", "Yellow"); });
btnTriggerBlue.addEventListener("click", () => { connection.invoke("TriggerGroup", "Blue"); });
btnTriggerOrange.addEventListener("click", () => { connection.invoke("TriggerGroup", "Orange"); });

connection.on("TriggerColor", (color) => {
    document.getElementsByTagName("body")[0].style.backgroundColor = color;
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