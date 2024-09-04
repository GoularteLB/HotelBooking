using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; set; }

        public AcceptedCurrencies currency { get; set; }
    }
}
