using Microsoft.EntityFrameworkCore;
using TeamwayPersonalityQuiz.DataAccess.Entities;

namespace TeamwayPersonalityQuiz.DataAccess
{
    public class ApiContext : DbContext
    {
        private const int MAX_SCORE = 15;

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Personality> Personalities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var personalities = new List<Personality> {
                new Personality { Id = 1, ScoreUpperBound = MAX_SCORE, PersonalityTrait = "Extrovert" },
                new Personality { Id = 2, ScoreUpperBound = 9, PersonalityTrait = "Introvert" }
            };

            var questions = new List<Question> {
                new Question { Id = 1, Text = "To prepare for a night out..." },
                new Question { Id = 2, Text = "Being around people makes me feel..." },
                new Question { Id = 3, Text = "When given a choice between working as part of a team or working as a group, I would prefer to..." },
                new Question { Id = 4, Text = "What's your idea of the perfect date?" },
                new Question { Id = 5, Text = "During parties or social gatherings, I tend to..." },
            };

            var answers = new List<Answer>
            {
                new Answer { Id = 1, Text = "I buy the latest outfit, tell my friends, then dance the night away.", Score = 3, QuestionId = 1 },
                new Answer { Id = 2, Text = "Call a few of my closest friends to see if they will be there.", Score = 2, QuestionId = 1 },
                new Answer { Id = 3, Text = "Prepare? My friends have to drag me out most nights.", Score = 1, QuestionId = 1 },

                new Answer { Id = 4, Text = "Like I'm alive!", Score = 3, QuestionId = 2 },
                new Answer { Id = 5, Text = "Inspired. I feed off of others' energy but there are times when I'd rather be alone.", Score = 2, QuestionId = 2 },
                new Answer { Id = 6, Text = "A bit exhausted. Being around others can be draining.", Score = 1, QuestionId = 2 },

                new Answer { Id = 7, Text = "Work with as many people as possible.", Score = 3, QuestionId = 3 },
                new Answer { Id = 8, Text = "Work as part of a small group.", Score = 2, QuestionId = 3 },
                new Answer { Id = 9, Text = "Work by myself.", Score = 1, QuestionId = 3 },

                new Answer { Id = 10, Text = "A live concert in Central Park.", Score = 3, QuestionId = 4 },
                new Answer { Id = 11, Text = "Dinner and a Broadway show.", Score = 2, QuestionId = 4 },
                new Answer { Id = 12, Text = "Wine and Netflix.", Score = 1, QuestionId = 4 },

                new Answer { Id = 13, Text = "Talk to as many people as I can. I've been called a social butterfly.", Score = 3, QuestionId = 5 },
                new Answer { Id = 14, Text = "Spend time with a few people that I know. It's about quality not quanitity.", Score = 2, QuestionId = 5 },
                new Answer { Id = 15, Text = "Keep to myself. You can find me by the punch bowl.", Score = 1, QuestionId = 5 },
            };

            builder.Entity<Answer>().HasData(answers);
            builder.Entity<Question>().HasData(questions);
            builder.Entity<Personality>().HasData(personalities);
        }
    }
}
