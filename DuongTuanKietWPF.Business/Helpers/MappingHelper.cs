using DuongTuanKietWPF.Business.DTOs;
using DuongTuanKietWPF.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DuongTuanKietWPF.Business.Helpers
{
    public static class MappingHelper
    {
        // Customer mappings
        public static CustomerDto ToDto(Customer customer)
        {
            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                CustomerFullName = customer.CustomerFullName,
                Telephone = customer.Telephone,
                EmailAddress = customer.EmailAddress,
                CustomerBirthday = customer.CustomerBirthday,
                CustomerStatus = customer.CustomerStatus,
                Password = customer.Password
            };
        }

        public static Customer ToEntity(CustomerCreateDto dto)
        {
            return new Customer
            {
                CustomerFullName = dto.CustomerFullName,
                Telephone = dto.Telephone,
                EmailAddress = dto.EmailAddress,
                CustomerBirthday = dto.CustomerBirthday,
                CustomerStatus = 1,
                Password = dto.Password
            };
        }

        public static void UpdateEntity(Customer entity, CustomerUpdateDto dto)
        {
            entity.CustomerFullName = dto.CustomerFullName;
            entity.Telephone = dto.Telephone;
            entity.EmailAddress = dto.EmailAddress;
            entity.CustomerBirthday = dto.CustomerBirthday;
            entity.CustomerStatus = dto.CustomerStatus;
        }

        // Room mappings
        public static RoomDto ToDto(RoomInformation room)
        {
            return new RoomDto
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                RoomDetailDescription = room.RoomDetailDescription,
                RoomMaxCapacity = room.RoomMaxCapacity,
                RoomTypeId = room.RoomTypeId,
                RoomStatus = room.RoomStatus,
                RoomPricePerDay = room.RoomPricePerDay,
                RoomTypeName = room.RoomType?.RoomTypeName,
                TypeDescription = room.RoomType?.TypeDescription
            };
        }

        public static RoomInformation ToEntity(RoomCreateDto dto)
        {
            return new RoomInformation
            {
                RoomNumber = dto.RoomNumber,
                RoomDetailDescription = dto.RoomDetailDescription,
                RoomMaxCapacity = dto.RoomMaxCapacity,
                RoomTypeId = dto.RoomTypeId,
                RoomStatus = 1,
                RoomPricePerDay = dto.RoomPricePerDay
            };
        }

        public static void UpdateEntity(RoomInformation entity, RoomUpdateDto dto)
        {
            entity.RoomNumber = dto.RoomNumber;
            entity.RoomDetailDescription = dto.RoomDetailDescription;
            entity.RoomMaxCapacity = dto.RoomMaxCapacity;
            entity.RoomTypeId = dto.RoomTypeId;
            entity.RoomStatus = dto.RoomStatus;
            entity.RoomPricePerDay = dto.RoomPricePerDay;
        }

        // RoomType mappings
        public static RoomTypeDto ToDto(RoomType roomType)
        {
            return new RoomTypeDto
            {
                RoomTypeId = roomType.RoomTypeId,
                RoomTypeName = roomType.RoomTypeName,
                TypeDescription = roomType.TypeDescription,
                TypeNote = roomType.TypeNote
            };
        }

        // Booking mappings
        public static BookingDto ToDto(BookingReservation booking)
        {
            return new BookingDto
            {
                BookingReservationId = booking.BookingReservationId,
                BookingDate = booking.BookingDate,
                TotalPrice = booking.TotalPrice,
                CustomerId = booking.CustomerId,
                BookingStatus = booking.BookingStatus,
                CustomerFullName = booking.Customer?.CustomerFullName,
                CustomerEmail = booking.Customer?.EmailAddress,
                BookingDetails = booking.BookingDetails?.Select(ToDto).ToList() ?? new List<BookingDetailDto>()
            };
        }

        public static BookingReservation ToEntity(BookingCreateDto dto)
        {
            return new BookingReservation
            {
                BookingDate = dto.BookingDate,
                CustomerId = dto.CustomerId,
                BookingStatus = 1
            };
        }

        public static void UpdateEntity(BookingReservation entity, BookingUpdateDto dto)
        {
            entity.BookingDate = dto.BookingDate;
            entity.CustomerId = dto.CustomerId;
            entity.BookingStatus = dto.BookingStatus;
        }

        // BookingDetail mappings
        public static BookingDetailDto ToDto(BookingDetail detail)
        {
            return new BookingDetailDto
            {
                BookingReservationId = detail.BookingReservationId,
                RoomId = detail.RoomId,
                StartDate = detail.StartDate,
                EndDate = detail.EndDate,
                ActualPrice = detail.ActualPrice,
                RoomNumber = detail.Room?.RoomNumber,
                RoomTypeName = detail.Room?.RoomType?.RoomTypeName,
                RoomPricePerDay = detail.Room?.RoomPricePerDay
            };
        }

        public static BookingDetail ToEntity(BookingDetailCreateDto dto)
        {
            return new BookingDetail
            {
                RoomId = dto.RoomId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ActualPrice = dto.ActualPrice
            };
        }

        // Report mappings
        public static BookingReportDto ToReportDto(BookingReservation booking)
        {
            return new BookingReportDto
            {
                BookingReservationId = booking.BookingReservationId,
                BookingDate = booking.BookingDate,
                TotalPrice = booking.TotalPrice,
                CustomerFullName = booking.Customer?.CustomerFullName ?? string.Empty,
                CustomerEmail = booking.Customer?.EmailAddress ?? string.Empty,
                TotalRooms = booking.BookingDetails?.Count ?? 0,
                BookingDetails = booking.BookingDetails?.Select(ToDto).ToList() ?? new List<BookingDetailDto>()
            };
        }

        // Collection mappings
        public static IEnumerable<CustomerDto> ToDto(IEnumerable<Customer> customers)
        {
            return customers.Select(ToDto);
        }

        public static IEnumerable<RoomDto> ToDto(IEnumerable<RoomInformation> rooms)
        {
            return rooms.Select(ToDto);
        }

        public static IEnumerable<RoomTypeDto> ToDto(IEnumerable<RoomType> roomTypes)
        {
            return roomTypes.Select(ToDto);
        }

        public static IEnumerable<BookingDto> ToDto(IEnumerable<BookingReservation> bookings)
        {
            return bookings.Select(ToDto);
        }

        public static IEnumerable<BookingReportDto> ToReportDto(IEnumerable<BookingReservation> bookings)
        {
            return bookings.Select(ToReportDto);
        }
    }
}
