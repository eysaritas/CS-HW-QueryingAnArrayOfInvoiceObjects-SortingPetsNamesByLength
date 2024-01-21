using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sorting_Pets_Names_by_Length
{
	internal class Program
	{
        //AddInputPetNames fonksiyonu döngü ifadesi break komutunu kullanana kadar devam eder. Kullanıcının listeye ekleme işlemi bittiğinde 'Quit' yazması gerekir. Kullanıcı Pet ismini listeye ekler.
        //Eğer eklenen Pet ismi Alfabetik ve boşluktan oluşmuyorsa (kontrol IsValidName fonksiyonu ile yapılır) hata mesajı bastırılır.
        static void AddInputPetNames(List<string> petNames)
        {
            while (true)
            {
                Console.WriteLine("Enter the pet name(or 'quit' to exit) : ");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                if (IsValidName(input))
                    petNames.Add(input);
                else
                    Console.WriteLine("Invalid pet name! Pet name should not contain numbers or special characters.");
            }
        }
        //IsValidName fonksiyonu Pet ismi Alfabetik ve boşluktan oluşma durumunu kontrol eder. Regex metin tabanlı verileri aramak için özel bir ifade ismidir.
        //Girilen metin ifadesi a-z, A-Z ve \s (space karakteri)'den aykırı bir karaktere sahipse return değeri false döner.
        static bool IsValidName(string name)
        {
            return (!Regex.IsMatch(name, @"[^a-zA-Z\s]"));
        }

        static void Main(string[] args)
		{
            //petNames isimli liste tanımı
			List<string> petNames = new List<string>();

			AddInputPetNames(petNames);

            //A) Sorted the List in ascending order on the basis of number of characters in the name.
            var sortedNameSize = from count in petNames
								 orderby count.Length
								 select count;
			
            Console.WriteLine("\n******************************************");
            Console.WriteLine("Pet names listed in ascending order : \n");
            
            foreach (var name in sortedNameSize)
			{
				Console.WriteLine(name);
			}

            //B) Sorted the List in ascending order on the basis of number of characters in the name.
            var sortedDescendingNameSize = from count in petNames
                                           orderby count.Length descending
                                           select count;
            
            Console.WriteLine("\n******************************************");
            Console.WriteLine("Pet Names listed in descending order : \n");
            
            foreach (var name in sortedDescendingNameSize)
            {
                Console.WriteLine(name);
            }

            //C) Pet Names listed in ascending order after removing duplicate names
            var sortedDuplicateNameSize = from count in petNames
                                          orderby count.Length
                                          select count;
            
            Console.WriteLine("\n******************************************");
            Console.WriteLine("Pet Names listed in ascending order after removing duplicate names : \n");
            
            foreach (var name in sortedDuplicateNameSize.Distinct())
            { 
                Console.WriteLine(name);
            }

            Console.ReadLine();
		}
	}
}
