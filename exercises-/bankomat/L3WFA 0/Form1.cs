class Person
{
    public string Name { get; set; }
    public int PinNumber { get; set; }
    public Account newAccount = new Account();
    public List<Account> MyAccounts = new List<Account>();

    public static void CreateAccount(Person currentPerson)
    {
        Account newAccount = new Account();
        Console.WriteLine("What type of account do you want to create?");
        Console.WriteLine("1: Payment account");
        Console.WriteLine("2: Savings account");
        Console.WriteLine("3: E-shopping account");
        int userChoice = ErrorHandling.IsNumber(Console.ReadLine());


        switch (userChoice)
        {
            case 1:
                newAccount.TypAvKonto = "Payments account";
                newAccount.Balance = 0;
                break;
            case 2:
                newAccount.TypAvKonto = "Savings account";
                newAccount.Balance = 0;
                break;
            case 3:
                newAccount.TypAvKonto = "E-shopping account";
                newAccount.Balance = 0;
                break;
            default:
                Console.WriteLine("You did not enter a correct choice, please try again");
                CreateAccount(currentPerson);
                break;
        }

        currentPerson.MyAccounts.Add(newAccount);
    }
    public static void RemoveAccount(Person currentPerson)
    {
        Console.WriteLine("Which account do you wish to remove?");
        foreach (var item in currentPerson.MyAccounts)
        {
            int i = 1;
            Console.WriteLine("{0} - {1} with the balance of {2}", i, item.TypAvKonto, item.Balance);
            i++;
        }
        Console.WriteLine("Which account do you wish to remove?");
        int userChoice = ErrorHandling.IsNumber(Console.ReadLine());
        currentPerson.MyAccounts.RemoveAt(userChoice);

    }
}
class Account
{
    public string TypAvKonto { get; set; }
    public int Balance { get; set; }

    public static void DisplayAccountInfo(Person currentPerson)
    {
        for (int i = 0; i < currentPerson.MyAccounts.Count(); i++)
        {
            Console.WriteLine("Index: {0}, accountname {1} , Balance {2}", i, currentPerson.MyAccounts[i].TypAvKonto, currentPerson.MyAccounts[i].Balance);
        }

    }
    public static void AddMoney(Person currentPerson)

    {
        int i = 0;
        Console.WriteLine("Which account do you wish to add money to?");
        DisplayAccountInfo(currentPerson);
        int userChoice;
        bool success = int.TryParse(Console.ReadLine(), out userChoice);
        Console.WriteLine("How much do you wish to add?");
        int addMoney;
        success = int.TryParse(Console.ReadLine(), out addMoney);
        foreach (var item in currentPerson.MyAccounts)
        {

            if (i == userChoice)
                item.Balance = item.Balance + addMoney;
            i++;
        }
    }
    public static void WithdrawMoney(Person currentPerson)
    {
        {
            int i = 0;
            Console.WriteLine("Which account do you wish to add money to?");
            DisplayAccountInfo(currentPerson);
            int userNumber = ErrorHandling.IsNumber(Console.ReadLine());
            Console.WriteLine("How much do you wish to add?");
            int withdrawMoney = ErrorHandling.IsNumber(Console.ReadLine());
            foreach (var item in currentPerson.MyAccounts)
            {

                if (i == userNumber)
                    item.Balance = item.Balance - withdrawMoney;
                i++;
            }
        }
    }
    public static void RemoveAccount(Person currentPerson)
    {
        int i = 0;
        int temporaryBalance = 0;
        DisplayAccountInfo(currentPerson);
        Console.WriteLine("Which account index do you wish to remove?");
        int userNumber = ErrorHandling.IsNumber(Console.ReadLine());
        foreach (var item in currentPerson.MyAccounts)
        {
            if (i == userNumber)
                if (item.Balance > 0)
                    temporaryBalance = item.Balance;
            i++;
        }
        i = 0;
        currentPerson.MyAccounts.RemoveAt(userNumber);
        if (temporaryBalance != 0)
        {
            Console.WriteLine("The account you closed had a balance of {0}, which of your other accounts do you wish to add that to?", temporaryBalance);
            DisplayAccountInfo(currentPerson);
            userNumber = ErrorHandling.IsNumber(Console.ReadLine());
            foreach (var item in currentPerson.MyAccounts)
            {
                if (i == userNumber)
                    item.Balance = item.Balance + temporaryBalance;
                i++;
            }
        }
    }
}
class UserCommunication
{
    public static void WelcomeUser()
    {
        Console.WriteLine("Welcome to Kevins Bankingsystem");
    }
    public static void FirstMenue()
    {
        Console.WriteLine("For [E]xisting customers, press E");
        Console.WriteLine("for [N]ew customers? press N");
        string userChoice = ErrorHandling.FirstMenueChoice(Console.ReadLine());
        if (userChoice.ToLower() == "e")
            ExistingCustomersMenue();
        else
            NewCustomersMenue();
    }
    public static void ExistingCustomersMenue()
    {
        Console.WriteLine("To access your account, please login by writing your name");
        Person currentPerson = ErrorHandling.IsCustomer();

        Console.WriteLine("To [V]iew current accounts and balances, press V");
        Console.WriteLine("To create a [N]ew account, press N");
        Console.WriteLine("To [C]lose one or more accounts, press C");
        Console.WriteLine("To [L]og out, press L");
        string userChoice = Console.ReadLine();
        userChoice = ErrorHandling.SecondMenueChoice(userChoice);
        ExistingCustomerSubMenue(userChoice, currentPerson);


    }
    public static void ExistingCustomersMenue(Person currentPerson)
    {
        bool play = true;
        do
        {
            Console.WriteLine("To [V]iew current accounts and balances, press V");
            Console.WriteLine("For [N]ew account, press N");
            Console.WriteLine("To [C]lose one or more accounts, press C");
            Console.WriteLine("To [L]og out, press L");
            string userChoice = Console.ReadLine();
            userChoice = ErrorHandling.SecondMenueChoice(userChoice);
            ExistingCustomerSubMenue(userChoice, currentPerson);

        } while (play);

    }
    public static void AddOrSubtractMoney(Person currentPerson)
    {
        Console.WriteLine("Do you want to [A]dd or [W]ithdraw money?");
        string userChoice = Console.ReadLine();
        if (userChoice.ToLower() == "a")
            Account.AddMoney(currentPerson);
        else if (userChoice.ToLower() == "w")
            Account.WithdrawMoney(currentPerson);
    }

