using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTaskInnowise.Controllers;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models.DTOs;
using TechTaskInnowise.Models;
using Xunit;

namespace TestProject1
{
    public class FilmsControllerTest
    {
        private readonly Mock<IActorRepositories> _mockActorRepository;
        private readonly Mock<IFilmsRepositories> _mockFilmRepository;
        private readonly Mock<ILogger<FilmsController>> _mockLogger;
        private readonly FilmsController _controller;

        public FilmsControllerTest()
        {
            _mockActorRepository = new Mock<IActorRepositories>();
            _mockFilmRepository = new Mock<IFilmsRepositories>();
            _mockLogger = new Mock<ILogger<FilmsController>>();

            _controller = new FilmsController(_mockActorRepository.Object, _mockFilmRepository.Object, _mockLogger.Object);
        }
        [Fact]
        public async void GetAllFilmssOk()
        {
            // Arrange
            _mockFilmRepository.Setup(repos => repos.GetListAsync(It.IsAny<bool>())).ReturnsAsync(new List<Film>());

            // Act
            var result = await _controller.GetFilmsList();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void CreateFilmOk()
        {
            // Создание макета репозитория, чтобы возвращать успешно добавленную сущность
            _mockFilmRepository.Setup(repos => repos.AddAsync(It.IsAny<Film>())).ReturnsAsync(new Film());

            var addFilmDTO = new AddFilmDTO
            {
                Title = "Alyx",
                Year = 2000,
                ActorIds = new List<int> { 1, 2, 3 }
            };

            // Act
            var result = await _controller.CreateFilmAsync(addFilmDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetFilmOk()
        {
            // Создание макета репозитория, чтобы возвращать успешно найденную сущность
            _mockFilmRepository.Setup(repos => repos.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(new Film());

            // Act
            var result = await _controller.GetFilm(It.IsAny<int>());

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void UpdateFilmOk()
        {
            _mockFilmRepository.Setup(repos => repos.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(new Film());
            // Создание макета репозитория, чтобы успешно обновить сущность

            var updFilmDTO = new UpdFilmDTO
            {
                Title = "Alyx",
                Year = 2010,
                ActorIds = new List<int> { 1, 2, 3,4 }
            };

            var result = await _controller.UpdateFilmAsync(It.IsAny<int>(), updFilmDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void DeleteFilmOk()
        {
            // Создание макета репозитория, чтобы успешно удалить сущность
            _mockFilmRepository.Setup(repos => repos.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(new Film());

            var result = await _controller.DeleteFilm(It.IsAny<int>());

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
