using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamwayPersonalityQuiz.DataAccess.Entities;
using TeamwayPersonalityQuiz.DataAccess.Repositories.Interfaces;
using TeamwayPersonalityQuiz.Services;
using Xunit;

#pragma warning disable IDE0051
namespace TeamwayPersonalityQuiz.Test.Services
{
    public class ResultServiceTests
    {
        private readonly ResultService _sut;

        private const string INTROVERT = "Introvert";
        private const string EXTROVERT = "Extrovert";
        private const int MAX_SCORE = 15;

        public ResultServiceTests()
        {
            var personalityRepoMock = new Mock<IPersonalityRepository>();

            personalityRepoMock.Setup(x => x.GetPersonalities()).ReturnsAsync(new List<Personality>
            {
                new Personality { Id = 1, ScoreUpperBound = MAX_SCORE, PersonalityTrait = "Extrovert" },
                new Personality { Id = 2, ScoreUpperBound = 9, PersonalityTrait = "Introvert" }
            });

            _sut = new(personalityRepoMock.Object);
        }

        [Fact]
        private async Task CheckPersonality_ValidInput_Success()
        {
            int input = 5;

            var result = await _sut.CheckPersonality(input).ConfigureAwait(false);

            Assert.Equal(INTROVERT, result);
        }

        [Fact]
        private async Task CheckPersonality_ValidInput_Success_2()
        {
            int input = 11;

            var result = await _sut.CheckPersonality(input).ConfigureAwait(false);

            Assert.Equal(EXTROVERT, result);
        }

        [Fact]
        private async Task CheckPersonality_BorderValue_Success()
        {
            int input = 9;

            var result = await _sut.CheckPersonality(input).ConfigureAwait(false);

            Assert.Equal(INTROVERT, result);
        }

        [Fact]
        private async Task CheckPersonality_NegativeScore_Success()
        {
            int input = -1;

            var result = await _sut.CheckPersonality(input).ConfigureAwait(false);

            Assert.Equal(INTROVERT, result);
        }

        [Fact]
        private void CheckPersonality_ScoreLargerThanMaxPersonalityBound_ThrowsException()
        {
            int input = int.MaxValue;
            Assert.ThrowsAsync<Exception>(async () => await _sut.CheckPersonality(input).ConfigureAwait(false));
        }
    }
}
