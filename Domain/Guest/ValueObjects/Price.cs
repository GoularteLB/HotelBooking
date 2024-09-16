using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Price
    {
        [Column(TypeName="decimal(18,5)")]
        public decimal Value { get; set; }

        public AcceptedCurrencies currency { get; set; }
    }
}
