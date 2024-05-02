



-- Creating tables
CREATE TABLE BuildingCompanies (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Buildings (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Direction NVARCHAR(MAX) NOT NULL,
    BuildingCompanyId INT NOT NULL,
    FOREIGN KEY (BuildingCompanyId) REFERENCES BuildingCompanies(Id)
);

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Surname NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    Password NVARCHAR(MAX) NOT NULL,
    Role INT NOT NULL,
    BuildingId INT,
    FOREIGN KEY (BuildingId) REFERENCES Buildings(Id) ON DELETE SET NULL 
);

CREATE TABLE Apartments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Number INT NOT NULL,
    Floor INT NOT NULL,
    NumberOfBedrooms INT NOT NULL,
    NumberOfBathrooms INT NOT NULL,
    HasTerrace BIT NOT NULL,
    OwnerId INT NOT NULL,
    BuildingId INT,
    FOREIGN KEY (OwnerId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (BuildingId) REFERENCES Buildings(Id) ON DELETE SET NULL 
);

CREATE TABLE CategoryService (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE MaintenanceRequests (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Description NVARCHAR(MAX) NOT NULL,
    DateStart DATETIME2 NOT NULL,
    DateEnd DATETIME2 NOT NULL,
    State INT NOT NULL,
    ApartmentId INT NOT NULL,
    CategoryServiceId INT NOT NULL,
    FOREIGN KEY (ApartmentId) REFERENCES Apartments(Id) ON DELETE CASCADE,
    FOREIGN KEY (CategoryServiceId) REFERENCES CategoryService(Id)
);

CREATE TABLE Invitation (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NameUser NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    FechaLimite DATETIME2 NOT NULL
);

-- Insert sample data (example for one table)
-- Insert data into BuildingCompanies
INSERT INTO BuildingCompanies (Name) VALUES 
('Building Corp'),
('Estate Holdings'),
('Skyline Builders'),
('Urban Developments'),
('Modern Spaces Ltd'),
('Heritage Constructions'),
('EcoLiving Builders'),
('Premier Real Estate Group'),
('Metropolis Constructors'),
('Tower Block Inc');

-- Insert data into Buildings
INSERT INTO Buildings (Name, Direction, BuildingCompanyId) VALUES 
('High Rise Complex', '101 Broad Street', 1),
('The Panorama', '550 Skyline Blvd', 2),
('River View Towers', '202 River Road', 3),
('Maple Gardens', '404 Green St', 4),
('The Metropolitan', '808 Cityscape Ave', 5),
('Pine Crest Apartments', '303 Pine Crest Rd', 6),
('Green Horizons', '707 Sustainable Way', 7),
('Harbor Light Towers', '400 Harbor View St', 8),
('City Center Flats', '250 Center St', 9),
('Hilltop Haven', '910 Hill St', 10);

-- Insert data into Users
INSERT INTO Users (Name, Surname, Email, Password, Role, BuildingId) VALUES 
('John', 'Doe', 'john.doe@example.com', 'pass123', 1, 1),
('Jane', 'Smith', 'jane.smith@example.com', 'pass456', 2, 2),
('Alice', 'Johnson', 'alice.johnson@example.com', 'pass789', 2, 3),
('Bob', 'Lee', 'bob.lee@example.com', 'pass321', 3, 4),
('Carol', 'White', 'carol.white@example.com', 'pass654', 1, 5),
('David', 'Brown', 'david.brown@example.com', 'pass987', 2, 6),
('Eve', 'Davis', 'eve.davis@example.com', 'pass789', 3, 7),
('Frank', 'Miller', 'frank.miller@example.com', 'pass432', 1, 8),
('Grace', 'Wilson', 'grace.wilson@example.com', 'pass678', 2, 9),
('Hank', 'Moore', 'hank.moore@example.com', 'pass543', 3, 10);

-- Insert data into Apartments
INSERT INTO Apartments (Number, Floor, NumberOfBedrooms, NumberOfBathrooms, HasTerrace, OwnerId, BuildingId) VALUES 
(101, 10, 3, 2, 1, 1, 1),
(102, 9, 2, 1, 0, 2, 1),
(103, 8, 1, 1, 1, 3, 2),
(104, 7, 3, 2, 0, 4, 2),
(105, 6, 2, 2, 1, 5, 3),
(106, 5, 1, 1, 0, 6, 3),
(107, 4, 3, 2, 1, 7, 4),
(108, 3, 2, 1, 0, 8, 4),
(109, 2, 1, 1, 1, 9, 5),
(110, 1, 3, 2, 0, 10, 5);


INSERT INTO CategoryService (Name) VALUES 
('Plumbing'),
('Electrical'),
('HVAC'),
('Cleaning'),
('Landscaping'),
('Security'),
('Painting'),
('Roofing'),
('Flooring'),
('General Maintenance');

INSERT INTO MaintenanceRequests (Description, DateStart, DateEnd, State, ApartmentId, CategoryServiceId) VALUES 
('Leaky faucet repair', '2022-01-15', '2022-01-16', 1, 1, 1),
('Light fixture installation', '2022-01-20', '2022-01-21', 1, 2, 2),
('Air conditioning fix', '2022-02-10', '2022-02-11', 1, 3, 3),
('Carpet cleaning', '2022-02-15', '2022-02-16', 1, 4, 4),
('Garden maintenance', '2022-03-01', '2022-03-02', 1, 5, 5),
('Install security cameras', '2022-03-10', '2022-03-11', 1, 6, 6),
('Repainting the living room', '2022-03-20', '2022-03-21', 1, 7, 7),
('Roof inspection', '2022-04-01', '2022-04-02', 1, 8, 8),
('Replacing old wooden floors', '2022-04-10', '2022-04-11', 1, 9, 9),
('Fixing general wear and tear', '2022-04-20', '2022-04-21', 1, 10, 10);

INSERT INTO Invitation (NameUser, Email, FechaLimite) VALUES 
('Guest1', 'guest1@example.com', '2023-05-01'),
('Guest2', 'guest2@example.com', '2023-05-02'),
('Guest3', 'guest3@example.com', '2023-05-03'),
('Guest4', 'guest4@example.com', '2023-05-04'),
('Guest5', 'guest5@example.com', '2023-05-05'),
('Guest6', 'guest6@example.com', '2023-05-06'),
('Guest7', 'guest7@example.com', '2023-05-07'),
('Guest8', 'guest8@example.com', '2023-05-08'),
('Guest9', 'guest9@example.com', '2023-05-09'),
('Guest10', 'guest10@example.com', '2023-05-10');



-- Dropping tables 
DROP TABLE IF EXISTS Invitation;
DROP TABLE IF EXISTS MaintenanceRequests;
DROP TABLE IF EXISTS Apartments;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Buildings;
DROP TABLE IF EXISTS BuildingCompanies;
DROP TABLE IF EXISTS CategoryService;
