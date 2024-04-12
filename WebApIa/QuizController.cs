using BackendLab01;
using Microsoft.AspNetCore.Components;

namespace WebApIa
{
    [Route("/api/v1/quizzes")]
    public class QuizController
    {
        public readonly IQuizUserService _service;
        public QuizController(IQuizUserService service)
        {
            _service = service;
        }
    }
}
