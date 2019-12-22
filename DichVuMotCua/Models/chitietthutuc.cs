namespace DichVuMotCua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietthutuc")]
    public partial class chitietthutuc
    {
        public int id { get; set; }

        [StringLength(255)]
        public string noidung { get; set; }

        public int? thutuc { get; set; }
        public string value { get; set; }
    }
}
