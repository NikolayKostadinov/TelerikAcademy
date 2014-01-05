namespace Atm.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CardAccounts")]
    public partial class CardAccount
    {
        public const int CardNumberLenght = 10;
        public const int CardPinLenght = 4;

        private string cardNumber;
        private string cardPin;
        private decimal cardCash;

        [Key]
        public int CardAccountsId { get; internal set; }

        public string CardNumber
        {
            get
            {
                return this.cardNumber;
            }

            set
            {
                if (value.Length < 1 || value.Length > CardNumberLenght)
                {
                    throw new ArgumentException("The lenght of CardNumber must be between 1 and 10 digits.");
                }

                if (value.Length < CardNumberLenght)
                {
                    value = value.PadLeft(CardNumberLenght, ' ');
                }

                this.cardNumber = value;
            }
        }

        public string CardPin
        {
            get
            {
                return this.cardPin;
            }

            set
            {
                if (value.Length != CardPinLenght)
                {
                    throw new ArgumentException("The PIN must be just 4 characters long.");
                }

                this.cardPin = value;
            }
        }

        public decimal CardCash
        {
            get
            {
                return this.cardCash;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The cash value cannot be negative");
                }

                this.cardCash = value;
            }
        }

        public override string ToString()
        {
            string displayResult = 
                string.Format(
                "{0,5} | {1,10} | {2,4} | {3,-10:F2}"
                ,this.CardAccountsId
                ,this.CardNumber
                ,this.CardPin
                ,this.CardCash);

            return displayResult;
        }
    }
}
