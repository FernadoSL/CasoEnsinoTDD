using RefactorTDD.Domain;

namespace RefactorTDD
{
    public class PaymentService
    {
        public MonthlyFee PayMonthlyFee(Student student, int feeId, int cardId)
        {
            var feeToPay = student.FeeList.First(fee => fee.FeeId == feeId);
            var cardToUse = student.CreditCardList.First(card => card.CardId == cardId);

            if (!cardToUse.BlockByFraud && cardToUse.Credit >= feeToPay.Value)
                feeToPay.Payed = true;

            return feeToPay;
        }

        public void SetAsMainCard(Student student, int cardId)
        {
            var cardToUse = student.CreditCardList.First(card => card.CardId == cardId);
            cardToUse.IsMainCard = true;
        }

        public void BlockCreditCardByFraud(Student student, int cardId)
        {
            var cardToBlcok = student.CreditCardList.First(card => card.CardId == cardId);
            cardToBlcok.BlockByFraud = true;
        }

        public MonthlyFee PayMonthlyFeeWithMainCard(Student student, int feeId)
        {
            return this.PayMonthlyFee(student, feeId, student.MainCard.CardId);
        }
    }
}
