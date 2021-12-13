using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TeamwayPersonalityQuiz.DataAccess.Entities;
using TeamwayPersonalityQuiz.DataAccess.Repositories.Interfaces;

namespace TeamwayPersonalityQuiz.DataAccess.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApiContext _context;
        public QuestionRepository([NotNull] ApiContext context)
        {
            _context = context;
        }

        public Task<List<Question>> GetQuestions()
        {
            //Workaround for enabling inMemory db seeding through out OnModelCreating method
            _context.Database.EnsureCreated();

            return _context.Questions
                .Select(x => new Question
                {
                    Id = x.Id,
                    Text = x.Text,
                    Answers = x.Answers
                })
                .ToListAsync();
        }
    }
}
