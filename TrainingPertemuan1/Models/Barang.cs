using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingPertemuan1.Models
{
    public class Barang
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Barang()
        {

        }
        public Barang(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}