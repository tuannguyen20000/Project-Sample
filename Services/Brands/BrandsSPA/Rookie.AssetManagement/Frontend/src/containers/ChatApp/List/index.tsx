import React, { useEffect, useState } from "react";
import '../../../styles/chat.css';
import {HubConnectionBuilder, HubConnection} from "@microsoft/signalr";

function ChatList(){
    const [hubConnection, setHubConnection] = useState<HubConnection>();
    const [text, setText] = useState<string>("");
    const [messageList, setMessageList] = useState<Array<string>>([]);
    const username = new Date().getTime();

    useEffect(() => {
        createHubConnection();
    }, []);
    const createHubConnection = async () => {
        const connection = new HubConnectionBuilder().withUrl("https://localhost:7248/hub").build();
        try{
            await connection.start();
        }catch(err){
            console.log(err);
        }       
        setHubConnection(connection);
    };


    useEffect(() => {
        if(hubConnection){
            hubConnection.on("messageReceived", (username: string, message: string) =>{
                setMessageList((prevState) => {
                    return prevState.concat(username, message)
                })
            });

        }
    }, [hubConnection])

    const sendMessage = async () => {
        const tbMessage: HTMLInputElement = document.querySelector("#tbMessage")!;
        if(tbMessage.value.trim().length > 0) {
            if(hubConnection){   
                await hubConnection.invoke("NewMessage",username, text).then(()=>{
                    tbMessage.value = "";        
                });
            }
        }
    };
    return(
        <div>
            <div id="divMessages" className="messages">
                {messageList.map((item, index: number) => {
                        return(
                            <div key={index}>
                                <div className="message-author">${item}</div>
                            </div>
                        );
                    })}
            </div>
            <label id="lblMessage">Message:</label>
            <input id="tbMessage" onChange={(e) => {setText(e.target.value)} } className="input-zone-input" />
            <button id="btnSend" onClick={sendMessage}>Send</button>
        </div>

    );
}

export default ChatList;