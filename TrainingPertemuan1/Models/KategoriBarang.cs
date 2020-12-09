using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainingPertemuan1.Models
{
    public class KategoriBarang
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public KategoriBarang() { }
        public KategoriBarang(int id, string name, int barangId)
        {
            Id = id;
            Name = name;
            Barang_Id = barangId;

        }
        public int Barang_Id { get; set; }
        [ForeignKey("Barang_Id")]
        public Barang Barang { get; set; }

    }
}