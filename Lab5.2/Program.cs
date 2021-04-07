using System;

namespace Lab5._2
{
    enum Roshambo
    {
        Paper,
        Rock,
        Scissors
    }

    enum Winner
    {
        one,
        two,
        draw
    }
    abstract class Player
    {
        private string Name;
        private Roshambo Choice;
        Random rand = new Random();        

        public string _Name
        {
            get { return Name; }
            set { Name = value; }
        }
        public Roshambo _Choice
        {
            get { return Choice; }
            set { Choice = value; }
        }

        public virtual Roshambo GenerateRoshambo()
        {
            return Choice;
        }

        class PlaysRock : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                Choice = Roshambo.Rock;
                return Choice;
            }
        }
        class PlaysRand : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                int num = rand.Next(0, 3);
                Choice = (Roshambo)num; //this will convert our number to the equivalent Roshambo
                return Choice; 
            }
        }

        class User : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                bool done = false;
                while (!done)
                {
                    Console.Write("Choose Rock, Paper, or Scissors (R/P/S): ");
                    string userChoice = Console.ReadLine().ToLower();
               
                    if (userChoice == "r")
                    {
                        Choice = Roshambo.Rock;
                        done = true;
                    }
                    else if (userChoice == "p")
                    {
                        Choice = Roshambo.Paper;
                        done = true;
                    }
                    else if (userChoice == "s")
                    {
                        Choice = Roshambo.Scissors;
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid entry, please try again");
                        Console.Write("Choose Rock, Paper, or Scissors (R/P/S): ");

                    }
                }
                return Choice;
            }
        }  
    class Program
    {

            static Winner Play(Player one, Player two)
            {
                if (one.Choice == two.Choice)
                {
                    return Winner.draw;
                }
                else if (one.Choice == Roshambo.Rock && two.Choice == Roshambo.Paper)
                {
                    return Winner.two;
                }
                else if (one.Choice == Roshambo.Rock && two.Choice == Roshambo.Scissors)
                {
                    return Winner.one;
                }
                else if (one.Choice == Roshambo.Paper && two.Choice == Roshambo.Rock)
                {
                    return Winner.one;
                }
                else if (one.Choice == Roshambo.Paper && two.Choice == Roshambo.Scissors)
                {
                    return Winner.two;
                }
                else if (one.Choice == Roshambo.Scissors && two.Choice == Roshambo.Paper)
                {
                    return Winner.one;
                }
                else if (one.Choice == Roshambo.Scissors && two.Choice == Roshambo.Rock)
                {
                    return Winner.two;
                }
                else
                {
                    return Winner.draw;
                }

            }

            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to Rock Paper Scissors!");

                PlaysRock Burke = new PlaysRock();
                Burke.Name = "Burke";
                

                PlaysRand Grady = new PlaysRand();
                Grady.Name = "Grady";
                

                User newUser = new User();
                Console.Write("Enter your name: ");
                newUser.Name = Console.ReadLine();

                bool done = false;

                while (!done)
                { 
               
                bool validPlayer = false;

                    while (!validPlayer)
                    {
                        Console.Write($"\nWould you like to play against 1.{Burke.Name} or 2.{Grady.Name}? : ");
                        string opponent = Console.ReadLine();

                        if (opponent == "Burke" || opponent == "1")
                        {
                            validPlayer = true;
                            Roshambo BurkeChoice = Burke.GenerateRoshambo();
                            Roshambo newUserchoice = newUser.GenerateRoshambo();
                            Console.WriteLine($"\n{newUser.Name}: {newUserchoice}!");
                            Console.WriteLine($"Burke: {BurkeChoice}!");

                            if (Play(newUser, Burke) == Winner.one)
                            {
                                Console.WriteLine($"{newUser.Name} won!\n");
                            }
                            else if (Play(newUser, Burke) == Winner.two)
                            {
                                Console.WriteLine("Burke won!\n");
                            }
                            else
                            {
                                Console.WriteLine("Draw!");
                            }

                        }
                        else if (opponent == "Grady" || opponent == "2")
                        {
                            validPlayer = true;
                            Roshambo GradyChoice = Grady.GenerateRoshambo();
                            Roshambo newUserchoice = newUser.GenerateRoshambo();
                            Console.WriteLine($"\n{newUser.Name}: {newUserchoice}!");
                            Console.WriteLine($"Grady: {GradyChoice}!");

                            if (Play(newUser, Grady) == Winner.one)
                            {
                                Console.WriteLine($"{newUser.Name} won!\n");
                            }
                            else if (Play(newUser, Grady) == Winner.two)
                            {
                                Console.WriteLine("Grady won!\n");
                            }
                            else
                            {
                                Console.WriteLine("Draw!");
                            }
                        }

                        else
                        {
                            Console.WriteLine("Invalid entry, please select from the available players.");
                        }
                    }                                        
                        bool valid = false;

                    while (!valid)
                    {
                        Console.Write("\nPlay again? (y/n): ");
                        string answer = Console.ReadLine().ToLower();

                        if (answer == "n")
                        {
                            valid = true;
                            done = true;
                            Console.WriteLine("\nThank you for playing, goodbye!\n");
                        }
                        else if (answer == "y")
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine($"Please only enter \"y\" or \"n\"");
                        }

                    }

                }





            } 
        }
    }
}
