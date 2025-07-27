using System;
using System.ComponentModel.DataAnnotations;

namespace DuongTuanKietWPF.Business.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer full name is required")]
        [StringLength(50, ErrorMessage = "Customer full name cannot exceed 50 characters")]
        public string CustomerFullName { get; set; } = string.Empty;

        [StringLength(12, ErrorMessage = "Telephone cannot exceed 12 characters")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [StringLength(50, ErrorMessage = "Email address cannot exceed 50 characters")]
        public string EmailAddress { get; set; } = string.Empty;

        public DateOnly? CustomerBirthday { get; set; }

        public byte CustomerStatus { get; set; } = 1;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters")]
        public string Password { get; set; } = string.Empty;
    }

    public class CustomerLoginDto
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }

    public class CustomerCreateDto
    {
        [Required(ErrorMessage = "Customer full name is required")]
        [StringLength(50, ErrorMessage = "Customer full name cannot exceed 50 characters")]
        public string CustomerFullName { get; set; } = string.Empty;

        [StringLength(12, ErrorMessage = "Telephone cannot exceed 12 characters")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [StringLength(50, ErrorMessage = "Email address cannot exceed 50 characters")]
        public string EmailAddress { get; set; } = string.Empty;

        public DateOnly? CustomerBirthday { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters")]
        public string Password { get; set; } = string.Empty;
    }

    public class CustomerUpdateDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer full name is required")]
        [StringLength(50, ErrorMessage = "Customer full name cannot exceed 50 characters")]
        public string CustomerFullName { get; set; } = string.Empty;

        [StringLength(12, ErrorMessage = "Telephone cannot exceed 12 characters")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [StringLength(50, ErrorMessage = "Email address cannot exceed 50 characters")]
        public string EmailAddress { get; set; } = string.Empty;

        public DateOnly? CustomerBirthday { get; set; }

        public byte CustomerStatus { get; set; }
    }
}
