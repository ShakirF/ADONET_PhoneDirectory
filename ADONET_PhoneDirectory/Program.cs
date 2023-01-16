using ADONET_PhoneDirectory.Models;
using ADONET_PhoneDirectory;

public class Proqram
{
    public static void Main()
    {
        PersonRepository repositery = new PersonRepository();

        Console.WriteLine("Seçim edin");
        Console.WriteLine("elave etmek ucun     (a)");
        Console.WriteLine("listlemek  ucun      (l)");
        Console.WriteLine("axtarish etmek  ucun (s)");
        Console.WriteLine("cixish etmek ucun    (e)");
        var userInput = Console.ReadLine();
        Console.Clear();
        while (true)
        {
            switch (userInput)
            {
                case "a":
                    Console.WriteLine("Ad,soyad,nomre,email-i daxil edin");
                    var name = Console.ReadLine();
                    var surname = Console.ReadLine();
                    var phone = Console.ReadLine();
                    var email = Console.ReadLine();
                    Console.WriteLine("Elave etmek isteyirsiniz? y/n");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "y":
                            bool result = repositery.Insert(new Person
                            {
                                FirstName = name,
                                LastName = surname,
                                Phone = phone,
                                Email = email,
                            });
                            Console.WriteLine("Elave edilldi");
                            break;
                        case "n":
                            Console.Clear();
                            Console.WriteLine("Elave edilmedi");
                            continue;
                    }
                    break;
                case "l":
                    repositery.Listed();
                    Console.WriteLine("Silmek ucun (d)");
                    Console.WriteLine("Menyuya qayitmaq ucun (m)");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "d":
                            Console.WriteLine("Id-ni daxil edin");
                            repositery.Deleted(Console.ReadLine());
                            Console.Clear();
                            repositery.Listed();
                            break;
                        case "m":
                            Console.Clear();
                            continue;
                    }
                    break;
                case "s":
                    Console.WriteLine("Axarmaq ucun deyer bildirin");
                    repositery.Searcing(Console.ReadLine());
                    break;
                case "e":
                    return;

            }
            Console.WriteLine();
            Console.WriteLine("Seçim edin");
            Console.WriteLine("elave etmek ucun     (a)");
            Console.WriteLine("listlemek  ucun      (l)");
            Console.WriteLine("axtarish etmek  ucun (s)");
            Console.WriteLine("cixish etmek ucun    (e)");
            userInput = Console.ReadLine();
            Console.Clear();

        }




    }
}