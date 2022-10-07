namespace RefactorTDD.Domain
{
    public class CreditCard
    {
        public int CardId { get; set; }

        public bool BlockByFraud { get; set; }
        
        public decimal Credit { get; set; }
        
        public bool IsMainCard { get; set; }
    }
}
