using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainingPertemuan1.Models
{
    public class Department
    {
        public Department()
        {

        }
        public Department(int id, string name, DateTimeOffset createdOn, int divisionId)
        {
            Id = id;
            Name = name;
            CreatedOn = createdOn;
            Division_Id = divisionId;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public int Division_Id { get; set; }
        [ForeignKey("Division_Id")]
        public Division Division { get; set; }
    }
}