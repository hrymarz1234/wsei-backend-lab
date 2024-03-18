using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01;

public class Summary : PageModel
{
    private readonly IQuizUserService _userService;

    public Summary(IQuizUserService userService)
    {
        _userService = userService;
    }
    [BindProperty]
    public Quiz Quiz { get; set; }

    [BindProperty]
    public int CorrectAnswers { get; set; }

    public void OnGet(int quizId, int correctAnswers)
    {
        Quiz = _userService.FindQuizById(quizId);
        CorrectAnswers = correctAnswers;
    }
}