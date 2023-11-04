import * as signalR from "@microsoft/signalr";
import React, { Component, useEffect, useState } from 'react';
import { useContext, createContext } from "react";
import MainPage from "../Pages/Main";

export const SignalrContext = createContext();
const transportOption = signalR.HttpTransportType.LongPolling | signalR.HttpTransportType.WebSockets;

const SignalrHub = ()=> {
useEffect ( ()=> {
const hubConnection = createSignalrConnection("chat");

},[] );

return (
  <SignalrContext.Provider  value={hubConnection}>
    <MainPage/>
  </SignalrContext.Provider>
);

};

const createSignalrConnection =(path)=> {
  try{
    const hubConnection = new signalR
      .HubConnectionBuilder()
      .withUrl("https://localhost:7095/" + path, {
        transportOption
      })
      .configureLogging(signalR.LogLevel.Information)
      .withAutomaticReconnect()
      .build();
  
      if(hubConnection != null){
        hubConnection.start()
          // .then ( ()=>{
          // hubConnection.invoke("SendMessage","Hello! It's!" + num);})
            .catch(
            (error )=> console.log(error)
          );
      };
      
    }
    catch (error){
      console.log(error);
     };
     
}
export default SignalrHub;