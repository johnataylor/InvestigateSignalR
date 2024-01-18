
//import { signalR } from "@microsoft/signalr";
//const signalR = require("@microsoft/signalr");

//import pkg from '@microsoft/signalr';
//const { signalR } = pkg;

import * as  signalR from '@microsoft/signalr';

const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5041/reminderhub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

connection.on('notification', (notification) => {
  console.log(`${notification.thread_id} ${notification.run_id} ${notification.status}`);
});


// Start the connection.
start();