namespace HaveYouSeenMe.Models.Business
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageID { get; set; }

        public int UserId { get; set; }

        public DateTime MessageDate { get; set; }

        [Required]
        [StringLength(150)]
        public string From { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Subject { get; set; }

        [Column("Message")]
        [Required]
        [StringLength(1500)]
        public string Message1 { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
