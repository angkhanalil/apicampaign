namespace apicampaign.Models
{
    public class OrderCampaign
    {
        //  public string pono { get; set; }
        public List<OrderHeader> orderHeaders { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}