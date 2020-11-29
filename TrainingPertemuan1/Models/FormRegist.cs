using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainingPertemuan1.Models
{
    public class FormRegist
    {
        public FormRegist() { }
        public FormRegist(int id, string firstName, string lastName, string address, string gender, bool isMarried, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Gender = gender;
            IsMarried = isMarried;
            Email = email;
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public string Email { get; set; }
    }
}