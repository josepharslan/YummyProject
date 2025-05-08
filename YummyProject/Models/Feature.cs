using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
        [Required(ErrorMessage ="Resim Boş Bırakılamaz")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Başlık Boş Bırakılamaz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama Boş Bırakılamaz")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vide Url Boş Bırakılamaz")]
        public string VideoUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}