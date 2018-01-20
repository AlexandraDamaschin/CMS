using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.CMSModel
{
    [Table("Device")]
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("AssociatedLocation")]
        public int LocationId { get; set; }

        [Required]
        [StringLength(255)]
        public string Build { get; set; }

        public bool HasError { get; set; }

        public virtual Location AssociatedLocation { get; set; }


    }
}