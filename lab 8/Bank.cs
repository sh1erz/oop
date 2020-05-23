
namespace oopsh8
{
    public class BankAccount
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;
        private double _cash;
        public double GetCash => _cash;
        private bool Flag { get; set; }
        private static int account = 0;
        
                    
        public BankAccount()
        {
            Notify?.Invoke("Вы создали аккаунт"); 
            Flag = true;
            account += 1;
        }
        
        public BankAccount(double cash)
        {
            if (cash < 0)
            {
                Notify?.Invoke($"Вы пытаетесь создать аккаунт с: {cash}"); 
            }
            else
            {
                Flag = true;
                _cash = cash;
                account += 1;
            }
        }
        
        public void AddToAcc(double cash)
        {
            if (cash > 0 && Flag)
            {
                _cash += cash;
                Notify?.Invoke($"На счет поступило: {cash}");
            }
        }
        
        public void SubstractFromAcc(double cash)
        {
            if (_cash < cash || cash < 0 || !Flag)
            {
                Notify?.Invoke($"На счету: {_cash}, попытка снять: {cash}"); 
            }
            else
            {
                _cash -= cash;
            }
        }
        
        public void DeleteAcc()
        {
            Notify?.Invoke($"Ваш аккаунт закрыт");
            _cash = 0;
            Flag = false;
            account -= 1;
        }

        public static int StaticAccountsAmount()
        {
            return account;
        }

        public int AccountsAmount()
        {
            return account;
        }
    }
}