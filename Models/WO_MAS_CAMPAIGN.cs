using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apicampaign.Models
{
    [Table("WO_MAS_CAMPAIGN")]
    public class WO_MAS_CAMPAIGN
    {
        [Key]
        public int CAMPAIGN_ID { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "")]
        public string CAMPAIGN_CODE { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "")]
        public string CAMPAIGN_DETAIL { get; set; }


    }
}