import { HubConnectionBuilder } from "@microsoft/signalr";
import { useEffect } from "react";

export const useSignalR = () => {
    const url = "http://localhost:5001/airport";
    const conection = new HubConnectionBuilder().withUrl(url).build();

    conection.on("ReceiveStation", (text: string) => {
        const data = JSON.parse(text);
        console.log(data);
    });

    useEffect(() => {
        conection.stop().then(() => {
            conection.start().then(() => {
                console.log("SignalR conected successfully")

            })
        });

        return () => {
            conection.stop().then(() => console.log("SignalR Disconnected"))
        }
    }, []);

    const start = () => {
        conection.invoke("Start", "hloo from react")
        // fetch("http://localhost:5001/api/Airport/StartTimer").then((res) => {
        //     res.text().then((data) => { console.log(data) });
        // })
    };


    return {
        start,
    }
}