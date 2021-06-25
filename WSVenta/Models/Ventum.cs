using System;
using System.Collections.Generic;

#nullable disable

namespace WSVenta.Models
{
    public partial class Ventum
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? Total { get; set; }
    }
}
