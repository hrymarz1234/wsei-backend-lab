using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using WebApIa.DTO;

namespace WebApIa.Controllers
{
    [Route("api/admin")]
    [ApiController]                      
    public class AdminController : Controller
    {
        private readonly IQuizAdminService _adminservice;
        public AdminController(IQuizAdminService adminService)
        {
            _adminservice = adminService;
        }
        //////////////////////////////////////TO DO //////////////////////////////////////////////////////////////
        [HttpPost("quizzes")]
        public ActionResult<QuizDto> AddQuiz([FromBody] NewQuizDto newQuizDto)
        {
            var quiz = _adminService.AddQuiz(newQuizDto.Title);
            if (quiz == null)
            {
                return BadRequest("Failed to add quiz."); // Jeśli nie udało się dodać quizu, zwracamy kod błędu 400
            }

            var quizDto = new QuizDto
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Items = new List<QuizItemDto>() // Inicjalizujemy listę pytań
            };

            return CreatedAtAction(nameof(GetQuiz), new { id = quizDto.Id }, quizDto); // Zwracamy kod stanu 201 (Created) oraz ścieżkę dostępu do utworzonego zasobu
        }

        // Usuwanie quizu o podanym ID
        [HttpDelete("quizzes/{id}")]
        public IActionResult DeleteQuiz(int id)
        {
            if (!_adminService.DeleteQuiz(id))
            {
                return NotFound(); // Jeśli nie znaleziono quizu, zwracamy kod błędu 404
            }

            return NoContent(); // Zwracamy kod stanu 204 (No Content) jeśli usunięto quiz pomyślnie
        }

        // Pobieranie quizu o podanym ID
        [HttpGet("quizzes/{id}")]
        public ActionResult<QuizDto> GetQuiz(int id)
        {
            var quiz = _adminService.GetQuiz(id);
            if (quiz == null)
            {
                return NotFound(); // Jeśli nie znaleziono quizu, zwracamy kod błędu 404
            }

            var quizDto = new QuizDto
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Items = quiz.Items.Select(item => new QuizItemDto // Mapowanie pytań na DTO
                {
                    Id = item.Id,
                    Question = item.Question,
                    Options = item.Options,
                    CorrectAnswer = item.CorrectAnswer
                }).ToList()
            };

            return quizDto; // Zwracamy quiz jako ciało odpowiedzi
        }

        // Dodawanie nowego pytania do quizu o podanym ID
        [HttpPost("quizzes/{quizId}/items")]
        public ActionResult<QuizItemDto> AddQuestion(int quizId, [FromBody] NewQuestionDto newQuestionDto)
        {
            var quizItem = _adminservice.AddQuestion(quizId, newQuestionDto.Question, newQuestionDto.Options, newQuestionDto.CorrectAnswer);
            if (quizItem == null)
            {
                return BadRequest("Failed to add question."); // Jeśli nie udało się dodać pytania, zwracamy kod błędu 400
            }

            var quizItemDto = new QuizItemDto
            {
                Id = quizItem.Id,
                Question = quizItem.Question,
                Options = quizItem.Options,
                CorrectAnswer = quizItem.CorrectAnswer
            };

            return CreatedAtAction(nameof(GetQuestion), new { quizId = quizId, itemId = quizItemDto.Id }, quizItemDto); // Zwracamy kod stanu 201 (Created) oraz ścieżkę dostępu do utworzonego zasobu
        }

        // Usuwanie pytania o podanym ID z quizu o podanym ID
        [HttpDelete("quizzes/{quizId}/items/{itemId}")]
        public IActionResult DeleteQuestion(int quizId, int itemId)
        {
            if (!_adminService.DeleteQuestion(quizId, itemId))
            {
                return NotFound(); // Jeśli nie znaleziono pytania lub quizu, zwracamy kod błędu 404
            }

            return NoContent(); // Zwracamy kod stanu 204 (No Content) jeśli usunięto pytanie pomyślnie
        }
    }
}
    }
}
