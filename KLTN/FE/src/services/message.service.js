import {HttpTransportType, LogLevel} from '@microsoft/signalr';
import * as signalR from '@microsoft/signalr';
const messageConnection = new signalR.HubConnectionBuilder().withUrl(`${process.env.REACT_APP_BASE_SIGNALR}/messagehub`,
{
    skipNegotiation: true,
    transport: HttpTransportType.WebSockets,
    accessTokenFactory: () => localStorage.getItem('token')
})
.build();
export default messageConnection;