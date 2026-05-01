using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Static utility class that tracks the total number of medicine entries created.
    public static class InventoryCounter
    {
        // Holds the running count of all Medicine objects instantiated in the system.
        public static int TotalMedicines { get; set; } = 0;
    }
}
