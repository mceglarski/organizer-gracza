﻿using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        
        public User User { get; set; }
        public int? UserId { get; set; }
    }
}