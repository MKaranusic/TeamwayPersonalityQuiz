using TeamwayPersonalityQuiz.DataAccess.Entities;

namespace TeamwayPersonalityQuiz.DTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }

        internal static Func<Answer, AnswerDTO> Select = x
            => new()
            {
                Id = x.Id,
                Text = x.Text,
                Score = x.Score
            };
    }
}
