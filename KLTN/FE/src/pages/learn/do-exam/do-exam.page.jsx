import "./do-exam.css";
import $ from "jquery";
import { useEffect, useState } from "react";
import QuestionComponent from "../../../components/question/question.component";
import { QUESTIONTYPE } from "../../../consts/question.const";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
const LAYOUT = {
  VERTICAL: "vertical",
  HORIZONTAL: "horizontal",
};
const questionsData = [
  {
    questionType: QUESTIONTYPE.BASIC,
    title: "Hệ quản trị CSDL là:",
    description: "Hãy chọn đáp án đúng",
    answers: [
      {
        id: 0,
        content: " Phần mềm dùng tạo lập, lưu trữ và khai thác một CSDL ",
        isSelected: false,
      },
      {
        id: 1,
        content: "Phần mềm dùng tạo lập, lưu trữ một CSDL",
        isSelected: false,
      },
      {
        id: 2,
        content: "Phần mềm để thao tác và xử lý các đối tượng trong CSDL",
        isSelected: false,
      },
      {
        id: 3,
        content: "Tập hợp các dữ liệu có liên quan",
        isSelected: false,
      },
    ],
  },
  {
    questionType: QUESTIONTYPE.BASIC,
    title: "Dog là con gì",
    description: "Hãy chọn đáp án đúng",
    answers: [
      {
        id: 0,
        content: "Con chó",
        isSelected: false,
      },
      {
        id: 1,
        content: "Con mèo",
        isSelected: false,
      },
      {
        id: 2,
        content: "Con cóc",
        isSelected: false,
      },
      {
        id: 3,
        content: "Con gà",
        isSelected: false,
      },
    ],
  },
  {
    questionType: QUESTIONTYPE.BASIC,
    title: "Con gì có biệt danh là hoàng thượng",
    description: "Hãy chọn đáp án đúng",
    answers: [
      {
        id: 0,
        content: "Con chó",
        isSelected: false,
      },
      {
        id: 1,
        content: "Con mèo",
        isSelected: false,
      },
      {
        id: 2,
        content: "Con cóc",
        isSelected: false,
      },
      {
        id: 3,
        content: "Con gà",
        isSelected: false,
      },
    ],
  },
  {
    questionType: QUESTIONTYPE.BASIC,
    title: "Con gì được gọi là cậu ông trời",
    description: "Hãy chọn đáp án đúng",
    answers: [
      {
        id: 0,
        content: "Con chó",
        isSelected: false,
      },
      {
        id: 1,
        content: "Con mèo",
        isSelected: false,
      },
      {
        id: 2,
        content: "Con cóc",
        isSelected: false,
      },
      {
        id: 3,
        content: "Con gà",
        isSelected: false,
      },
    ],
  },
  {
    questionType: QUESTIONTYPE.BASIC,
    title: "Con gì được gọi là cậu ông trời",
    description: "Hãy chọn đáp án đúng",
    answers: [
      {
        id: 0,
        content: "Con chó",
        isSelected: false,
      },
      {
        id: 1,
        content: "Con mèo",
        isSelected: false,
      },
      {
        id: 2,
        content: "Con cóc",
        isSelected: false,
      },
      {
        id: 3,
        content: "Con gà",
        isSelected: false,
      },
    ],
  },
  {
    questionType: QUESTIONTYPE.BASIC,
    title: "Con gì được gọi là cậu ông trời",
    description: "Hãy chọn đáp án đúng",
    answers: [
      {
        id: 0,
        content: "Con chó",
        isSelected: false,
      },
      {
        id: 1,
        content: "Con mèo",
        isSelected: false,
      },
      {
        id: 2,
        content: "Con cóc",
        isSelected: false,
      },
      {
        id: 3,
        content: "Con gà",
        isSelected: false,
      },
    ],
  },
];
const DoExamPage = () => {
  const [questions, setQuestions] = useState(questionsData);
  const [layout, setLayout] = useState(LAYOUT.HORIZONTAL);
  const mySwal = withReactContent(Swal);
  const selectAnswer = (index, answer) => {
    const question = questions[index];
    const qAnswer = question.answers.find((x) => x === answer);
    const otherAnswers = question.answers.filter((x) => x !== answer);
    otherAnswers.forEach((ans) => {
      ans.isSelected = false;
    });
    qAnswer.isSelected = true;
    setQuestions([...questions]);
  };
  const [currentQuestion, setCurrentQuestion] = useState(questions[0]);
  const [currentIdx, setCurrentIdx] = useState(0);
  useEffect(() => {
    setCurrentQuestion(questions[currentIdx]);
  }, [currentIdx, setCurrentIdx]);
  useEffect(() => {
    $(".side-navigation").addClass("full");
    $(".main").addClass("full");
  }, []);
  const changeQuestion = (isBack = false) => {
    let index = currentIdx;
    isBack
      ? setCurrentIdx(currentIdx > 0 ? index - 1 : questions.length - 1)
      : setCurrentIdx(currentIdx < questions.length - 1 ? index + 1 : 0);
  };

  const openSubmitExamModal = () => {
    mySwal.fire({
        title:'Nộp bài?',
        icon: 'warning',
        html: 'Bạn có chắc chắn nộp bài? không thể hoàn tác',
        showConfirmButton: true,
        showCancelButton: true,
        confirmButtonText: 'Chắc chắn',
        cancelButtonText: 'Hủy'
    });
  }
  return (
    <>
      {layout === LAYOUT.VERTICAL && (
        <div className="do-exam-page-ver">
          {questions.map((question, idx) => (
            <QuestionComponent
              key={idx}
              question={question}
              index={idx + 1}
              selectAnswer={selectAnswer}
            ></QuestionComponent>
          ))}
        </div>
      )}
      {layout === LAYOUT.HORIZONTAL && (
        <div className="do-exam-page-hor">
          <QuestionComponent
            index={currentIdx + 1}
            question={currentQuestion}
            selectAnswer={selectAnswer}
          ></QuestionComponent>
          <div className="d-flex">
            <button
              onClick={() => changeQuestion(true)}
              className="btn btn-transparent"
            >
              <ion-icon
                size="large"
                name="chevron-back-circle-outline"
              ></ion-icon>
            </button>
            <button onClick={openSubmitExamModal} className="btn btn-transparent">Nộp bài</button>
            <button
              onClick={() => changeQuestion(false)}
              className="btn btn-transparent"
            >
              <ion-icon
                size="large"
                name="chevron-forward-circle-outline"
              ></ion-icon>
            </button>
          </div>
        </div>
      )}
    </>
  );
};

export default DoExamPage;
