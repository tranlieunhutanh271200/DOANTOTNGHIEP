import { useState } from "react";
import { useSelector } from "react-redux";
import './report.page.css'
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
const labels = ["January", "February", "March", "April", "May", "June", "July"];

const temp = [
    {
        name: "Nghien cuu gRPC",
        description: "Nghien cuu",
        start: "2022-06-22",
        end: "2022-07-22",
        members: [
            {
                fullname: 'Tran lieu nhut anh',
                studentId: 1811001,
                id: 'abc',
                accountId: 'abc-xyz',
                tasks: [
                    {
                        id: 1,
                        title: 'Tim hieu ve CNTT'
                    },
                    {
                        id: 2,
                        title: 'Viet bao cao'
                    }
                ]
            },
            {
                fullname: 'Nguyen huy the',
                studentId: 1811002,
                id: 'abc1',
                accountId: 'abc-xy2',
                tasks: [
                    {
                        id: 3,
                        title: ''
                    },
                    {
                        id: 4,
                        title: 'Viet bao cao'
                    }
                ]
            }
        ]
    },
    {
        name: "Nghien cuu dotnet",
        description: "Nghien cuu",
        start: "2022-06-22",
        end: "2022-07-22",
        members: [
            {
                fullname: 'Tran lieu nhut anh 1',
                studentId: 1811001,
                id: 'abc',
                accountId: 'abc-xyz',
                tasks: [
                    {
                        id: 1,
                        title: 'Tim hieu ve CNTT'
                    },
                    {
                        id: 2,
                        title: 'Viet bao cao'
                    }
                ]
            },
            {
                fullname: 'Nguyen huy the 1',
                studentId: 1811002,
                id: 'abc1',
                accountId: 'abc-xy2',
                tasks: [
                    {
                        id: 3,
                        title: 'Bao cao'
                    },
                    {
                        id: 4,
                        title: 'Viet bao cao'
                    }
                ]
            }
        ]
    },
    {
        name: "Nghien cuu gRPC 2",
        description: "Nghien cuu",
        start: "2022-06-22",
        end: "2022-07-22",
        members: [
            {
                fullname: 'Tran lieu nhut anh 2',
                studentId: 1811001,
                id: 'abc',
                accountId: 'abc-xyz',
                tasks: [
                    {
                        id: 1,
                        title: 'Tim hieu ve CNTT'
                    },
                    {
                        id: 2,
                        title: 'Viet bao cao'
                    }
                ]
            },
            {
                fullname: 'Nguyen huy the 2',
                studentId: 1811002,
                id: 'abc1',
                accountId: 'abc-xy2',
                tasks: [
                    {
                        id: 3,
                        title: 'test'
                    },
                    {
                        id: 4,
                        title: 'Viet bao cao'
                    }
                ]
            }
        ]
    }
]
const ProjectReportPage = () => {
    const { account } = useSelector(x => x.auth);
    const [projects, setProjects] = useState([...temp])
    const [selectedProject, setSelectedProject] = useState(null);
    const [selectedMember, setSelectedMember] = useState(null);
    const [selectedTask, setSelectedTask] = useState(null);

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
                {
                    type: "bar",
                    label: "Dataset 3",
                    backgroundColor: "rgb(53, 162, 235)",
                    data: labels.map(() => faker.datatype.number({ min: 1, max: 8 })),
                },
            ],
        }
    }
    const [data2,setData2] = useState(generate())
    useEffect(() => {
        setData2(generate());
    }, [selectedTask])
    return (<div className="report-project">
        
        <div className="row">
            <div className="col separate">
                <h5>Chon project</h5>
                <ul className="list-group">
                    {
                        projects.map((project, idx) =>
                            <li onClick={() => setSelectedProject(project)} key={idx} className="list-group-item local-item">
                                {project.name}
                            </li>

                        )
                    }
                </ul>
            </div>
            <div className="col">
                {selectedProject && <>
                    <h4>Chon hoc sinh</h4>
                    <ul className="list-group">
                        {selectedProject.members.map((member, idx) =>
                            <li onClick={() => setSelectedMember(member)} key={idx} className="list-group-item local-item">
                                {member.fullname}
                            </li>)}
                    </ul>
                </>}
            </div>
            <div className="col">
                {selectedMember && <>
                    <h4>Chon task</h4>
                    <ul className="list-group">
                        {selectedMember.tasks.map((task, idx) =>
                            <li onClick={() => setSelectedTask(task)} key={idx} className="list-group-item local-item">
                                {task.title}
                            </li>)}
                    </ul>
                </>}
            </div>
        </div>
        <div className="row glass-panel">

            {selectedTask && <><button className="btn btn-primary">Export</button>
                <Chart data={data2}></Chart>
            </>}
        </div>
    </div>);
}

export default ProjectReportPage;