using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.CMSModel
{
    [Table("EventCategory")]
    public class EventCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventCategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}