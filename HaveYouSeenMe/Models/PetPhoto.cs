namespace HaveYouSeenMe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PetPhoto")]
    public partial class PetPhoto
    {
        [Key]
        public int PhotoID { get; set; }

        public int PetID { get; set; }

        [Required]
        [StringLength(500)]
        public string Photo { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
