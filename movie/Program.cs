using System;

class MovieTicketPurchase
{
    static void Main(string[] args)
    {
        // Get user's name
        string userName = GetUserName();

        // Get user's age
        int userAge = GetUserAge();

        // Select ticket type
        (string ticketType, double originalPrice) = SelectTicketType(userAge);

        // Apply discount code
        double finalPrice = ApplyDiscount(originalPrice);

        // Print summary
        PrintSummary(userName, ticketType, originalPrice, finalPrice);
    }

    static string GetUserName()
    {
        string name;
        do
        {
            Console.Write("Please enter your name: ");
            name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty. Please try again.");
            }
        } while (string.IsNullOrEmpty(name));

        return name;
    }

    static int GetUserAge()
    {
        int age;
        while (true)
        {
            Console.Write("Please enter your age: ");
            if (int.TryParse(Console.ReadLine(), out age) && age > 0)
            {
                return age;
            }
            else
            {
                Console.WriteLine("Age must be a positive integer. Please try again.");
            }
        }
    }

    static (string, double) SelectTicketType(int age)
    {
        while (true)
        {
            Console.WriteLine("\nSelect Ticket Type:");
            Console.WriteLine("1: Child's Ticket (under 12 years old) - €5");
            Console.WriteLine("2: Adult Ticket (12–64 years old) - €10");
            Console.WriteLine("3: Senior Ticket (65 years and older) - €7");
            Console.Write("Enter the number of the ticket type you want: ");

            string ticketSelection = Console.ReadLine();
            switch (ticketSelection)
            {
                case "1":
                    if (age < 12)
                        return ("Child's Ticket", 5);
                    break;
                case "2":
                    if (age >= 12 && age <= 64)
                        return ("Adult Ticket", 10);
                    break;
                case "3":
                    if (age >= 65)
                        return ("Senior Ticket", 7);
                    break;
                default:
                    Console.WriteLine("Error: Invalid selection. Please try again.");
                    continue;
            }
            Console.WriteLine("Error: The selected ticket type does not match your age. Please try again.");
        }
    }

    static double ApplyDiscount(double price)
    {
        Console.Write("Do you have a discount code? (Type 'none' if you don't): ");
        string discountCode = Console.ReadLine().Trim();

        if (discountCode.Equals("SALE20", StringComparison.OrdinalIgnoreCase))
        {
            double discount = price * 0.20;
            double finalPrice = price - discount;
            Console.WriteLine($"Discount applied: €{discount:F2}");
            return finalPrice;
        }
        else if (discountCode.Equals("none ", StringComparison.OrdinalIgnoreCase))
        {
            return price;
        }

        Console.WriteLine("Invalid discount code. No discount applied.");
        return price;
    }

    static void PrintSummary(string userName, string ticketType, double originalPrice, double finalPrice)
    {
        Console.WriteLine("\n--- Summary ---");
        Console.WriteLine($"User Name: {userName}");
        Console.WriteLine($"Selected Ticket Type: {ticketType}");
        Console.WriteLine($"Original Ticket Price: €{originalPrice:F2}");
        Console.WriteLine($"Final Price after Discount: €{finalPrice:F2}");
    }
}