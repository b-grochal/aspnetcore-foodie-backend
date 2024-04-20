//using AutoMapper;
//using Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation;
//using Foodie.Meals.Application.Mapper;
//using Foodie.Meals.Domain.Exceptions;
//using Foodie.Meals.UnitTests.Mocks.Repositories;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace Foodie.Meals.UnitTests.Handlers.Locations
//{
//    public class UpdateLocationCommandHandlerTests
//    {
//        private readonly IMapper mapper;

//        public UpdateLocationCommandHandlerTests()
//        {
//            var mapperConfiguration = new MapperConfiguration(c =>
//            {
//                c.AddProfile<MapperProfile>();
//            });

//            this.mapper = mapperConfiguration.CreateMapper();
//        }

//        [Fact]
//        public async void UpdateLocationCommandHandler_HandleUpdatingExistingLocation_ShouldSucessfullyUpdateExistingLocation()
//        {
//            var locationsRepository = new MockLocationsRepository()
//                .MockUpdateAsync()
//                .MockGetByIdAsync();

//            var command = new UpdateLocationCommand
//            {
//                Id = 1,
//                Address = "Test address",
//                PhoneNumber = "123-456-789",
//                Email = "test@email.com",
//                CityId = 1,
//                RestaurantId = 1
//            };

//            var commandHandler = new UpdateLocationCommandHandler(locationsRepository.Object, this.mapper);

//            var result = await commandHandler.Handle(command, CancellationToken.None);

//            Assert.IsType<UpdateLocationCommandResponse>(result);
//            Assert.Equal(command.Id, result.Id);
//            Assert.Equal(command.Address, result.Address);
//            Assert.Equal(command.Email, result.Email);
//            Assert.Equal(command.PhoneNumber, result.PhoneNumber);
//            Assert.Equal(command.RestaurantId, result.RestaurantId);
//            Assert.Equal(command.CityId, result.CityId);
//            locationsRepository.VerifyUpdateAsync(Times.Once());
//            locationsRepository.VerifyGetByIdAsync(Times.Once());
//        }

//        [Fact]
//        public async void UpdateLocationCommandHandler_HandleUpdatingNonExistingLocation_ShouldThrowLocationNotFoundException()
//        {
//            var locationsRepository = new MockLocationsRepository()
//                .MockUpdateAsync()
//                .MockGetByIdAsyncWithNullResult();

//            var command = new UpdateLocationCommand
//            {
//                Id = 1,
//                Address = "Test address",
//                PhoneNumber = "123-456-789",
//                Email = "test@email.com",
//                CityId = 1,
//                RestaurantId = 1
//            };

//            var commandHandler = new UpdateLocationCommandHandler(locationsRepository.Object, this.mapper);

//            await Assert.ThrowsAsync<LocationNotFoundException>(async () => await commandHandler.Handle(command, CancellationToken.None));

//            locationsRepository.VerifyUpdateAsync(Times.Never());
//            locationsRepository.VerifyGetByIdAsyncWithNullResult(Times.Once());
//        }
//    }
//}
