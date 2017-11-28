using System;
using System.Text;
using System.IO;

namespace Bankomat
{
   public class Account
    {   
        public double Balance;
        public string Pass;
        public double Balanc;
        private int popitka = 3;

        public void ReadClients()
        {
            Operations oop = new Operations();
            int count = 0;
            using (StreamReader lines = new StreamReader(@"F:\VS\Bankomat\BankDataBase.txt"))
            {
                String line;
                while ((line = lines.ReadLine()) != null)
                {
                    count++;
                }
            }
            Client[] array = new Client[count];
            using (StreamReader reader = new StreamReader(@"F:\VS\Bankomat\BankDataBase.txt", Encoding.Default))
            {
                for (int j = 0; j < count; j++)
                {
                    array[j] = new Client(reader.ReadLine().Split('|'));
                }
            }
            Console.Clear();
            Console.WriteLine("Информация о всех клиентах: ");
            foreach (Client s in array)
                s.Show();
            Console.WriteLine("------------------------------");
            Console.WriteLine("0. Выход");
            Console.Write("Введите номер клиента: ");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 0)
            {
                Console.Clear();
                oop.FirstDisplay();
            }
            else
            {
                Console.Clear();
                Pass = array[input - 1].Password;
                Balanc = array[input - 1].Balance;
            }
        }

        public void InputPIN()
        {
            Console.Clear();
            int i = 0;
            do
            {
                i++;
                Console.WriteLine("Введите Пин-код");
                if (popitka == 3 || popitka == 2)
                    Console.WriteLine("Осталось " + popitka + " попытки");
                else
                    Console.WriteLine("Осталось " + popitka + " попытка");
                popitka--;
                string InputPassword = Console.ReadLine();
                if (InputPassword == Pass)
                {
                    Operations operat = new Operations();
                    operat.Operation(Balanc, Pass);
                }
                else if (InputPassword != Pass && i == 3)
                {
                    Console.WriteLine("Карточка заблокирована");
                    Console.ReadKey();
                    return;
                }
            } while (i < 3);
        }

        public void ChangeBalance(double NewBalance, double Balanc)
        {
            string NewBalanceStr = NewBalance.ToString();
            string OldBalanceStr = Balanc.ToString();

            string chngbalout = string.Empty;
            using (StreamReader reader = File.OpenText(@"F:\VS\Bankomat\BankDataBase.txt"))
            {
                chngbalout = reader.ReadToEnd();
            }
            chngbalout = chngbalout.Replace(OldBalanceStr, NewBalanceStr);

            using (StreamWriter file = new StreamWriter(@"F:\VS\Bankomat\BankDataBase.txt"))
            {
                file.Write(chngbalout);
            }
        }
        public void ChangePassword(string NewPassword, string Pass)
        {
            string chngpas = string.Empty;
           
            using (StreamReader reader1 = File.OpenText(@"F:\VS\Bankomat\BankDataBase.txt"))
            {
                chngpas = reader1.ReadToEnd(); 
            }
            chngpas = chngpas.Replace(Pass, NewPassword);

            using (StreamWriter file = new StreamWriter(@"F:\VS\Bankomat\BankDataBase.txt"))
            {
                file.Write(chngpas);
            }
        }
    }

    public struct Client
    {
            public int Id;
            public string Name;
            public string Password;
            public double Balance;
            public Client(string[] args)
            {
                Id = int.Parse(args[0]);
                Name = args[1];
                Password =args[2];
                Balance = double.Parse(args[3]);
            }
            public void Show()
            {
                Console.WriteLine("{0}.{1}", Id, Name);
            }

    }
}



