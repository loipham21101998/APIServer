namespace DigitalPhotoPrinting.Models
{
    public class PrintOrder
    {
        public int AccountId { get; set; }
        public string ImageName { get; set; }
        public string SizeName { get; set; }
        public string MaterialName { get; set; }    
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        //public double Total { get; set; }   
    }
}
