import { useCallback, useEffect, useState } from "react";
import { Draggable } from "react-beautiful-dnd";
import { Droppable } from "react-beautiful-dnd";
import { DragDropContext } from "react-beautiful-dnd";
import Moment from "react-moment";
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";

import "./jira.css";
import axiosClient from "../../global/axios/axiosClient";
import { useSelector } from "react-redux";
function JiraPage() {
  const data = [
    {
      id: "7a311221-4bd3-47cc-662a-08da367bbf1a",
      taskName: "Research",
      description: "test task",
      projectId: "a0aa8732-24cf-4000-abb5-08da3ca2566e",
      projectName: "Nghiên cứu ngành CNTT",
      assigneeId: "b36c2a83-aabd-40c3-6b72-08da3503ce41",
      assignee: null,
      status: "TODO",
      startAt: "2022-05-15T14:03:34.485",
      dueTo: "2022-05-15T14:03:34.485",
      totalSpent: 0,
    },
  ];
  const [tasks, setTasks] = useState([]);
  const { account } = useSelector((x) => x.auth);
  const [projects, setProjects] = useState([]);
  const [currentProject, setCurentProject] = useState(null);
  const [todo, setTodo] = useState([]);
  const [process, setProcess] = useState([]);
  const [done, setDone] = useState([]);
  const [isOpen, setIsOpen] = useState(false);
  const toggleModal = () => setIsOpen(!isOpen);
  const [isReload, setIsReload] = useState(false);
  useEffect(() => {
    const fetchData = async () => {
      const getTasks = axiosClient.get(`/api/CRM/task?accountId=${account.id}`);
      const getProjects = axiosClient.get(
        `/api/CRM/project?accountId=${account.id}`
      );
      var result = await getTasks;
      var result2 = await getProjects;
      setTasks([
        ...result.map((item, idx) => {
          return {
            ...item,
            index: idx,
          };
        }),
      ]);
      setProjects(result2);
    };
    fetchData();
  }, [isReload]);
  console.log(tasks);
  useEffect(() => {
    if (currentProject) {
      setTasks(
        currentProject.tasks.map((item, idx) => {
          return {
            ...item,
            index: idx,
          };
        })
      );
    }
  }, [currentProject]);
  const onDragStart = () => {
    /*...*/
  };
  const onDragUpdate = () => {
    /*...*/
  };
  const onDragEnd = async (result) => {
    if (result.source) {
      if (result.source.droppableId) {
        console.log(tasks);
        var item = tasks.find((x) => x.index === result.source.index);
        if (result.destination) {
          item.status = result.destination.droppableId;

          var result2 = await axiosClient.put(`/api/CRM/task/${item.id}`, item);
          if(result2.status === 200){
            var proj = projects.find(x => x.id === item.projectId);
            proj.tasks = [...tasks];
            setProjects([...projects]);
            setTasks([...tasks]);
          }
        }
      }
    }
  };

  const submit = () => {};

  useEffect(() => {
    setTodo([...tasks.filter((x) => x.status === "TODO")]);
    setProcess([...tasks.filter((x) => x.status === "PROCESS")]);
    setDone([...tasks.filter((x) => x.status === "DONE")]);
  }, [tasks, setTasks]);
  return (
    <>
      <h2 className="text-center">AGILE BOARD</h2>
      <button className="btn btn-primary" onClick={toggleModal}>
        Chọn project
      </button>
      <div className="jira-page">
        <DragDropContext onDragEnd={onDragEnd}>
          <div className="column">
            <h2>To do</h2>
            <Droppable
              css={{ width: "100%", height: "100%" }}
              droppableId="TODO"
            >
              {(dropProvided) => (
                <ul
                  className="drag-zone todo"
                  {...dropProvided.droppableProps}
                  ref={dropProvided.innerRef}
                >
                  {todo.map((subject, idx) => (
                    <Draggable
                      key={subject.id}
                      draggableId={subject.index.toString()}
                      index={subject.index}
                    >
                      {(provided) => (
                        <li
                          className="noselect task"
                          ref={provided.innerRef}
                          {...provided.draggableProps}
                          {...provided.dragHandleProps}
                        >
                          <div className="task-item">
                            <h3>Project: {subject.projectName}</h3>

                            <div className="task-body">
                              <h4>Tên task: {subject.taskName}</h4>
                              <p>{subject.description}</p>
                              <b>
                                Ngày bắt đầu:{" "}
                                <Moment format="DD/MM/YYYY">
                                  {subject.startAt}
                                </Moment>
                              </b>
                              <br></br>
                              <b>
                                Ngày kết thúc:{" "}
                                <Moment format="DD/MM/YYYY">
                                  {subject.dueTo}
                                </Moment>
                              </b>
                            </div>
                          </div>
                        </li>
                      )}
                    </Draggable>
                  ))}
                </ul>
              )}
            </Droppable>
          </div>
          <div className="column">
            <h2>In Process</h2>
            <Droppable
              css={{ width: "100%", height: "100%" }}
              droppableId="PROCESS"
            >
              {(dropProvided) => (
                <ul
                  className="drag-zone process"
                  {...dropProvided.droppableProps}
                  ref={dropProvided.innerRef}
                >
                  {process.map((subject, idx) => (
                    <Draggable
                      key={subject.id}
                      draggableId={subject.index.toString()}
                      index={subject.index}
                    >
                      {(provided) => (
                        <li
                          className="noselect"
                          ref={provided.innerRef}
                          {...provided.draggableProps}
                          {...provided.dragHandleProps}
                        >
                          <div className="task-item">
                            <h3>Project: {subject.projectName}</h3>

                            <div className="task-body">
                              <h4>Tên task: {subject.taskName}</h4>
                              <p>{subject.description}</p>
                              <b>
                                Ngày bắt đầu:{" "}
                                <Moment format="DD/MM/YYYY">
                                  {subject.startAt}
                                </Moment>
                              </b>
                              <br></br>
                              <b>
                                Ngày kết thúc:{" "}
                                <Moment format="DD/MM/YYYY">
                                  {subject.dueTo}
                                </Moment>
                              </b>
                            </div>
                          </div>
                        </li>
                      )}
                    </Draggable>
                  ))}
                </ul>
              )}
            </Droppable>
          </div>
          <div className="column">
            <h2>Done</h2>
            <Droppable
              css={{ width: "100%", height: "100%" }}
              droppableId="DONE"
            >
              {(dropProvided) => (
                <ul
                  className="drag-zone done"
                  {...dropProvided.droppableProps}
                  ref={dropProvided.innerRef}
                >
                  {done.map((subject, idx) => (
                    <Draggable
                      key={subject.id}
                      draggableId={subject.index.toString()}
                      index={subject.index}
                    >
                      {(provided) => (
                        <li
                          className="noselect"
                          ref={provided.innerRef}
                          {...provided.draggableProps}
                          {...provided.dragHandleProps}
                        >
                          <div className="task-item">
                            <h3>Project: {subject.projectName}</h3>

                            <div className="task-body">
                              <h4>Tên task: {subject.taskName}</h4>
                              <p>{subject.description}</p>
                              <b>
                                Ngày bắt đầu:{" "}
                                <Moment format="DD/MM/YYYY">
                                  {subject.startAt}
                                </Moment>
                              </b>
                              <br></br>
                              <b>
                                Ngày kết thúc:{" "}
                                <Moment format="DD/MM/YYYY">
                                  {subject.dueTo}
                                </Moment>
                              </b>
                            </div>
                          </div>
                        </li>
                      )}
                    </Draggable>
                  ))}
                </ul>
              )}
            </Droppable>
          </div>
        </DragDropContext>
      </div>
      <ModalTransition>
        {isOpen && (
          <Modal onClose={toggleModal}>
            <ModalHeader>
              <ModalTitle>Chọn project</ModalTitle>
            </ModalHeader>
            <ModalBody>
              <div className="form-group">
                <ul>
                  {projects.map((proj, idx) => (
                    <li
                      className={`project ${
                        currentProject === proj ? "selected" : ""
                      }`}
                      onClick={() => setCurentProject(proj)}
                      key={idx}
                    >
                      {proj.name}

                      {proj.detail}
                    </li>
                  ))}
                </ul>
              </div>
            </ModalBody>
            <ModalFooter></ModalFooter>
          </Modal>
        )}
      </ModalTransition>
    </>
  );
}

export default JiraPage;
