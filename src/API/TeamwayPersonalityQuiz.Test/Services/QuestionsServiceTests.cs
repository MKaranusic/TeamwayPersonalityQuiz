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
    public class QuestionsServiceTests
    {
        private readonly QuestionService _sut;
        private readonly Mock<IQuestionRepository> _mockQuestionRepository;
        private readonly List<Question> _mockQuestions;

        public QuestionsServiceTests()
        {
            _mockQuestions = new List<Question>
            {
                new Question { Id = 1,Text ="test 1", Answers = new List<Answer>()},
                new Question { Id = 2,Text ="test 2", Answers = new List<Answer>()},
                new Question { Id = 3,Text ="test 3", Answers = new List<Answer>()},
            };

            _mockQuestionRepository = new Mock<IQuestionRepository>();

            _mockQuestionRepository.Setup(x => x.GetQuestions()).ReturnsAsync(_mockQuestions);

            _sut = new(_mockQuestionRepository.Object);
        }

        [Fact]
        private async Task GetQuestions_VerifyCall_Success()
        {
            var result = await _sut.GetQuestions().ConfigureAwait(false);

            var expected = _mockQuestions.Count;

            _mockQuestionRepository.Verify(x => x.GetQuestions(), Times.Once);
            Assert.Equal(expected, result.Count);
        }

        [Fact]
        private void GetQuestions_DbEmpty_ThrowsException()
        {
            _mockQuestionRepository.Setup(x => x.GetQuestions()).ReturnsAsync(new List<Question>());
            Assert.ThrowsAsync<Exception>(async () => await _sut.GetQuestions().ConfigureAwait(false));
        }
    }
}
