USE [Foodie.Orders] 
GO

INSERT INTO Buyers (Id, CustomerId, FirstName, LastName, PhoneNumber, Email) 
VALUES (1, '3', 'Jim', 'Halpert', '123-456-789', 'jimhal123@foodie.com')

INSERT INTO Contractors (Id, RestaurantId, Name, LocationId, Address, PhoneNumber, Email, CityId, City, CountryId, Country) 
VALUES (1, 1, 'KFC', 1, 'Kfc Las Vegas', '123-123-213', 'kfc.lasvegas@email.com', 1, 'Las Vegas', 1, 'USA')

INSERT INTO Contractors (Id, RestaurantId, Name, LocationId, Address, PhoneNumber, Email, CityId, City, CountryId, Country) 
VALUES (2, 2, 'Pizza Hut', 5, 'Pizza Hut Los Angeles', '123-123-213', 'pizzahut.losangeles@email.com', 2, 'Los Angeles', 1, 'USA')

INSERT INTO Orders (Id, BuyerId, ContractorId, OrderStatus, DeliveryAddress_Street, DeliveryAddress_City, DeliveryAddress_Country)
VALUES (1, 1, 1, 'Started', 'Las Vegas Street', 'Las Vegas', 'USA')

INSERT INTO Orders (Id, BuyerId, ContractorId, OrderStatus, DeliveryAddress_Street, DeliveryAddress_City, DeliveryAddress_Country)
VALUES (2, 1, 2, 'Started', 'Los Angeles Street', 'Los Angeles Vegas', 'USA')

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Quantity, UnitPrice)
VALUES (1, 1, 1, 'Longer', 1, 12)

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Quantity, UnitPrice)
VALUES (2, 2, 1, 'Zinger', 2, 10)

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Quantity, UnitPrice)
VALUES (3, 3, 2, 'Pizza Texas', 1, 12)

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Quantity, UnitPrice)
VALUES (4, 4, 2, 'Pizza Carbonara', 2, 12)

ALTER SEQUENCE BuyersSequence Restart with 2

ALTER SEQUENCE ContractorsSequence Restart with 2

ALTER SEQUENCE OrdersSequence Restart with 2

ALTER SEQUENCE OrderItemsSequence Restart with 4