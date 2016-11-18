namespace HaveYouSeenMe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PetType")]
    public partial class PetType
    {
        public int PetTypeID { get; set; }

        [StringLength(50)]
        public string PetTypeDescription { get; set; }
    }
}
