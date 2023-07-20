using Foodie.Meals.Application.Functions.Cities.Commands.CreateCity;
using Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity;
using Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCities;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCityById;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.UnitTests.Mocks.Mediators
{
    public class MockMediatorForCities : Mock<IMediator>
    {
        public MockMediatorForCities MockSendingCreateCityCommand()
        {
            //Setup(m => m.Send(It.IsAny<CreateCityCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((CreateCityCommand createCityCommand, CancellationToken cancellationToken) =>
            //{
            //    return new CreateCityCommandResponse
            //    {
            //        Id = 1,
            //        Name = createCityCommand.Name,
            //        Country = createCityCommand.Country
            //    };
            //});

            return this;
        }

        public MockMediatorForCities VerifySendingCreateCityCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<CreateCityCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForCities MockSendingUpdateCityCommand()
        {
            //Setup(m => m.Send(It.IsAny<UpdateCityCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((UpdateCityCommand updateCityCommand, CancellationToken cancellationToken) =>
            //{
            //    return new UpdateCityCommandResponse
            //    {
            //        Id = updateCityCommand.Id,
            //        Name = updateCityCommand.Name,
            //        Country = updateCityCommand.Country
            //    };
            //});

            return this;
        }

        public MockMediatorForCities VerifySendingUpdateCityCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<UpdateCityCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForCities MockSendingDeleteCityCommand()
        {
            Setup(m => m.Send(It.IsAny<DeleteCityCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((DeleteCityCommand deleteCityCommand, CancellationToken cancellationToken) =>
            {
                return new DeleteCityCommandResponse
                {
                    Id = deleteCityCommand.Id,
                };
            });

            return this;
        }

        public MockMediatorForCities VerifySendingDeleteCityCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<DeleteCityCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForCities MockSendingGetCityByIdQuery()
        {
            //Setup(m => m.Send(It.IsAny<GetCityByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetCityByIdQuery getCityByIdQuery, CancellationToken cancellationToken) =>
            //{
            //    return new GetCityByIdQueryResponse
            //    {
            //        Id = getCityByIdQuery.Id,
            //        Name = "Test category",
            //        Country = "Test country"
            //    };
            //});

            return this;
        }

        public MockMediatorForCities VerifySendingGetCityByIdQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetCityByIdQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForCities MockSendingGetCitiesQuery()
        {
            //Setup(m => m.Send(It.IsAny<GetCitiesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetCitiesQuery getCitiesQuery, CancellationToken cancellationToken) =>
            //{
            //    return new GetCitiesQueryResponse
            //    {
            //        Name = getCitiesQuery.Name,
            //        Country = getCitiesQuery.Country,
            //        PageSize = getCitiesQuery.PageSize,
            //        CurrentPage = getCitiesQuery.PageNumber,
            //        TotalPages = 2,
            //        Cities = new List<CityDto>
            //        {
            //            new CityDto
            //            {
            //                Id = 1,
            //                Name = "Test city 1",
            //                Country = "Test country"
            //            },
            //            new CityDto
            //            {
            //                Id = 2,
            //                Name = "Test city 2",
            //                Country = "Test country"
            //            },
            //            new CityDto
            //            {
            //                Id = 3,
            //                Name = "Test city 3",
            //                Country = "Test country"
            //            }
            //        }
            //    };
            //});

            return this;
        }

        public MockMediatorForCities VerifySendingGetCitiesQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetCitiesQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }
    }
}
