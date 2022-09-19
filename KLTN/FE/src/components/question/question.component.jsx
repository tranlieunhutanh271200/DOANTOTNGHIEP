import { ALPHABET } from "../../consts/alphabet.const";
import { QUESTIONTYPE } from "../../consts/question.const";
import "./question.css";
const demoBasicQuestion = {
  questionType: QUESTIONTYPE.BASIC,
  title: "Con gì được là cậu ông trời",
  description: "Hãy chọn đáp án đúng",
  answers: [
    {
      id: 0,
      content: "Con chó",
      isSelected: false
    },
    {
      id: 1,
      content: "Con mèo",
      isSelected: false
    },
    {
      id: 2,
      content: "Con cóc",
      isSelected: false
    },
    {
      id: 3,
      content: "Con gà",
      isSelected: false
    },
  ],
};
const QuestionComponent = ({ question = demoBasicQuestion, index = 0, selectAnswer }) => {
  return (
    <div className="question">
      <div className="p-10">
        <h4>{`Câu ${index}.`}{question.description}</h4>
        <h2>{question.title}</h2>
        {question.questionType === QUESTIONTYPE.BASIC && (
          <div className="answers">
            {question.answers.map((answer, idx) => (
              <div onClick={() => selectAnswer(index - 1,answer)} key={answer.id} className={`answer ${answer.isSelected ? 'selected' : ''}`}>
                  {ALPHABET[idx].toUpperCase()}. {answer.content}
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
};

export default QuestionComponent;
