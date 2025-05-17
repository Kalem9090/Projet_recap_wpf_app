using System;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Services;
using Moq;
using Xunit;

namespace IdeaManager.Tests.Services
{
    public class IdeaServiceTests
    {
        [Fact]
        public async Task SubmitIdeaAsync_TitreVide_LèveException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new IdeaService(unitOfWorkMock.Object);

            var idee = new Idea { Title = "", Description = "Description" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.SubmitIdeaAsync(idee));
        }

        [Fact]
        public async Task SubmitIdeaAsync_IdeeValide_AppelleAddEtSave()
        {
            // Arrange
            var ideaRepoMock = new Mock<IRepository<Idea>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.IdeaRepository).Returns(ideaRepoMock.Object);

            var service = new IdeaService(unitOfWorkMock.Object);
            var idee = new Idea { Title = "Mon idée", Description = "Une description" };

            // Act
            await service.SubmitIdeaAsync(idee);

            // Assert
            ideaRepoMock.Verify(r => r.AddAsync(It.IsAny<Idea>()), Times.Once);
            unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }
    }
}
