using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TechTaskInnowise.Controllers;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models.DTOs;
using TechTaskInnowise.Models;
using Xunit;


namespace TestProject1
{
    public class ReviewsControllerTest
    {
        private readonly Mock<IReviewsRepositories> _mockReviewRepository;
        private readonly Mock<ILogger<ReviewsController>> _mockLogger;
        private readonly ReviewsController _controller;

        public ReviewsControllerTest()
        {
            _mockReviewRepository = new Mock<IReviewsRepositories>();
            _mockLogger = new Mock<ILogger<ReviewsController>>();

            _controller = new ReviewsController(_mockReviewRepository.Object,  _mockLogger.Object);
        }
        [Fact]
        public async void GetAllReviewsOk()
        {
            // Arrange
            _mockReviewRepository.Setup(repos => repos.GetListAsync()).ReturnsAsync(new List<Review>());

            // Act
            var result = await _controller.GetReviewsList();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void CreateActorOk()
        {
            // Создание макета репозитория, чтобы возвращать успешно добавленную сущность
            _mockReviewRepository.Setup(repos => repos.AddAsync(It.IsAny<Review>())).ReturnsAsync(new Review());

            var addReviewDTO = new AddReviewDTO
            {
            };

            // Act
            var result = await _controller.CreateReviewAsync(addReviewDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetActorOk()
        {
            // Создание макета репозитория, чтобы возвращать успешно найденную сущность
            _mockReviewRepository.Setup(repos => repos.GetAsync(It.IsAny<int>())).ReturnsAsync(new Review());

            // Act
            var result = await _controller.GetReview(It.IsAny<int>());

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void UpdateActorOk()
        {
            _mockReviewRepository.Setup(repos => repos.GetAsync(It.IsAny<int>())).ReturnsAsync(new Review());
            // Создание макета репозитория, чтобы успешно обновить сущность

            var updReviewDTO = new UpdReviewDTO
            {
                Title = "Title",
                Description = "Description",
                Stars = 5,
                FilmId = 1,
            };

            var result = await _controller.UpdateReviewAsync(It.IsAny<int>(), updReviewDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void DeleteActorOk()
        {
            // Создание макета репозитория, чтобы успешно удалить сущность
            _mockReviewRepository.Setup(repos => repos.GetAsync(It.IsAny<int>())).ReturnsAsync(new Review());

            var result = await _controller.DeleteReview(It.IsAny<int>());

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}