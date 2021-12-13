using TeamwayPersonalityQuiz.DataAccess.Entities;

namespace TeamwayPersonalityQuiz.DataAccess.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        public Task<List<Question>> GetQuestions();
    }
}
