using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E2BizzEventManagementSystem.Model
{
    [MetadataType(typeof(EventMetadata))]
    public partial class Event
    {
    }

    public class EventMetadata
    {
        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Event Code is a required field")]
        [MinLength(length: 6, ErrorMessage = "Event Code must be minimum 6 characters long")]
        [MaxLength(length: 6, ErrorMessage = "Event Code must be maximum 6 characters long")]
        public string EventCode { get; set; }
        [Required(ErrorMessage = "Event Name is a required field")]
        [MinLength(length: 5, ErrorMessage = "Event Name can not be less than 5 characters")]
        public string EventName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> Fees { get; set; }
        public Nullable<int> SeatsFilled { get; set; }
        public string Logo { get; set; }
    }
}
