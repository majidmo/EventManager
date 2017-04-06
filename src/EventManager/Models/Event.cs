using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class Event : BaseEntity
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Host { get; set; }
        //public DateTime Deadline { get; set; }
        public int MaxNoOfAttendees { get; set; }
        //public decimal Price { get; set; }
    }
}
