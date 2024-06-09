USE [Foodie.Identity] 
GO

SET IDENTITY_INSERT ApplicationUsers ON

INSERT INTO ApplicationUsers (Id, FirstName, LastName, Email, PhoneNumber, PasswordHash, AccessFailedCount, IsLocked, IsActive, Role, IsDeleted) 
VALUES (1, 'Michael', 'Scott', 'michsco123@foodie.com', '123-456-789', '$2a$11$PoFX6aj9gOhvC0GmgA9C8e4Rlo749VwDWom0vFY9IZ1Ber8XHjUUW', 0, 0, 1, 1, 0);

INSERT INTO ApplicationUsers (Id, FirstName, LastName, Email, PhoneNumber, PasswordHash, AccessFailedCount, IsLocked, IsActive, Role, IsDeleted) 
VALUES (2, 'Dwight', 'Schrute', 'dwigsch123@foodie.com', '123-456-789', '$2a$11$PoFX6aj9gOhvC0GmgA9C8e4Rlo749VwDWom0vFY9IZ1Ber8XHjUUW', 0, 0, 1, 2, 0);

INSERT INTO ApplicationUsers (Id, FirstName, LastName, Email, PhoneNumber, PasswordHash, AccessFailedCount, IsLocked, IsActive, Role, IsDeleted) 
VALUES (3, 'Jim', 'Halpert', 'jimhal123@foodie.com', '123-456-789', '$2a$11$PoFX6aj9gOhvC0GmgA9C8e4Rlo749VwDWom0vFY9IZ1Ber8XHjUUW', 0, 0, 1, 3, 0);

SET IDENTITY_INSERT ApplicationUsers OFF

INSERT INTO Admins (Id)
VALUES (1);

INSERT INTO OrderHandlers (Id, LocationId)
VALUES (2, 1);

INSERT INTO Customers (Id)
VALUES (3);