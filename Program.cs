using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Derivative
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
            Console.ReadLine();
        }
        static void menu()
        {
            Console.Clear();
            Console.WriteLine("\t\t'Main Menu'");
            Console.WriteLine("1)\tDerivate");
            Console.WriteLine("2)\tAbout");
            Console.WriteLine("3)\tHelp");
            Console.WriteLine("4)\tExit");
            char choice = Convert.ToChar(Console.ReadLine());
            switch (choice)
            {
                case '1':
                    derivativeMenu();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("'ABOUT'");
                    Console.WriteLine("This software has been developed by Hassan Rais Khan who is currently studying BSCS from PAF KIET.");
                    Console.WriteLine("It's is an open source software so anybody can use and alter it :)");
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("To derivate anything select 1 and further select type of derivation, input methods have been defined their....");
                    Console.WriteLine("For more issues please contact: hassan@xyz.com");
                    break;
                case '4':
                    Environment.Exit(0);
                    break;
            }

        }

        static string derivative(string input)
        {
            bool isx = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'x')
                {
                    isx = true;
                    break;
                }

            }

            if (input == "x")
            {
                return "1";
            }



            else if (input[0] == 'x')
            {
                    string num = "";
                    for (int i = 2; i < input.Length; i++)
                    {
                        num += input[i];
                    }
                    return (Convert.ToInt32(num) + "x^" + (Convert.ToInt32(num) - 1));
            }

            else if (input[input.Length - 1] == 'x')
            {
                string num = "";
                for (int i = 0; i < input.Length - 1; i++)
                    num += input[i];
                return num;
            }

            else if (isx)
            {
                char[] c = { 'x', '^' };
                string[] nums = input.Split(c);

                return (Convert.ToInt32(nums[0]) * Convert.ToInt32(nums[2]) + "x^" + (Convert.ToInt32(nums[2]) - 1));
            }
            else
            {
                return "0";
            }
        }

        static string derivatePolynomial(string polynomial)
        {
            char[] c = {'-','+' };
            string[] input = polynomial.Split(c);
            string polynomialD = "";
            int count = 0;
            for (int i = 0; i < polynomial.Length; i++,count++)
            {
                polynomialD += derivative(input[count]);
                i += input[count].Length;
                if (i < polynomial.Length)
                    polynomialD += polynomial[i];
                else
                    break;

            }

            return polynomialD;
        }

        static void derivativeMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\tSelect type of derivation");
            Console.WriteLine("1)\tSingle term");
            Console.WriteLine("2)\tPolynomial");
            Console.WriteLine("3)\tMultiplication of polynomial [UV]");
            Console.WriteLine("4)\tDivision of polynomial [U/V]");
            Console.WriteLine("5)\tBack to main menu");
            char choice = Convert.ToChar(Console.ReadLine());
            switch (choice)
            {
                case '1':
                    singleTermDerivation();
                    break;
                case '2':
                    derivationOfPolynomial();
                    break;
                case '3':
                    multiplicationOfPolynomial();
                    break;
                case '4':
                    divisionOfPolynomial();
                    break;
                case '5':
                    menu();
                    break;
                default:
                    menu();
                    break;
            }
        }

        static void singleTermDerivation()
        {
            Console.Clear();
            Console.WriteLine("Input must be like e.g. x,mx,x^n,mx^n,m........ etc");
            Console.WriteLine("Where m and n are integers.\n");
            Console.Write("Enter term : ");
            string input = Console.ReadLine();
            Console.WriteLine(derivative(input));
            Console.ReadKey();
            Console.WriteLine("Press anykey for back or 'y' for again single term derivation....");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'y')
                singleTermDerivation();
            else
                derivativeMenu();
        }

        static void derivationOfPolynomial()
        {
            Console.Clear();
            Console.WriteLine("Polynomials must be like e.g. mx^n+mx^n-mx^n..... etc");
            Console.WriteLine("Where m and n are integers.\n");
            Console.Write("Enter first polynomial : ");
            string input = Console.ReadLine();
            Console.WriteLine(derivatePolynomial(input));
            Console.ReadKey();
            Console.WriteLine("Press anykey for back or 'y' for again polynomial derivation....");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'y')
                derivationOfPolynomial();
            else
                derivativeMenu();
        }
        static void multiplicationOfPolynomial()
        {
            Console.Clear();
            Console.WriteLine("Polynomials must be like e.g. mx^n+mx^n-mx^n..... etc");
            Console.WriteLine("Where m and n are integers.\n");
            Console.Write("Enter first polynomial [U] = ");
            string input1 = Console.ReadLine();
            Console.Write("Enter second polynomial [V] = ");
            string input2 = Console.ReadLine();
            Console.WriteLine("("+input1+")("+derivatePolynomial(input2)+")+("+input2+")("+derivatePolynomial(input1)+")");
            Console.ReadKey();
            Console.WriteLine("Press anykey for back or 'y' for again polynomial derivation....");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'y')
                multiplicationOfPolynomial();
            else
                derivativeMenu();
        }

        static void divisionOfPolynomial()
        {
            Console.Clear();
            Console.WriteLine("Polynomials must be like e.g. mx^n+mx^n-mx^n..... etc");
            Console.WriteLine("Where m and n are integers.\n");
            Console.Write("Enter first polynomial [U] = ");
            string input1 = Console.ReadLine();
            Console.Write("Enter second polynomial [V] = ");
            string input2 = Console.ReadLine();
            Console.WriteLine("[(" + input2 + ")(" + derivatePolynomial(input1) + ")-(" + input1 + ")(" + derivatePolynomial(input2) + ")]/("+input2+")^2");
            Console.ReadKey();
            Console.WriteLine("Press anykey for back or 'y' for again polynomial derivation....");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'y')
                divisionOfPolynomial();
            else
                derivativeMenu();
        }
    }
}
