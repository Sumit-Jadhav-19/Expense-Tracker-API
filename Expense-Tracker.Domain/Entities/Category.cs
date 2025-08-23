using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime Data_Entered_On { get; set; } = DateTime.Now;
        public int Data_Entered_By { get; set; }
        public DateTime Data_Modified_On { get; set; }
        public int Data_Modified_By { get; set; }
    }
}
