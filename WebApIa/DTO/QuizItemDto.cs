using BackendLab01;

namespace WebApIa.DTO
{
    public class QuizItemDto
    {
        public int Id { get; set; }
        public string Question{ get; set; }
        public List<string> Options { get;}
        public static QuizItemDto of(QuizItem quiz)
        {
            QuizItemDto qidto = new QuizItemDto();
            qidto.Id = quiz.Id;
            qidto.Question = quiz.Question;
            qidto.Options.Add(quiz.CorrectAnswer);
            qidto.Options.AddRange(quiz.IncorrectAnswers);
            return qidto;

            
        }   
    }
}
