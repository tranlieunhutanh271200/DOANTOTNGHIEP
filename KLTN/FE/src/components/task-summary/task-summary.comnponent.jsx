import { useState } from 'react';
import './task-summary.css'
const data = [
    {
        id: 1,
        title: 'Tìm hiểu về Internet',
        assignee: 'Nhut Anh',
        assigneeId: 1,
        assignDate: '2022/04/30',
        endDate: '2022/05/02',
        status: 'Pending'
    },
    {
        id: 2,
        title: 'Thiết kế giao diện',
        assignee: 'Nhut Anh',
        assigneeId: 1,
        assignDate: '2022/04/30',
        endDate: '2022/05/10',
        status: 'In Process'
    },
    {
        id: 3,
        title: 'Làm backend',
        assignee: 'Nhut Anh',
        assigneeId: 1,
        assignDate: '2022/04/30',
        endDate: '2022/05/10',
        status: 'In Process'
    },
    {
        id: 4,
        title: 'Làm mobile',
        assignee: 'Nhut Anh',
        assigneeId: 1,
        assignDate: '2022/04/30',
        endDate: '2022/05/10',
        status: 'In Process'
    },
    {
        id: 5,
        title: 'Viết báo cáo',
        assignee: 'Nhut Anh',
        assigneeId: 1,
        assignDate: '2022/04/30',
        endDate: '2022/05/10',
        status: 'In Process'
    },
]
const TaskSummaryComponent = ({tasks = []}) => {
    const [dates,setDates] = useState([])
    return ( <div className='task-summary'>
        <h5>Tiến độ công việc của - {data[0].assignee}</h5>
        <table>
            <thead>
                <tr>
                    <td>Tên công việc</td>
                    <td className='d-center'>Mon</td>
                    <td className='d-center'>Tue</td>
                    <td className='d-center'>Wed</td>
                    <td className='d-center'>Thu</td>
                    <td className='d-center'>Fri</td>
                    <td className='d-center'>Sat</td>
                </tr>
            </thead>
            <tbody>
                {data.map((task,idx) => 
                <tr key={idx}>
                    <td>{task.id} {task.title}</td>
                    {
                        [...Array(6).keys()].map((day, dayIdx) => 
                        <td className='d-center' key={dayIdx}>
                            6h
                        </td>)
                    }
                </tr>)}
            </tbody>
        </table>
    </div> );
}

export default TaskSummaryComponent;