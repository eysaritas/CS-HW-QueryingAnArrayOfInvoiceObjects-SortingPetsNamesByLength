using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Querying_an_Array_of_Invoice_Objects
{
	//Fatura classı
	class Invoice
	{
		public int PartNumber { get; set; }
		public string PartDescription { get; set; }
		public int Quantity { get; set; }
		public double Price  { get; set; }

		//4 parametreli Invoice constructerı
		public Invoice(int partNumber, string partDescription, int quantity, double price)
		{
			this.PartNumber = partNumber;
			this.PartDescription = partDescription;
			this.Quantity = quantity;
			this.Price = price;
		} 

	}
	internal class Program
	{
		static void Main(string[] args)
		{
			//Tablo bilgileri nesneler halinde dizi elemanları oluyor.
			Invoice[] invoice = new Invoice[]
			{
				new Invoice  (83, "Electric sander", 7, 57.98 ),
				new Invoice  (24, "Power saw", 18, 99.99 ),
				new Invoice  (7, "Sledge hammer", 11, 21.50),
				new Invoice  (77, "Hammer", 76, 11.99),
				new Invoice  (39, "Lawn mower", 3, 79.50),
				new Invoice  (68, "Screwdriver", 106, 6.99),
				new Invoice  (56, "Jig saw", 21, 11.00),
				new Invoice  (3, "Wrench", 34, 7.50)
			};

			//A) Sorted the Invoice objects by PartDescription 
			var FilteredPartDescription = from items in invoice
								  orderby items.PartDescription
								  select items.PartDescription;
			
			//Foreach ile LINQ ile filtrelenenler yazdırılıyor.
			foreach (var item in FilteredPartDescription)
			{
				Console.WriteLine($"Part Description : {item}");
			}

            Console.WriteLine("\n*************************************************\n");

            //B) Sorted the Invoice objects by Price
            var FilteredPrice = from items in invoice
								orderby items.Price
								select items;
            
			//Foreach ile LINQ ile filtrelenenler yazdırılıyor.
            foreach (var item in FilteredPrice)
			{
				Console.WriteLine($"Price : {item.Price}");
			}

            Console.WriteLine("\n*************************************************\n");

            //C) Selected the PartDescription and Quantity and sorted the results by Quantity
            var FilteredQuantity = from items in invoice
								   orderby items.Quantity
								   select new { items.PartDescription, items.Quantity };
            
			//Foreach ile LINQ ile filtrelenenler yazdırılıyor.					   
            foreach (var item in FilteredQuantity)
            {
				Console.WriteLine(item);
            }

            Console.WriteLine("\n*************************************************\n");

            //D) Selected PartDescription, InvoiceTotal and sorted the results by InvoiceTotal
            var flterdTotal = from items in invoice
						let InvoiceTotal = items.Quantity * items.Price
						orderby InvoiceTotal
						select new { items.PartDescription, InvoiceTotal };
            
			//Foreach ile LINQ ile filtrelenenler yazdırılıyor.
            foreach (var item in flterdTotal)
			{
				Console.WriteLine(item);
			}

            Console.WriteLine("\n*************************************************\n");

            //E) Using the results of the LINQ query in part (d), select the InvoiceTotals in the range $200 to $500.
            var condition200to500 = from items in flterdTotal
									where 200 < items.InvoiceTotal && items.InvoiceTotal < 500
									select items;
            
			//Foreach ile LINQ ile filtrelenenler yazdırılıyor.
            foreach (var item in condition200to500)
			{
				Console.WriteLine(item);
			}

			Console.ReadLine();
		}
	}
}
