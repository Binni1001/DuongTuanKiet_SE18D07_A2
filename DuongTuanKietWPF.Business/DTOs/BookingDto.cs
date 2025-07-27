using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DuongTuanKietWPF.Business.DTOs
{
    public class BookingDto
    {
        public int BookingReservationId { get; set; }

        [Required(ErrorMessage = "Booking date is required")]
        public DateOnly BookingDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than 0")]
        public decimal? TotalPrice { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }

        public byte BookingStatus { get; set; } = 1;

        // Navigation properties
        public string? CustomerFullName { get; set; }
        public string? CustomerEmail { get; set; }
        public List<BookingDetailDto> BookingDetails { get; set; } = new List<BookingDetailDto>();
    }

    public class BookingDetailDto
    {
        public int BookingReservationId { get; set; }
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateOnly EndDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Actual price must be greater than 0")]
        public decimal? ActualPrice { get; set; }

        // Navigation properties
        public string? RoomNumber { get; set; }
        public string? RoomTypeName { get; set; }
        public decimal? RoomPricePerDay { get; set; }
    }

    public class BookingCreateDto
    {
        [Required(ErrorMessage = "Booking date is required")]
        public DateOnly BookingDate { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "At least one room must be selected")]
        public List<BookingDetailCreateDto> BookingDetails { get; set; } = new List<BookingDetailCreateDto>();
    }

    public class BookingDetailCreateDto
    {
        [Required(ErrorMessage = "Room is required")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateOnly EndDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Actual price must be greater than 0")]
        public decimal? ActualPrice { get; set; }
    }

    public class BookingUpdateDto
    {
        public int BookingReservationId { get; set; }

        [Required(ErrorMessage = "Booking date is required")]
        public DateOnly BookingDate { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }

        public byte BookingStatus { get; set; }

        [Required(ErrorMessage = "At least one room must be selected")]
        public List<BookingDetailCreateDto> BookingDetails { get; set; } = new List<BookingDetailCreateDto>();
    }

    public class BookingReportDto
    {
        public int BookingReservationId { get; set; }
        public DateOnly BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public string CustomerFullName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int TotalRooms { get; set; }
        public List<BookingDetailDto> BookingDetails { get; set; } = new List<BookingDetailDto>();
    }
}
