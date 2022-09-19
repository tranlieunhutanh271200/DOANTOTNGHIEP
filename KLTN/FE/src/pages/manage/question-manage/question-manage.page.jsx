const questions =  [
    {
      answers: [
        {
          id: "8d09a116-62c3-4869-c735-08da362d87ab",
          content: "Dog",
          isCorrectAnswer: true
        },
        {
          id: "590ca998-b2ee-472d-c736-08da362d87ab",
          content: "Cat",
          isCorrectAnswer: false
        },
        {
          id: "aa3056b5-c0a4-4617-c737-08da362d87ab",
          content: "Duck",
          isCorrectAnswer: false
        }
      ],
      id: "799119e7-4ad1-4b7e-dd09-08da362d87a1",
      title: "Chọn đáp án đúng",
      content: "Con chó trong tiếng Anh là gì",
      isCountdown: false,
      textFormat: 0
    },
    {
      "answers": [
        {
          "id": "8243d4e4-a1d9-407a-c738-08da362d87ab",
          "content": "Dog",
          "isCorrectAnswer": false
        },
        {
          "id": "e57c4480-6816-41cd-c739-08da362d87ab",
          "content": "Cat",
          "isCorrectAnswer": false
        },
        {
          "id": "728fa0bf-79d5-4cd6-c73a-08da362d87ab",
          "content": "Duck",
          "isCorrectAnswer": true
        }
      ],
      "id": "105f92aa-542a-44e0-dd0a-08da362d87a1",
      "title": "Chọn đáp án đúng",
      "content": "Con vịt trong tiếng Anh là gì",
      "isCountdown": false,
      "textFormat": 0
    },
    {
      "answers": [
        {
          "id": "a7f8264b-a96d-46bf-c73b-08da362d87ab",
          "content": "Dog",
          "isCorrectAnswer": false
        },
        {
          "id": "d0204853-b5c9-402b-c73c-08da362d87ab",
          "content": "Cat",
          "isCorrectAnswer": true
        },
        {
          "id": "36eb323b-e8f2-4222-c73d-08da362d87ab",
          "content": "Duck",
          "isCorrectAnswer": false
        }
      ],
      "id": "68cb78fb-d401-464e-dd0b-08da362d87a1",
      "title": "Chọn đáp án đúng",
      "content": "Con mèo trong tiếng Anh là gì",
      "isCountdown": false,
      "textFormat": 0
    }
  ]
const QuestionManagePage = () => {
    return ( <div className="question-manage">
        This is question bank page
    </div> );
}

export default QuestionManagePage;