using TeamwayPersonalityQuiz.DataAccess.Entities;

namespace TeamwayPersonalityQuiz.DataAccess.Repositories.Interfaces
{
    public interface IPersonalityRepository
    {
        public Task<List<Personality>> GetPersonalities();
    }
}
