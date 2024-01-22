using Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocations;
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
    public class MockMediatorForLocations : Mock<IMediator>
    {
        public MockMediatorForLocations MockSendingCreateLocationCommand()
        {
            //Setup(m => m.Send(It.IsAny<CreateLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((CreateLocationCommand createLocationCommand, CancellationToken cancellationToken) =>
            //{
            //    return new CreateLocationCommandResponse
            //    {
            //        Id = 1,
            //        Address = createLocationCommand.Address,
            //        Email = createLocationCommand.Email,
            //        PhoneNumber = createLocationCommand.PhoneNumber,
            //        CityId = createLocationCommand.CityId,
            //        RestaurantId = createLocationCommand.RestaurantId,
            //        CityName = "Test city",
            //        RestaurantName = "Test restaurant"
            //    };
            //});

            return this;
        }

        public MockMediatorForLocations VerifySendingCreateLocationCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<CreateLocationCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForLocations MockSendingUpdateLocationCommand()
        {
            Setup(m => m.Send(It.IsAny<UpdateLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((UpdateLocationCommand updateLocationCommand, CancellationToken cancellationToken) =>
            {
                return new UpdateLocationCommandResponse
                {
                    Id = updateLocationCommand.Id,
                    Address = updateLocationCommand.Address,
                    Email = updateLocationCommand.PhoneNumber,
                    PhoneNumber = updateLocationCommand.PhoneNumber,
                    CityId = updateLocationCommand.CityId,
                    RestaurantId = updateLocationCommand.RestaurantId,
                    CityName = "Test city",
                    RestaurantName = "Test restaurant"
                };
            });

            return this;
        }

        public MockMediatorForLocations VerifySendingUpdateLocationCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<UpdateLocationCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForLocations MockSendingDeleteLocationCommand()
        {
            Setup(m => m.Send(It.IsAny<DeleteLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((DeleteLocationCommand deleteLocationCommand, CancellationToken cancellationToken) =>
            {
                return new DeleteLocationCommandResponse
                {
                    Id = deleteLocationCommand.Id,
                };
            });

            return this;
        }

        public MockMediatorForLocations VerifySendingDeleteLocationCommand(Times times)
        {
            Verify(m => m.Send(It.IsAny<DeleteLocationCommand>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForLocations MockSendingGetLocationByIdQuery()
        {
            Setup(m => m.Send(It.IsAny<GetLocationByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetLocationByIdQuery getLocationByIdQuery, CancellationToken cancellationToken) =>
            {
                return new GetLocationByIdQueryResponse
                {
                    Id = getLocationByIdQuery.Id,
                    Address = "Test address",
                    Email = "test@email.com",
                    PhoneNumber = "123-456-789",
                    CityId = 1,
                    RestaurantId = 1,
                    CityName = "Test city",
                    RestaurantName = "Test restaurant"
                };
            });

            return this;
        }

        public MockMediatorForLocations VerifySendingGetLocationByIdQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetLocationByIdQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }

        public MockMediatorForLocations MockSendingGetLocationsQuery()
        {
            Setup(m => m.Send(It.IsAny<GetLocationsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetLocationsQuery getLocationsQuery, CancellationToken cancellationToken) =>
            {
                return new GetLocationsQueryResponse
                {
                    CityId = getLocationsQuery.CityId,
                    RestaurantId = getLocationsQuery.RestaurantId,
                    PageSize = getLocationsQuery.PageSize,
                    Page = getLocationsQuery.PageNumber,
                    TotalPages = 2,
                    Locations = new List<LocationDto>
                    {
                        new LocationDto
                        {
                            Id = 1,
                            Address = "Test address",
                            Email = "test@email.com",
                            PhoneNumber = "123-456-789",
                            CityName = "Test city",
                            RestaurantName = "Test restaurant"
                        },
                        new LocationDto
                        {
                            Id = 2,
                            Address = "Test address",
                            Email = "test@email.com",
                            PhoneNumber = "123-456-789",
                            CityName = "Test city",
                            RestaurantName = "Test restaurant"
                        },
                        new LocationDto
                        {
                            Id = 3,
                            Address = "Test address",
                            Email = "test@email.com",
                            PhoneNumber = "123-456-789",
                            CityName = "Test city",
                            RestaurantName = "Test restaurant"
                        }
                    }
                };
            });

            return this;
        }

        public MockMediatorForLocations VerifySendingGetLocationsQuery(Times times)
        {
            Verify(m => m.Send(It.IsAny<GetLocationsQuery>(), It.IsAny<CancellationToken>()), times);

            return this;
        }
    }
}
