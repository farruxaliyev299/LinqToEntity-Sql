using System;
using System.Collections.Generic;

namespace LinqToHW.Models
{
    public partial class Ogrenciler
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? City { get; set; }
    }
}
