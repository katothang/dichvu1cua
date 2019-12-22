namespace DichVuMotCua.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoso")]
    public partial class hoso
    {
        public int id { get; set; }

        [StringLength(255)]
        public string noidung { get; set; }

        public int? nguoitao { get; set; }

        public int? nguoiduyet { get; set; }
    }
}
