using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Action
    {
        Pay = 0,
        Finish = 1, // after your guest uses and pays
        Cancel = 2,
        Refound = 3,
        Reopen = 4,

    }
}
