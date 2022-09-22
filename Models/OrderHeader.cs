using System.ComponentModel.DataAnnotations;


namespace apicampaign.Models
{
    public class OrderHeader
    {
        [Required]
        [StringLength(50, ErrorMessage = "PO NO is")]
        public string pono { get; set; }
        public string billid { get; set; }
        public string orderdate { get; set; }
    }
}