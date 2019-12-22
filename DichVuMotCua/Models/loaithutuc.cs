namespace DichVuMotCua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loaithutuc")]
    public partial class loaithutuc
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? loai { get; set; }
    }
}