namespace DichVuMotCua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitiethoso")]
    public partial class chitiethoso
    {
        public int id { get; set; }

        [StringLength(255)]
        public string noidung { get; set; }

        public int? hoso { get; set; }
    }
}
