using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HollyProject.Models
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string deskripsi { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        [DataType(DataType.Currency)]
        public float price { get; set; }
        public int hotel_class { get; set; }
        public int rating { get; set; }
        public string image { get; set; }
    }
}