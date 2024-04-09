using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTaskInnowise.Controllers;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models;
using TechTaskInnowise.Models.DTOs;
using Xunit;


namespace TestProject1
{
    public class ActorsControllerTest
    {
        private readonly Mock<IActorRepositories> _mockActorRepository;
        private readonly Mock<IFilmsRepositories> _mockFilmRepository;
        private readonly Mock<ILogger<ActorsController>> _mockLogger;
        private readonly ActorsController _controller;

        public ActorsControllerTest()
        {
            _mockActorRepository = new Mock<IActorRepositories>();
            _mockFilmRepository = new Mock<IFilmsRepositories>();
            _mockLogger = new Mock<ILogger<ActorsController>>();

            _controller = new ActorsController(_mockActorRepository.Object, _mockFilmRepository.Object, _mockLogger.Object);
        }
        [Fact]
        public async void GetAllActorsOk()
        {
            // Arrange
            _mockActorRepository.Setup(repos => repos.GetListAsync(It.IsAny<bool>())).ReturnsAsync(new List<Actor>());

            // Act
            var result = await _controller.GetActorsList();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void CreateActorOk()
        {
            // Создание макета репозитория, чтобы возвращать успешно добавленную сущность
            _mockActorRepository.Setup(repos => repos.AddAsync(It.IsAny<Actor>())).ReturnsAsync(new Actor());

            var addActorDTO = new AddActorDTO
            {
                FirstName = "Alyx",
                LastName = "Vens",
                FilmIds = new List<int> { 1, 2, 3 }
            };

            // Act
            var result = await _controller.CreateActorAsync(addActorDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetActorOk()
        {
            // Создание макета репозитория, чтобы возвращать успешно найденную сущность
            _mockActorRepository.Setup(repos => repos.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(new Actor());

            // Act
            var result = await _controller.GetActor(It.IsAny<int>());

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void UpdateActorOk()
        {
            // Создание макета репозитория, чтобы успешно обновить сущность
            _mockActorRepository.Setup(repos => repos.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(new Actor());

            var updActorDTO = new UpdActorDTO
            {
                FirstName = "Alyx",
                LastName = "Vens",
                FilmIds = new List<int> { 1, 2, 3, 4 }
            };

            var result = await _controller.UpdateActorAsync(It.IsAny<int>(), updActorDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void DeleteActorOk()
        {
            // Создание макета репозитория, чтобы успешно удалить сущность
            _mockActorRepository.Setup(repos => repos.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(new Actor());

            var result = await _controller.DeleteActor(It.IsAny<int>());

            // Assert
            Assert.IsType<OkResult>(result);
        }


    }
}
