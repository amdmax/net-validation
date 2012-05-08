namespace DataValidation.Models
{
    public class LineItem: IEntity
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public decimal PricePerItem { get; set; }

        public string Name { get; set; }

        public decimal GetLineItemPrice()
        {
            return Qty*PricePerItem;
        }
    }
}