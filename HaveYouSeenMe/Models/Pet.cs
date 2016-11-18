namespace HaveYouSeenMe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pet")]
    public partial class Pet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pet()
        {
            PetPhotoes = new HashSet<PetPhoto>();
        }

        public int PetID { get; set; }

        [Required]
        [StringLength(100)]
        public string PetName { get; set; }

        public int? PetAgeYears { get; set; }

        public int? PetAgeMonths { get; set; }

        public int StatusID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastSeenOn { get; set; }

        [StringLength(500)]
        public string LastSeenWhere { get; set; }

        [StringLength(1500)]
        public string Notes { get; set; }

        public int UserId { get; set; }

        public virtual Status Status { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PetPhoto> PetPhotoes { get; set; }
    }
}
