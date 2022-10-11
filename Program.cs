using System.Linq;

public interface ICashMachine
{
    int Withdraw(int amount);
    void Insert(int[] cash);
}

public class ATM : ICashMachine
{
    private int Balance { get; set; }

    //private int[] AcceptableBanknotes = { 5, 10, 20, 50, 100 };

    static void Main(string[] args)
    {
        int choice; // User input choice for console
        //int inputArr = new int[] {0};
        ATM atm = new ATM();
        bool isTrue = true;
        while (isTrue)
        {
            Console.WriteLine("\n \n \n");
            Console.WriteLine("********Welcome to ATM Service**************\n");
            Console.WriteLine("1. Check Balance\n");
            Console.WriteLine("2. Withdraw Cash\n");
            Console.WriteLine("3. Deposit Cash\n");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("*********************************************\n\n");
            Console.WriteLine("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Your balance is : {0} ", atm.Balance);
                    break;
                case 2:
                    Console.WriteLine("\nEnter the amount to withdraw: ");
                    atm.Balance = atm.Withdraw(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("\nEnter the amount to deposit: ");
                    atm.Insert(Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32));
                    break;
                case 4:
                    Console.WriteLine("\n Thank you for using the ATM machine");
                    isTrue = false;
                    break;

            }
        }

    }


    public void Insert(int[] cash)
    {

        //bool IsAcceptable = cash.Intersect(AcceptableBanknotes).Any();
        bool IsAcceptable = cash.All(x => x == 5 || x==10 || x== 20 || x == 50 || x ==100);

        if (!IsAcceptable)
        {
            throw new Exception("The only banknotes allowed are 5s, 10s, 20s, 50s and 100s"); // I throw it as an exception here So I could UnitTest it 
        }
        else
        {
            this.Balance += cash.Sum();
        }

        Console.Write(this.Balance);
    }

    public int Withdraw(int amount)
    {
        bool IsAcceptable = (amount == 5 || amount == 10 || amount == 20 || amount == 50 || amount == 100);
        if (!IsAcceptable)
        {
            Console.WriteLine("The only banknotes allowed are 5s, 10s, 20s, 50s and 100s");
        }
        else if (this.Balance - amount < 0m)  // check if their balance after withdrawal wont be below 0
        {
            Console.WriteLine("You dont have enough cash, your balance is : {0} ", this.Balance);
        }
        else
        {
            this.Balance -= amount;
        }
       
        return this.Balance;
    }



}