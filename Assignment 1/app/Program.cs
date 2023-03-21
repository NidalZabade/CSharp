

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                enterIdAndName();
                displayMenu();
            }
        }

        public static void enterIdAndName()
        {
            Console.WriteLine("Enter user name: ");
            string name = Console.ReadLine();
            int Id;

            while (true)
            {
                Console.WriteLine("Enter user Id: ");
                string IdString = Console.ReadLine();
                if (int.TryParse(IdString, out Id))
                {
                    if (Id==-1){
                        Console.WriteLine("Goodbye");
                        System.Environment.Exit(0);
                    }
                    if (CheckEquation.isBalanced(Id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Id is not balanced");
                    }
                }
                else
                {
                    Console.WriteLine("Id is not a number");
                }
            }
        }

        public static void displayMenu()
        {
            Console.WriteLine("\n 1- Solve equation given x\n 2-Find roots of equation\n 3-Combine two equations\n 4-Exit\n");
            Console.WriteLine("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        double[] coefficients = new double[3];
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine("Enter coefficient {0}: ", i + 1);
                            if (double.TryParse(Console.ReadLine(), out coefficients[i]))
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coefficient");
                                break;
                            }
                        }

                        double x;

                        while (true)
                        {
                            Console.WriteLine("Enter x: ");
                            if (double.TryParse(Console.ReadLine(), out x))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid x");
                            }
                        }

                        Console.WriteLine($"The result for the equation : {coefficients[0]}x^2 + {coefficients[1]}x + {coefficients[2]} is {CheckEquation.solveEquation(coefficients[0], coefficients[1], coefficients[2], x)} when x = {x}");
                        break;
                    case 2:
                        double[] coefficients2 = new double[3];
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine("Enter coefficient {0}: ", i + 1);
                            if (double.TryParse(Console.ReadLine(), out coefficients2[i]))
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coefficient");
                                break;
                            }
                        }
                        double[] roots;
                        if (CheckEquation.isValidEquation(coefficients2[0], coefficients2[1], coefficients2[2]))
                        {
                            roots = CheckEquation.findEquationRoots(coefficients2[0], coefficients2[1], coefficients2[2]);
                            Console.WriteLine($"The roots of the equation : {coefficients2[0]}x^2 + {coefficients2[1]}x + {coefficients2[2]} are {roots[0]} and {roots[1]}");
                        }
                        else
                        {
                            Console.WriteLine("The equation has no real roots");
                        }
                        break;
                    case 3:
                        double[] coefficients3 = new double[3];

                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine("Enter coefficient {0} for the first equation: ", i + 1);
                            if (double.TryParse(Console.ReadLine(), out coefficients3[i]))
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coefficient");
                                break;
                            }
                        }

                        double[] coefficients4 = new double[3];

                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine("Enter coefficient {0} for the second equation: ", i + 1);
                            if (double.TryParse(Console.ReadLine(), out coefficients4[i]))
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coefficient");
                                break;
                            }
                        }

                        double[] combinedCoefficients = CheckEquation.combineEquations(coefficients3, coefficients4);

                        Console.WriteLine($"The first equation is {coefficients3[0]}x^2 + {coefficients3[1]}x + {coefficients3[2]}");
                        Console.WriteLine($"The second equation is {coefficients4[0]}x^2 + {coefficients4[1]}x + {coefficients4[2]}");
                        Console.WriteLine($"The combined equation is {combinedCoefficients[0]}x^2 + {combinedCoefficients[1]}x + {combinedCoefficients[2]}");
                        break;
                    case 4:
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
    }

    class CheckEquation
    {

        public static bool isBalanced(int Id)
        {

            int sumOdd = 0;
            int sumEven = 0;
            int lastDigit = -1;

            while (Id > 0)
            {
                int digit = Id % 10;
                if (digit == lastDigit)
                {
                    return false;
                }
                if (digit % 2 == 0)
                {
                    sumEven += digit;
                }
                else
                {
                    sumOdd += digit;
                }
                lastDigit = digit;
                Id /= 10;
            }

            return sumEven == sumOdd;

        }

        public static double solveEquation(double a, double b, double c, double x)
        {
            return a * x * x + b * x + c;
        }

        public static bool isValidEquation(double a, double b, double c)
        {
            double root = b * b - 4 * a * c;
            return root >= 0;

        }

        public static double[] findEquationRoots(double a, double b, double c)
        {
            double[] roots = new double[2];
            roots[0] = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            roots[1] = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

            return roots;
        }

        public static double[] combineEquations(double[] firstCoefficients, double[] secondCoefficients)
        {
            double[] combinedCoefficients = new double[3];
            combinedCoefficients[0] = firstCoefficients[0] + secondCoefficients[0];
            combinedCoefficients[1] = firstCoefficients[1] + secondCoefficients[1];
            combinedCoefficients[2] = firstCoefficients[2] + secondCoefficients[2];

            return combinedCoefficients;
        }


    }
}