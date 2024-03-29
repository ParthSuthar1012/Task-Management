﻿using System.ComponentModel.DataAnnotations.Schema;
using Task_Management.SD;

namespace Task_Management.Models.NewFolder
{
    public class DisplayVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }   
        public string Status { get; set; }    
        public string Priority { get; set; }     
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> AssignedToUsers { get; set; }
    }
}
