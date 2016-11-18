namespace HaveYouSeenMe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Setting")]
    public partial class Setting
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Key { get; set; }

        [StringLength(500)]
        public string Value { get; set; }
    }
}
