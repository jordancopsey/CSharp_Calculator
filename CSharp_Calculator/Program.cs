using CalculatorLibrary;
namespace CalculatorProgram
{
    class Program
    {
        static void Main(String[] args)
        {
            bool endApp = false;

            //Display title as the C# console Calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                // declare variables and set to empty
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.WriteLine("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.WriteLine("Invalid Input. Enter an integer Value: ");
                    numInput1 = Console.ReadLine();
                }


                // Ask the user to type the second number.
                Console.WriteLine("Type a number, and then press Enter");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.WriteLine("Invalid Input. Enter an integer Value: ");
                    numInput2 = Console.ReadLine();
                }

                // ask the user to choose an option.
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Mulitply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option?\n");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This Operation will result in a mathematical error \n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occured trying to do the math. \n = details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // wait for user response before closing application
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: \n");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly Linespacing

            }
            // add call to close the JSON writer before return
            calculator.Finish();
            return;
        }
    }
}