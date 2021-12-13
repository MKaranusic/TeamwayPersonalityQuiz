using TeamwayPersonalityQuiz.DataAccess.Entities;
using TeamwayPersonalityQuiz.DataAccess.Repositories.Interfaces;
using TeamwayPersonalityQuiz.Services.Interfaces;

namespace TeamwayPersonalityQuiz.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;
        public QuestionService(IQuestionRepository repo)
        {
            _questionRepo = repo;
        }

        public Task<List<Question>> GetQuestions() => _questionRepo.GetQuestions();
    }
}
