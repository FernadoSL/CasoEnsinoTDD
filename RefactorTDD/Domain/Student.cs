namespace RefactorTDD.Domain
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public List<MonthlyFee> FeeList { get; set; }


        public List<CreditCard> CreditCardList { get; set; }

        public CreditCard MainCard
        {
            get
            {
                return this.CreditCardList.First(card => card.IsMainCard);
            }
        }

        public Student()
        {
            this.FeeList = new List<MonthlyFee>();
            this.CreditCardList = new List<CreditCard>();
        }
    }
}
