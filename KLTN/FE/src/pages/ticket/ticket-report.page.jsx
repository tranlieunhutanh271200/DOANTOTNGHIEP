import '../report/report.page.css';
import {
    Chart as ChartJS,
    ArcElement,
    LinearScale,
    CategoryScale,
    BarElement,
    PointElement,
    LineElement,
    Tooltip,
    Legend,
} from "chart.js";
import { Chart } from "react-chartjs-2";
import faker from "faker";
import { useEffect } from "react";
import { useState } from 'react';
import CalendarComponent from '../../components/calendar/calendar.component';
ChartJS.register(
    ArcElement,
    LinearScale,
    CategoryScale,
    BarElement,
    PointElement,
    LineElement,
    Tooltip,
    Legend
);
const labels = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

const TicketReportPage = () => {
    const generate = () => {
        return {
            labels,
            datasets: [
                {
                    type: "bar",
                    label: "Dataset 2",
                    backgroundColor: "rgb(75, 192, 192)",
                    data: labels.map(() => faker.datatype.number({ min: 1, max: 8 })),
                    borderColor: "white",
                    borderWidth: 2,
                },
            ],
        }
    }
    const [data, setData] = useState(generate());

    return (<div className="ticket-report">
        <div className="form-inline">
            <input type={'date'}></input>
            <input type="date" name="" id="" />
        </div>
        <div className="row glass-panel">
            {<><button className="btn btn-primary">Export</button>
                <Chart data={data}></Chart>
            </>}
        </div>
    </div>);
}

export default TicketReportPage;