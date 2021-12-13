namespace TeamwayPersonalityQuiz.Services.Interfaces
{
    public interface IResultService
    {
        Task<string> CheckPersonality(int score);
    }
}
