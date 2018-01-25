using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.CMSModel
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Town { get; set; }

        [StringLength(255)]
        public string County { get; set; }

        public float Lat { get; set; }

        public float Lng { get; set; }


        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Device> Devices { get; set; }

    }
}