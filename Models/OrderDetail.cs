using System.ComponentModel.DataAnnotations;

namespace apicampaign.Models
{
    public class OrderDetail
    {
        [Required]
        public string pono { get; set; }
        public string itemid { get; set; }

    }
}