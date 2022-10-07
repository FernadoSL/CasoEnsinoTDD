using RefactorTDD.Domain;

namespace RefactorTDD.Test
{
    public class PaymentServiceTest
    {
        [Fact]
        public void PaymentApproved()
        {
            var paymentService = new PaymentService();
            var student = CreateFakeData(1200);

            var fee = paymentService.PayMonthlyFee(student, 1, 1);
            Assert.True(fee.Payed);
        }

        [Fact]
        public void PaymentBlockedByFraud()
        {
            var paymentService = new PaymentService();
            var student = CreateFakeData(1200);

            paymentService.BlockCreditCardByFraud(student, 1);
            var fee = paymentService.PayMonthlyFee(student, 1, 1);
            Assert.False(fee.Payed);
        }

        [Fact]
        public void PaymentBlockedByCredit()
        {
            var paymentService = new PaymentService();
            var student = CreateFakeData(200);

            var fee = paymentService.PayMonthlyFee(student, 1, 1);
            Assert.False(fee.Payed);
        }

        [Fact]
        public void SetAsMainCard()
        {
            var paymentService = new PaymentService();
            var student = CreateFakeData(1200);

            var fee = paymentService.PayMonthlyFee(student, 1, 1);
            paymentService.SetAsMainCard(student, 1);

            Assert.Equal(1, student.MainCard.CardId);
            Assert.True(fee.Payed);
        }

        [Fact]
        public void PaymentApproveWithMainCard()
        {
            var paymentService = new PaymentService();
            var student = CreateFakeData(1200);

            paymentService.SetAsMainCard(student, 1);
            var fee = paymentService.PayMonthlyFeeWithMainCard(student, 1);
            Assert.True(fee.Payed);
        }

        [Fact]
        public void PaymentBlockedByCreditWithMainCard()
        {
            var paymentService = new PaymentService();
            var student = CreateFakeData(600);

            paymentService.SetAsMainCard(student, 1);
            var fee = paymentService.PayMonthlyFeeWithMainCard(student, 1);
            Assert.False(fee.Payed);
        }

        [Fact]
        public void PaymentBlockedByFraudWithMainCard()
        {
            var paymentService = new PaymentService();
            var student = CreateFakeData(1200);

            paymentService.SetAsMainCard(student, 1);
            paymentService.BlockCreditCardByFraud(student, student.MainCard.CardId);
            var fee = paymentService.PayMonthlyFeeWithMainCard(student, 1);
            Assert.False(fee.Payed);
        }

        private static Student CreateFakeData(decimal creditValue)
        {
            MonthlyFee monthlyFee = new MonthlyFee() { FeeId = 1, Value = 1200.0M };
            CreditCard creditCard = new CreditCard() { CardId = 1, Credit = creditValue };

            return new Student()
            {
                FeeList = new List<MonthlyFee>() { monthlyFee },
                CreditCardList = new List<CreditCard>() { creditCard }
            };
        }
    }
}