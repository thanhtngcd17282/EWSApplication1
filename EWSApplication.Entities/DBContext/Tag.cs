namespace EWSApplication.Entities.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        [StringLength(10)]
        public string tagid { get; set; }

        [Required]
        [StringLength(100)]
        public string tagname { get; set; }

        [Required]
        [StringLength(100)]
        public string description { get; set; }
    }
}
