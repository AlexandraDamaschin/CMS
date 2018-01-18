using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models.CMSModel
{
    [Table("Device")]
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("associatedLocation")]
        public int LocationID { get; set; }

        [Required]
        [StringLength(255)]
        public string Build { get; set; }

        public bool HasError { get; set; }

        public virtual Location associatedLocation { get; set; }


    }
}