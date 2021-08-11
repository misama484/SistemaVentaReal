using System;
using System.Collections.Generic;

#nullable disable

namespace WSVenta.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            Conceptos = new HashSet<Concepto>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public string DniCliente { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente DniClienteNavigation { get; set; }
        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}
