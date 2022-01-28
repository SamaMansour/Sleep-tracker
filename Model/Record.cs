using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sleep_tracker.Model
{
    public class Record
    {

        [Key]
        public int Id { get; set; }

      

        [Required]
        public DateTime SleepTime { get; set; }

        [Required]
        public DateTime WakeupTime { get; set; }



        [NotMapped]
        public TimeSpan TotalHrs
        {
            get
            {
                return this.WakeupTime - this.SleepTime;
            }
        }



    }
}
