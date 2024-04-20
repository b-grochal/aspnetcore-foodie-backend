USE [Foodie.Orders] 
GO

INSERT INTO OrderStatuses (Id, Name) VALUES (1, 'Started')
INSERT INTO OrderStatuses (Id, Name) VALUES (2, 'InProgress')
INSERT INTO OrderStatuses (Id, Name) VALUES (3, 'InDelivery')
INSERT INTO OrderStatuses (Id, Name) VALUES (4, 'Delivered')
INSERT INTO OrderStatuses (Id, Name) VALUES (5, 'Cancelled')
GO

INSERT INTO Buyers (Id, UserId, FirstName, LastName, PhoneNumber, Email) 
VALUES (1, '6a1ab648-6be8-44f1-87b7-394c34547589', 'Jim', 'Halpert', '123-456-789', 'jimhal123@foodie.com')

INSERT INTO Contractors (Id, RestaurantId, Name, LocationId, Address, PhoneNumber, Email, CityId, City, Country) 
VALUES (1, 1, 'KFC', 1, 'Kfc Las Vegas', '123-123-213', 'kfc.lasvegas@email.com', 1, 'Las Vegas', 'USA')

INSERT INTO Contractors (Id, RestaurantId, Name, LocationId, Address, PhoneNumber, Email, CityId, City, Country) 
VALUES (2, 2, 'Pizza Hut', 5, 'Pizza Hut Los Angeles', '123-123-213', 'pizzahut.losangeles@email.com', 2, 'Los Angeles', 'USA')

INSERT INTO Orders (Id, Address_Street, Address_City, Address_Country, OrderStatusId, BuyerId, ContractorId, OrderDate)
VALUES (1, 'Las Vegas Street', 'Las Vegas', 'USA', 1, 1, 1, GETDATE())

INSERT INTO Orders (Id, Address_Street, Address_City, Address_Country, OrderStatusId, BuyerId, ContractorId, OrderDate)
VALUES (2, 'Los Angeles Street', 'Los Angeles Vegas', 'USA', 1, 1, 2, GETDATE())

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Units, UnitPrice)
VALUES (1, 1, 1, 'Longer', 1, 12)

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Units, UnitPrice)
VALUES (2, 2, 1, 'Zinger', 2, 10)

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Units, UnitPrice)
VALUES (3, 3, 2, 'Pizza Texas', 1, 12)

INSERT INTO OrderItems (Id, MealId, OrderId, Name, Units, UnitPrice)
VALUES (4, 4, 2, 'Pizza Carbonara', 2, 12)

ALTER SEQUENCE BuyersSequence Restart with 2

ALTER SEQUENCE ContractorsSequence Restart with 2

ALTER SEQUENCE OrdersSequence Restart with 2

ALTER SEQUENCE OrderItemsSequence Restart with 4