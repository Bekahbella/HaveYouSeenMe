using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaveYouSeenMe.Models
{
    public class MessageModel
    {   [Required(ErrorMessage = "Please type your name")]
        [StringLength(150, ErrorMessage = "You can only have up to 150 characters")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please type your email address")]
        [StringLength(150, ErrorMessage = "You can only have up to 150 characters")]
        public string Email { get; set; }

        [Phone]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "(###) ###-####", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }

        [FileExtensions(Extensions = ".jpg, .png")]
        public string TypeOfEmail { get; set; }

        [StringLength(150, ErrorMessage = "You can only have up to 150 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please type your message")]
        [StringLength(150, ErrorMessage = "You can only have up to 150 characters")]
        [AllowHtml]
        public string Message { get; set; }
    }
}