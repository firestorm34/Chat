import * as signalR from "@microsoft/signalr";
import React, { Component, useEffect, useState } from 'react';
import { useContext, createContext } from "react";
import MainPage from "../Pages/Main";

export const SignalrContext = createContext();
export const SignalrContext2 = createContext();
const transportOption = signalR.HttpTransportType.LongPolling | signalR.HttpTransportType.WebSockets;

const SignalrHub = ()=> {
const [hubConnection, setHubConnection] = useState();
useEffect ( ()=> {

  try{
  const  hubConnection = new signalR
    .HubConnectionBuilder()
    .withUrl("https://localhost:7095/chat", {
      transportOption
    })
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .build();

    setHubConnection(hubConnection);
    if(hubConnection != null){
      hubConnection.start()
        // .then ( ()=>{
        // hubConnection.invoke("SendMessage","Hello! I am here!");})
          .catch(
          (error )=> console.log(error)
        );
    };
  }
   catch (error){
    console.log(error);
   }

},[] );


return (
  <SignalrContext.Provider  value={hubConnection}>
    <MainPage/>
  </SignalrContext.Provider>
);

};
export default SignalrHub;