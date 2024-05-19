USE [Foodie.Orders] 
GO

INSERT INTO Buyers (Id, CustomerId, FirstName, LastName, PhoneNumber, Email, CreatedBy, CreatedDate) 
VALUES (1, '3', 'Jim', 'Halpert', '123-456-789', 'jimhal123@foodie.com', 'Seed', GETDATE())

INSERT INTO Contractors (Id, RestaurantId, Name, LocationId, Address, PhoneNumber, Email, CityId, City, CountryId, Country, CreatedBy, CreatedDate) 
VALUES (1, 1, 'KFC', 1, 'Kfc Las Vegas', '123-123-213', 'kfc.lasvegas@email.com', 1, 'Las Vegas', 1, 'USA', 'Seed', GETDATE())

INSERT INTO Contractors (Id, RestaurantId, Name, LocationId, Address, PhoneNumber, Email, CityId, City, CountryId, Country, CreatedBy, CreatedDate) 
VALUES (2, 2, 'Pizza Hut', 5, 'Pizza Hut Los Angeles', '123-123-213', 'pizzahut.losangeles@email.com', 2, 'Los Angeles', 1, 'USA', 'Seed', GETDATE())

INSERT INTO Orders (Id, BuyerId, ContractorId, OrderStatus, DeliveryAddress_Street, DeliveryAddress_City, DeliveryAddress_Country, CreatedBy, CreatedDate)
VALUES (1, 1, 1, 'Started', 'Las Vegas Street', 'Las Vegas', 'USA', 'Seed', GETDATE())

INSERT INTO Orders (Id, BuyerId, ContractorId, OrderStatus, DeliveryAddress_Street, DeliveryAddress_City, DeliveryAddress_Country, CreatedBy, CreatedDate)
VALUES (2, 1, 2, 'Started', 'Los Angeles Street', 'Los Angeles Vegas', 'USA', 'Seed', GETDATE())

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Quantity, UnitPrice, CreatedBy, CreatedDate)
VALUES (1, 1, 1, 'Longer', 1, 12, 'Seed', GETDATE())

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Quantity, UnitPrice, CreatedBy, CreatedDate)
VALUES (2, 2, 1, 'Zinger', 2, 10, 'Seed', GETDATE())

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Quantity, UnitPrice, CreatedBy, CreatedDate)
VALUES (3, 3, 2, 'Pizza Texas', 1, 12, 'Seed', GETDATE())

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Quantity, UnitPrice, CreatedBy, CreatedDate)
VALUES (4, 4, 2, 'Pizza Carbonara', 2, 12, 'Seed', GETDATE())

ALTER SEQUENCE BuyersSequence Restart with 2

ALTER SEQUENCE ContractorsSequence Restart with 2

ALTER SEQUENCE OrdersSequence Restart with 2

ALTER SEQUENCE OrderItemsSequence Restart with 4