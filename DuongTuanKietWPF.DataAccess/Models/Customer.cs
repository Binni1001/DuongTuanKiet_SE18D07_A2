﻿using System;
using System.Collections.Generic;

namespace DuongTuanKietWPF.DataAccess.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerFullName { get; set; } = null!;

    public string? Telephone { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateOnly? CustomerBirthday { get; set; }

    public byte CustomerStatus { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();
}
