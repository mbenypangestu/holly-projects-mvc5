using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HollyProject.Models
{
    public class Booking
    {
        public int id { get; set; }
        public int Userid { get; set; }
        public int Hotelid { get; set; }
        public string date_checkin { get; set; }
        public string date_checkout { get; set; }
        public int jml_orang { get; set; }
        public int jml_hari { get; set; }
        public float total { get; set; }
        public int is_accepted { get; set; }
        public int is_canceled { get; set; }
        public int is_rescheduled { get; set; }
        public int is_rejected { get; set; }
        public int request_reschedule { get; set; }
        public int request_cancel { get; set; }

        public virtual User User { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}