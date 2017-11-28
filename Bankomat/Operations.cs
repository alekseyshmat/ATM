using System;

namespace Bankomat
{
    class Operations : Account
    {
        public double NewBalance;
        public string NewPassword;

        public void FirstDisplay()
        {
            Console.WriteLine("  Сделайте выбор -> ");
            Console.WriteLine("\n        1.Начать работать \n        2.Завершить работу ");
            int insert = Convert.ToInt32(Console.ReadLine());
            switch (insert)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Выбор клиента банка: ");
                    ReadClients();
                    InputPIN();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        private void Insert()
        {
            Console.Clear();
            Console.WriteLine("Выбор клиента банка: ");
            ReadClients();
            InputPIN();
        }
        private void NewPas()
        {
            Console.Write("Введите новый Пин-код --> ");
            NewPassword = Console.ReadLine();
            Console.WriteLine("Пин-код изменен!");          
        }
        private void CashIN()
        {
            Console.Clear();
            Console.WriteLine("\tВВЕДИТЕ СУММУ");
            int summa = Convert.ToInt32(Console.ReadLine());
            NewBalance += summa;
            Console.WriteLine("На баланс зачислено " + summa + " BYN");
            Console.ReadKey();
        }
        private void CashOut()
        {
            Console.Clear();
            Console.WriteLine("\tВЫБЕРИТЕ СУММУ");
            Console.WriteLine("1. 5  BYN                3. 50  BYN  ");
            Console.WriteLine("2. 10 BYN                4. 100 BYN  ");
            Console.WriteLine("5. 20 BYN                6. 200 BYN  ");
            Console.WriteLine("7. Другая сумма");
            int operation = Convert.ToInt32(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    if ((NewBalance - 5) >= 0)
                    {
                        NewBalance -= 5;
                        Console.WriteLine("С баланса списано 5 BYN");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    if ((NewBalance - 10) >= 0)
                    {
                        NewBalance -= 10;
                        Console.WriteLine("С баланса списано 10 BYN");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    if ((NewBalance - 50) >= 0)
                    {
                        NewBalance -= 50;
                        Console.WriteLine("С баланса списано 50 BYN");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств");
                        Console.ReadKey();
                    }
                    break;
                case 4:
                    if ((NewBalance - 100) >= 0)
                    {
                        NewBalance -= 100;
                        Console.WriteLine("С баланса списано 100 BYN");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств");
                        Console.ReadKey();
                    }
                    break;
                case 5:
                    if ((NewBalance - 20) >= 0)
                    {
                        NewBalance -= 20;
                        Console.WriteLine("С баланса списано 20 BYN");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств");
                        Console.ReadKey();
                    }
                    break;
                case 6:
                    if ((NewBalance - 200) >= 0)
                    {
                        NewBalance -= 200;
                        Console.WriteLine("С баланса списано 200 BYN");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств");
                        Console.ReadKey();
                    }
                    break;
                case 7:
                    Console.WriteLine("Введите сумму");
                    int summa = Convert.ToInt32(Console.ReadLine());
                    if ((NewBalance - summa) >= 0)
                    {
                        NewBalance -= summa;
                        Console.WriteLine("С баланса списано " + summa + " BYN");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств");
                        Console.ReadKey();
                    }
                    break;
                default:
                    break;
            }
        }
        private void Cassh()
        {
            Console.Clear();
            Console.WriteLine("На карте осталось " + NewBalance + " BYN");
            Console.ReadKey();
        }
        public void Operation(double Balanc, string Pass)
        {
            NewBalance = Balanc;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tВЫБЕРИТЕ ОПЕРАЦИЮ");
                Console.WriteLine("1.Пополнение счёта               3.Выдача наличных");
                Console.WriteLine("2.Остаток на счёте               4.Смена пароля");
                Console.WriteLine("                5.Завершить сеанс");
                 int operation = Convert.ToInt32(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        CashIN();
                        break;
                    case 2:
                        Cassh();
                        break;
                    case 3:
                       CashOut();
                        break;
                    case 4:
                        NewPas();
                        ChangeBalance(NewBalance, Balanc);
                        ChangePassword(NewPassword, Pass);
                        Insert();
                        break;
                    case 5:
                        ChangeBalance(NewBalance, Balanc);
                        ChangePassword(NewPassword, Pass);
                        Insert();
                        break;
                }
            }
        }
        
      
    }
}
