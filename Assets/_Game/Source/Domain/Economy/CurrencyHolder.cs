using UniRx;

namespace _Game.Source.Domain
{
    public class CurrencyHolder
    {
        public ReactiveProperty<Currency> CurrencyProperty { get; }
        
        public CurrencyHolder(Currency currency)
        {
            CurrencyProperty = new ReactiveProperty<Currency>(currency);
        }

        public void AddCoins(int coinsAmount)
        {
            CurrencyProperty.Value += new Currency(){Coins = coinsAmount};
        }

        public void SubCoins(int coinsAmount)
        {
            AddCoins(-coinsAmount);
        }

        public void SubCurrency(Currency value)
        {
            throw new System.NotImplementedException();
        }

        public bool IsEnough(Currency currency)
        {
            throw new System.NotImplementedException();
        }
    }
}