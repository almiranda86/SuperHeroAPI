using Moq;
using Moq.AutoMock;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.Infrastructure.Query;
using SuperHeroDomain.Model.HeroMaster;
using SuperHeroDomain.QueryModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SuperHeroApiTest.Service.Handlers
{
    public class ListAllHeroesPaginatedRequestHandler_Test
    {
        readonly AutoMocker _mocker;
        public ListAllHeroesPaginatedRequestHandler_Test()
        {
            _mocker = new AutoMocker();
        }


        [Fact]
        public async Task Handle_Success()
        {
            //Arrange
            var queryResult = _mocker.GetMock<QueryPagedResponse<Hero>>();

            var heroLookup = _mocker.GetMock<IHeroLookup>()
                                    .Setup(lookup => lookup.GetAllHeroesPaginated(It.IsAny<IPagedRequest>()))
                                    .ReturnsAsync(queryResult.Object);

            var ListAllHeroesPaginatedRequestHandler = _mocker.CreateInstance<SuperHeroService.Handlers.ListAllHeroesPaginatedRequestHandler>();

            //Act
            var response = await ListAllHeroesPaginatedRequestHandler.Handle(It.IsAny<ListAllHeroesPaginatedRequest>(), It.IsAny<CancellationToken>());


            //Assert
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.Status);

        }
    }
}