    public static void ExistingCustomerSubMenue(string userChoice, Person currentPerson)
    {
        if (userChoice == "v")
        {
            Account.DisplayAccountInfo(currentPerson);
            AddOrSubtractMoney(currentPerson);

        }
        else if (userChoice == "n")
        {
            Person.CreateAccount(currentPerson);
        }
        else if (userChoice == "c")
        {
            Account.RemoveAccount(currentPerson);
        }
        else
        {
            UserInteraction();
        }
    }
    public static void NewCustomersMenue()
    {
        Person currentPerson = CreateNewUser();
        Bank.BankCustomers.Add(currentPerson);
        ExistingCustomersMenue(currentPerson);
    }

    public static void UserInteraction()
    {
        WelcomeUser();
        FirstMenue();

    }
    public static Person CreateNewUser()
    {
        Person currentPerson = new Person();
        Console.WriteLine("Please write your name");
        currentPerson.Name = Console.ReadLine();
        Console.WriteLine("Please write your 4 digit PinNumber");
        currentPerson.PinNumber = ErrorHandling.GetPinNumber();
        return currentPerson;
    }


}
class ErrorHandling
{
    public static int IsNumber(string userChoice)
    {
        int tempNr;
        bool success = int.TryParse(userChoice, out tempNr);
        while (!success)
        {
            Console.WriteLine("Du angav inte ett korrekt val, försök igen");
            success = int.TryParse(Console.ReadLine(), out tempNr);
        }
        return tempNr;
    }
    public static Person IsCustomer()
    {
        string username = Console.ReadLine();
        Person kalle = new Person();
        int pin = ErrorHandling.GetPinNumber();
        foreach (var item in Bank.BankCustomers)
        {
            if (username == item.Name && pin == item.PinNumber)
            {
                return item;
            }
        }
        IsCustomer();
        return kalle;
    }
    public static string FirstMenueChoice(string userChoice)
    {
        bool loop = true;
        do
        {
            if (userChoice.ToLower() == "e" || userChoice.ToLower() == "n")
                return userChoice;
            else
            {
                Console.WriteLine("You did not enter a valid menue choice, please try again");
                userChoice = Console.ReadLine();
            }

        } while (loop);
        return userChoice;
    }
    public static string SecondMenueChoice(string userChoice)
    {
        userChoice.ToLower();
        bool loop = true;
        do
        {
            if (userChoice.ToLower() == "v" || userChoice.ToLower() == "n" || userChoice.ToLower() == "c" || userChoice.ToLower() == "l")
                return userChoice;
            else
            {
                Console.WriteLine("You did not enter a valid menue choice, please try again");
                userChoice = Console.ReadLine();
            }

        } while (loop);
        return userChoice;
    }
    public static int GetPinNumber()
    {
        bool success = true;
        int pin = 0;
        do
        {
            string pinNumber = Console.ReadLine();
            if (pinNumber.Count() > 4)
                Console.WriteLine("Your pin is to long");
            else if (pinNumber.Count() < 4)
                Console.WriteLine("Your pin is to short");
            else if (pinNumber.Count() == 4)
            {
                success = int.TryParse(pinNumber, out pin);
                if (!success)
                    Console.WriteLine("Not all the 4 characters you entered were digits, please try again");
                if (success)
                    success = false;

            }

        } while (success);
        return pin;
    }
}
class Bank
{
    public static List<Person> BankCustomers = new List<Person>();

}
class Program
{
    static void Main(string[] args)
    {
        UserCommunication.FirstMenue();
    }
}