namespace EWSApplication.Entities.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [StringLength(10)]
        public string studentid { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName(" Student Name")]

        public string studentname { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName(" Student Gender")]
        public string studentgender { get; set; }

        [DisplayName(" Student DoB")]
        public DateTime studentdob { get; set; }

        [Required]
        [StringLength(10)]
        
        public string facultyid { get; set; }

        [Required]
        [StringLength(10)]
        public string userid { get; set; }

        [Required]
        [StringLength(10)]
        public string mmid { get; set; }
    }
}
