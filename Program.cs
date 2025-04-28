using System;

class BankMenu
{
    private BankAccount clientAccount = new BankAccount();
    public void MainMenu()
    {
        int choice;

        do
        {
            Console.Write("===================================================\n" +
                          "                 << ATM Services >>                \n" +
                          "===================================================\n" +
                          "  #1. Deposit money             #3. Check balance  \n" +
                          "  #2. Withdraw cash             #4. Exit           \n" +
                          "===================================================\n\n" +

                          "Enter operation number: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Clear();
                Console.Write("===================================================\n" +
                              "          Error! Invalid number operation.         \n" +
                              "===================================================\n");
                WaitForEnter();
                continue;
            }

            switch (choice)
            {
                case 1:
                    DepositOption();
                    break;

                case 2:
                    WithdrawOption();
                    break;

                case 3:
                    CheckBalanceOption();
                    break;

                case 4:
                    break;

                default:
                    Console.Clear();
                    Console.Write("===================================================\n" +
                                  "     Invalid number operation. Please try again.   \n" +
                                  "===================================================\n");
                    WaitForEnter();
                    break;
            }

        } while (choice != 4);

        Console.Clear();
        Console.Write("===================================================\n" +
                      "             Shutting down the program...          \n" +
                      "===================================================\n");
    }

    void DepositOption()
    {
        do
        {
            Console.Clear();
            Console.Write("===================================================\n" +
                          "                 > Deposit money <                 \n" +
                          "===================================================\n\n" +

                          "Enter amount: ");

            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.Clear();
                Console.Write("===================================================\n" +
                              "      Error! The entered value in not a number.    \n" +
                              "===================================================\n");

                WaitForEnter();
                break;
            }

            if (value > 0)
            {
                clientAccount.AddMoney(value);

                Console.Write("\n===================================================\n");
                Console.Write($"+ Amound of {value} UAH \n");
                Console.Write($"  successfully added to your balance!\n");
                Console.Write("===================================================\n");

                WaitForEnter();
            }
            else if (value < 0)
            {
                Console.Clear();
                Console.Write("===================================================\n" +
                              "           Error! Amount cannot be negative.       \n" +
                              "===================================================\n");

                WaitForEnter();
                break;
            }
            else
            {
                Console.Clear();
                Console.Write("===================================================\n" +
                              "            Error! Amount cannot be zero.          \n" +
                              "===================================================\n");

                WaitForEnter();
                break;
            }

            return;

        } while (true);
    }

    void WithdrawOption()
    {
        Console.Clear();
        Console.Write("===================================================\n" +
                      "                 > Withdraw cash <                 \n" +
                      "===================================================\n\n" +

                      "Enter amount: ");

        if (!double.TryParse(Console.ReadLine(), out double value))
        {
            Console.Clear();
            Console.Write("===================================================\n" +
                          "      Error! The entered value is not a number.    \n" +
                          "===================================================\n");

            WaitForEnter();
            return;
        }
        else if (value < 0)
        {
            Console.Clear();
            Console.Write("===================================================\n" +
                          "          Error! Amount cannot be negative.        \n" +
                          "===================================================\n");

            WaitForEnter();
            return;
        }
        else if (value == 0)
        {
            Console.Clear();
            Console.Write("===================================================\n" +
                          "        Error! Withdraw amount cannot be zero.     \n" +
                          "===================================================\n");

            WaitForEnter();
            return;
        }


        if (value <= clientAccount.CheckBalance())
        {
            clientAccount.WithdrawMoney(value);
            Console.Write("\n===================================================\n");
            Console.Write($"- Amount of {value} UAH                             \n");
            Console.Write($"  successfully withdrawn from your account!         \n");
            Console.Write("===================================================\n");

            WaitForEnter();
        }
        else
        {
            Console.Clear();
            Console.Write("===================================================\n" +
                          "     Error! Insufficient balance for withdrawal.   \n" +
                          "===================================================\n");

            WaitForEnter();
            return;
        }
    }

    void CheckBalanceOption()
    {
        Console.Clear();
        Console.Write("===================================================\n" +
                      "                  Account Balance                  \n" +
                      "===================================================\n\n" +

                     $"Account number:   {clientAccount.TakeAccountNumber()}\n" +
                     $"Current balance:  {clientAccount.CheckBalance()} UAH        \n\n" +

                      "===================================================\n\n");

        WaitForEnter();
        return;
    }

    static void WaitForEnter()
    {
        Console.Write("\nPress Enter for continue...");
        Console.ReadLine();
        Console.Clear();
    }
}

class BankAccount
{
    private readonly string AccountNumber = "UA12345678901234567890";
    private double Balance = 0;

    public void AddMoney(double value)
    {
        if (value > 0)
            Balance += value;
        else
        {
            Console.Clear();
            Console.Write("===================================================\n" +
                          "            Error! Invalid deposit amount.         \n" +
                          "===================================================\n");
            Console.ReadLine();
            Console.Clear();
        }
    }
    public void WithdrawMoney(double value)
    {
        if (value <= Balance)
            Balance -= value;
        else
        {
            Console.Clear();
            Console.Write("===================================================\n" +
                          "     Error! Insufficient balance for withdrawal.   \n" +
                          "===================================================\n");
        }
    }
    public double CheckBalance()
    {
        return Balance;
    }
    public string TakeAccountNumber()
    {
        return AccountNumber;
    }
}

class Program
{
    static int Main()
    {
        BankMenu DigitATM = new BankMenu();
        DigitATM.MainMenu();

        return 0;
    }
}