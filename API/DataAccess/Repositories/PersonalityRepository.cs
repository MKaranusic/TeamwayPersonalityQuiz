using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TeamwayPersonalityQuiz.DataAccess.Entities;
using TeamwayPersonalityQuiz.DataAccess.Repositories.Interfaces;

namespace TeamwayPersonalityQuiz.DataAccess.Repositories
{
    public class PersonalityRepository : IPersonalityRepository
    {
        private readonly ApiContext _context;
        public PersonalityRepository([NotNull] ApiContext context)
        {
            _context = context;
        }

        public Task<List<Personality>> GetPersonalities()
        {
            //Workaround for enabling inMemory db seeding through out OnModelCreating method
            _context.Database.EnsureCreated();

            return _context.Personalities.ToListAsync();
        }
    }
}
