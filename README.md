# quizzy

Quizzy is a web application being developed using Microservices architecture.

# Services:

## Question microservice: service to manage questions
  - Swagger : https://localhost:44321/swagger/index.html
  - Sample POST : https://localhost:44321/api/Question
    {
        "questionId": "b27c7e0c-4c13-4743-8925-f5c0e8d081c1",
        "description": "Sun rises in ",
        "options": [
            "North", "East", "West", "South"
        ],
        "answer": "East",
        "tag": "General"
    }

  - Sample GET: https://localhost:44321/api/Question/b27c7e0c-4c13-4743-8925-f5c0e8d081c1
