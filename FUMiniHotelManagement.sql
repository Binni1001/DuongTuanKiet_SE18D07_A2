-- Create Database
USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'FUMiniHotelManagement')
BEGIN
    DROP DATABASE FUMiniHotelManagement;
END
GO

CREATE DATABASE FUMiniHotelManagement;
GO

USE FUMiniHotelManagement;
GO

-- Create RoomType table
CREATE TABLE RoomType (
    RoomTypeId INT IDENTITY(1,1) PRIMARY KEY,
    RoomTypeName NVARCHAR(50) NOT NULL,
    TypeDescription NVARCHAR(250),
    TypeNote NVARCHAR(250)
);

-- Create RoomInformation table
CREATE TABLE RoomInformation (
    RoomId INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber NVARCHAR(50) NOT NULL UNIQUE,
    RoomDetailDescription NVARCHAR(220),
    RoomMaxCapacity INT,
    RoomTypeId INT NOT NULL,
    RoomStatus TINYINT NOT NULL DEFAULT 1, -- 1: Active, 0: Inactive
    RoomPricePerDay MONEY,
    FOREIGN KEY (RoomTypeId) REFERENCES RoomType(RoomTypeId)
);

-- Create Customer table
CREATE TABLE Customer (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerFullName NVARCHAR(50) NOT NULL,
    Telephone NVARCHAR(12),
    EmailAddress NVARCHAR(50) NOT NULL UNIQUE,
    CustomerBirthday DATE,
    CustomerStatus TINYINT NOT NULL DEFAULT 1, -- 1: Active, 0: Inactive
    Password NVARCHAR(50) NOT NULL
);

-- Create BookingReservation table
CREATE TABLE BookingReservation (
    BookingReservationId INT IDENTITY(1,1) PRIMARY KEY,
    BookingDate DATE NOT NULL,
    TotalPrice MONEY,
    CustomerId INT NOT NULL,
    BookingStatus TINYINT NOT NULL DEFAULT 1, -- 1: Active, 0: Cancelled
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

-- Create BookingDetail table
CREATE TABLE BookingDetail (
    BookingReservationId INT NOT NULL,
    RoomId INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    ActualPrice MONEY,
    PRIMARY KEY (BookingReservationId, RoomId),
    FOREIGN KEY (BookingReservationId) REFERENCES BookingReservation(BookingReservationId),
    FOREIGN KEY (RoomId) REFERENCES RoomInformation(RoomId)
);

-- Insert sample data
INSERT INTO RoomType (RoomTypeName, TypeDescription, TypeNote) VALUES
('Standard', 'Standard room with basic amenities', 'Basic room type'),
('Deluxe', 'Deluxe room with premium amenities', 'Premium room type'),
('Suite', 'Suite with separate living area', 'Luxury room type');

INSERT INTO RoomInformation (RoomNumber, RoomDetailDescription, RoomMaxCapacity, RoomTypeId, RoomStatus, RoomPricePerDay) VALUES
('101', 'Standard room on first floor', 2, 1, 1, 100.00),
('102', 'Standard room on first floor', 2, 1, 1, 100.00),
('201', 'Deluxe room on second floor', 3, 2, 1, 150.00),
('202', 'Deluxe room on second floor', 3, 2, 1, 150.00),
('301', 'Suite on third floor', 4, 3, 1, 250.00);

INSERT INTO Customer (CustomerFullName, Telephone, EmailAddress, CustomerBirthday, CustomerStatus, Password) VALUES
('John Doe', '0123456789', 'john.doe@email.com', '1990-01-15', 1, 'password123'),
('Jane Smith', '0987654321', 'jane.smith@email.com', '1985-05-20', 1, 'password456'),
('Admin User', '0111222333', 'admin@FUMiniHotelSystem.com', '1980-01-01', 1, '@@abc123@@');

INSERT INTO BookingReservation (BookingDate, TotalPrice, CustomerId, BookingStatus) VALUES
('2024-01-15', 300.00, 1, 1),
('2024-01-20', 450.00, 2, 1);

INSERT INTO BookingDetail (BookingReservationId, RoomId, StartDate, EndDate, ActualPrice) VALUES
(1, 1, '2024-01-16', '2024-01-18', 200.00),
(1, 2, '2024-01-16', '2024-01-17', 100.00),
(2, 3, '2024-01-21', '2024-01-24', 450.00);

GO
