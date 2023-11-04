import React from 'react';
import { useContext} from "react";
import { SignalrContext } from "../Components/SignalrHub";

const MainPage = () => {
  const hubConnection = useContext(SignalrContext);
  if(CheckHubExistance(hubConnection)){
    hubConnection.on("ReceiveMessage", (messageText)=>{
      let labelMessage = document.getElementById("labelMessage");
       labelMessage.innerText = "This is your message" + messageText;
    });

    hubConnection.on("ReceiveUser", (user)=>{
      let userInfo = document.getElementById("userInfo");
      userInfo.innerText = user.email;
    });
  }


  const  handleSendUserClick = ()=> {
    if(CheckHubExistance(hubConnection)){
      let email = document.getElementById("emailInput").value;
      let nickname  = document.getElementById("nicknameInput").value; 
      

      hubConnection.invoke("SendUser", {
        id:1,
        email:email,
        nickname:nickname
      });
    } 
  }
  


return (
  
 <div className="form-div">
  <label id="messageLabel"></label> <br/>
    <div>
        <label> Nickname:</label>
        <input type="text" id="nicknameInput"/>
    </div>

    <div>
        <label> Email:</label>
        <input type="email" id="emailInput"/>
    </div>
      <button onClick={handleSendUserClick}></button>
    <br/>
    <label id ="userInfo"></label>
 </div>
);

};

const CheckHubExistance = (hubConn)=>{
  return hubConn !== null && hubConn!== undefined;
}
export default MainPage;