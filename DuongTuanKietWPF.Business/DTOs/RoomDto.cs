using System.ComponentModel.DataAnnotations;

namespace DuongTuanKietWPF.Business.DTOs
{
    public class RoomDto
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Room number is required")]
        [StringLength(50, ErrorMessage = "Room number cannot exceed 50 characters")]
        public string RoomNumber { get; set; } = string.Empty;

        [StringLength(220, ErrorMessage = "Room description cannot exceed 220 characters")]
        public string? RoomDetailDescription { get; set; }

        [Range(1, 10, ErrorMessage = "Room max capacity must be between 1 and 10")]
        public int? RoomMaxCapacity { get; set; }

        [Required(ErrorMessage = "Room type is required")]
        public int RoomTypeId { get; set; }

        public byte RoomStatus { get; set; } = 1;

        [Range(0.01, double.MaxValue, ErrorMessage = "Room price must be greater than 0")]
        public decimal? RoomPricePerDay { get; set; }

        // Navigation properties
        public string? RoomTypeName { get; set; }
        public string? TypeDescription { get; set; }
    }

    public class RoomCreateDto
    {
        [Required(ErrorMessage = "Room number is required")]
        [StringLength(50, ErrorMessage = "Room number cannot exceed 50 characters")]
        public string RoomNumber { get; set; } = string.Empty;

        [StringLength(220, ErrorMessage = "Room description cannot exceed 220 characters")]
        public string? RoomDetailDescription { get; set; }

        [Range(1, 10, ErrorMessage = "Room max capacity must be between 1 and 10")]
        public int? RoomMaxCapacity { get; set; }

        [Required(ErrorMessage = "Room type is required")]
        public int RoomTypeId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Room price must be greater than 0")]
        public decimal? RoomPricePerDay { get; set; }
    }

    public class RoomUpdateDto
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Room number is required")]
        [StringLength(50, ErrorMessage = "Room number cannot exceed 50 characters")]
        public string RoomNumber { get; set; } = string.Empty;

        [StringLength(220, ErrorMessage = "Room description cannot exceed 220 characters")]
        public string? RoomDetailDescription { get; set; }

        [Range(1, 10, ErrorMessage = "Room max capacity must be between 1 and 10")]
        public int? RoomMaxCapacity { get; set; }

        [Required(ErrorMessage = "Room type is required")]
        public int RoomTypeId { get; set; }

        public byte RoomStatus { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Room price must be greater than 0")]
        public decimal? RoomPricePerDay { get; set; }
    }

    public class RoomTypeDto
    {
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage = "Room type name is required")]
        [StringLength(50, ErrorMessage = "Room type name cannot exceed 50 characters")]
        public string RoomTypeName { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Type description cannot exceed 250 characters")]
        public string? TypeDescription { get; set; }

        [StringLength(250, ErrorMessage = "Type note cannot exceed 250 characters")]
        public string? TypeNote { get; set; }
    }
}
