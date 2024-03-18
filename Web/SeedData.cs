using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            QuizItem m1= new QuizItem (1, "3+1", new List<string> { "3", "1", "5", "7", "2" }, "4");
            QuizItem m2 = new QuizItem(2, "2*7", new List<string> { "11", "21", "43", "54", "32" }, "14");
            QuizItem m3 = new QuizItem(3, "10-7", new List<string> { "2", "1", "5", "7", "9" }, "3");
            QuizItem m4 = new QuizItem(4, "16/4", new List<string> { "3", "1", "5", "7", "2" }, "4");

            QuizItem g1 = new QuizItem(1, "Gdzie leży Kanada?", new List<string> { "Ameryka Płd", "Europa", "Azja", "Afryka", "Australia" }, "Ameryka Płn");
            QuizItem g2 = new QuizItem(2, "Gdzie leży Wietnam?", new List<string> { "Europa", "Ameryka Płd", "Afryka", "Ameryka Płn", "Australia" }, "Azja");
            QuizItem g3 = new QuizItem(3, "Gdzie leży Libia?", new List<string> { "Ameryka Płn", "Europa", "Australia", "Azja", "Ameryka Płd" }, "Afryka");

            Quiz matematyka = new Quiz(1,new List<QuizItem>(){m1,m2,m3,m4},"Matematyka");
            Quiz geografia = new Quiz(2, new List<QuizItem>() { g1, g2, g3}, "Geografia");
        }
    }
}