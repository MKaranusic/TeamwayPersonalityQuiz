using TeamwayPersonalityQuiz.DataAccess.Entities;

namespace TeamwayPersonalityQuiz.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<AnswerDTO> Answers { get; set; }

        internal static Func<Question, QuestionDTO> Select = x
            => new()
            {
                Id = x.Id,
                Text = x.Text,
                Answers = x.Answers.Select(AnswerDTO.Select),
            };
    }
}
