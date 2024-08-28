using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class PersonId
    {
        public string IdNumber { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
