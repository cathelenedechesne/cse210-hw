using System;

class Program
{
    static void Main(string[] args)
    {
        Address lectureAddress = new Address("123 Lecture Ave", "Lecture City", "Lecture State", "54321");
        Address receptionAddress = new Address("456 Reception St", "Reception City", "Reception State", "98765");
        Address outdoorGatheringAddress = new Address("789 Outdoor Blvd", "Outdoor City", "Outdoor State", "13579");

        Lecture lecture = new Lecture("Lecture on the Art of Lazyness", "From one of the best seller of all time, John Doe will speak on how this book and concept might impact society on a bigger scale.", new DateTime(2024, 4, 5), new TimeSpan(10, 0, 0), lectureAddress, "John Doe", 50);
        Reception reception = new Reception("Jo & Mary's Wedding reception", "You are invited to celebrate Jo and Mary's best day.", new DateTime(2024, 4, 6), new TimeSpan(18, 30, 0), receptionAddress, "lareception@thebest.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Dinner at LaLaLake", "Come enjoy a nice evening at LaLaLake with some food and refreshments!", new DateTime(2024, 4, 7), new TimeSpan(15, 0, 0), outdoorGatheringAddress, "Sunny");


        Console.WriteLine("\nLecture:");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetFullDetails());


        Console.WriteLine("\nReception:");
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails());



        Console.WriteLine("\nOutdoor Gathering:");
        Console.WriteLine(outdoorGathering.GetShortDescription());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetFullDetails());

    }
}
