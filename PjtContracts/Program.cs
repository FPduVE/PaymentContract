using System;
using System.Globalization;
using PjtContracts.Entities;
using PjtContracts.Services;

namespace PjtContracts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value:");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(number, date, totalValue);

            ContractService contractService = new ContractService(new PayPalService());
            contractService.ProcessContract(myContract, months);


            Console.WriteLine("Installment:");
            foreach (Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }

            


        }
    }
}

