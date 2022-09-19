import {HttpTransportType, LogLevel} from '@microsoft/signalr';
import * as signalR from '@microsoft/signalr';
const connection = new signalR.HubConnectionBuilder()
    .withUrl(`${process.env.REACT_APP_BASE_SIGNALR}/rtchub`,
    {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
        accessTokenFactory: () => localStorage.getItem('token')
    })
    .build();
export default connection;
