using TeamwayPersonalityQuiz.DataAccess.Entities;

namespace TeamwayPersonalityQuiz.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<List<Question>> GetQuestions();
    }
}
