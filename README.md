# quizzy

Quizzy is a web application being developed using Microservices architecture.

## Services:

# Question microservice: service to manage questions
  - Swagger : https://localhost:44321/swagger/index.html
  - Sample POST : https://localhost:44321/api/Question
    {
        "questionId": "<guid>",
        "description": "Sun rises in ",
        "options": [
            "North", "East", "West", "South"
        ],
        "answer": "East",
        "tag": "General"
    }

  - Sample GET: https://localhost:44321/api/Question/<guid>
