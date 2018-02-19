using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models.CMSModel
{
    public class Organiser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganiserId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Dispaly Name")]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Contact Details")]
        public string ContactDetails { get; set; }


        public virtual ICollection<Event> Events { get; set; }


    }
}