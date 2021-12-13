using TeamwayPersonalityQuiz.DataAccess.Repositories.Interfaces;
using TeamwayPersonalityQuiz.Services.Interfaces;

namespace TeamwayPersonalityQuiz.Services
{
    public class ResultService : IResultService
    {
        private readonly IPersonalityRepository _personalityRepo;
        public ResultService(IPersonalityRepository repo)
        {
            _personalityRepo = repo;
        }

        public async Task<string> CheckPersonality(int score)
        {
            var personalities = await _personalityRepo.GetPersonalities().ConfigureAwait(false);

            var resultPersonality = personalities.Where(x => x.ScoreUpperBound >= score).MinBy(x => x.ScoreUpperBound);

            if (resultPersonality is null)
                throw new Exception("Score can't be larger than quiz max score, something went wrong!");

            return resultPersonality.PersonalityTrait;
        }
    }
}
