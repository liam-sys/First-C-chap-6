/*
Chap 6 Summary (Loops)
-This chapter introduces loops, the constructs that let a program execute a piece of code repeatedly.
-The main things i covered in this chapter are:
1. What Is a Loop:
   I learned that a loop repeats a code either a fixed number of times or until a condition stops being true. I also learned that a loop that never ends is called an infinite loop, and it is rarely needed except when a break is used inside it.
2. While Loops:
   I was reminded of the while loop from Python. The condition (a bool expression) is checked before each pass, so if it is false at the start the body never runs, and if it never becomes false the loop runs forever.
3. The break Operator:
   I learned that break ends a loop early from inside its body, and the program continues from the line right after the loop. 
4. Do-While Loops:
   I learned that a do-while loop checks its condition after the body, so the body always runs at least once. I also learned that it ends with a semicolon after the condition, and it is used when the code must run at least once.
5. For Loops:
   I learned that a for loop packs the initialization, the condition and the update of the counter into one line: for (initialization; condition; update). It is mostly used when the number of repetitions is known in advance, and the counter is only visible inside the loop. I also learned that any of the three parts can be left out, and for ( ; ; ) makes an infinite loop.
6. For Loop with Several Variables:
   I learned that a for loop can have more than one counter, separated by commas.
7. The continue Operator:
   I learned that continue skips the rest of the current pass and jumps to the next one, without ending the loop (unlike break).
8. Foreach Loops:
   I learned that foreach goes through every element of an array or other collection without needing an index. It is similar to Python's for item in list.
9. Nested Loops:
   I learned that nested loops are loops placed inside each other, where the inner loop runs more times than the outer one. 
*/

//Chap 6 Code Snippet

using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. while loop: the condition is checked before each pass
        int count = 1;
        while (count <= 3)
        {
            Console.WriteLine("while: " + count);            // 1 2 3
            count++;                                          // to update the variable or the loop never ends
        }

        // 2. do-while loop: the body runs at least once
        int tries = 10;
        do
        {
            Console.WriteLine("do-while ran once even though the condition is false");
            tries++;
        } while (tries < 5);                                  

        // 3. break: leave the loop early
        int n = 1;
        while (true)                                          // infinite loop
        {
            if (n > 5)
            {
                break;                                        // jumps to the line after the loop
            }
            n++;
        }
        Console.WriteLine("break stopped the loop at n = " + n);   

        // 4. for loop: for (initialization; condition; update)
        int sum = 0;
        for (int i = 1; i <= 5; i++)                          // i only exists inside this loop
        {
            sum += i;
        }
        Console.WriteLine("Sum of 1 to 5 = " + sum);          

        // 5. for loop with several variables
        for (int small = 1, large = 10; small < large; small++, large--)
        {
            Console.WriteLine(small + " " + large);           
        }

        // 6. continue: skip the rest of this pass only
        int oddSum = 0;
        for (int i = 1; i <= 10; i += 2)                      // odd numbers only (step of 2)
        {
            if (i % 7 == 0)
            {
                continue;                                     // skips 7, goes to the next number
            }
            oddSum += i;
        }
        Console.WriteLine("Odd numbers not divisible by 7 = " + oddSum);   

        // 7. foreach loop: goes through every element of a collection
        int[] numbers = { 2, 3, 5, 7 };
        foreach (int num in numbers)
        {
            Console.Write(num + " ");                         
        }
        Console.WriteLine();
        string[] towns = { "London", "Paris", "Milan" };
        foreach (string town in towns)
        {
            Console.Write(town + " ");                        
        }
        Console.WriteLine();

        // 8. Nested loops: the inner loop runs fully for each pass of the outer loop
        for (int row = 1; row <= 4; row++)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write("* ");                          // prints a triangle
            }
            Console.WriteLine();                              // new line after each row (is important to use or only the first line of the triangle will be printed)
        }

        // 9. Work-on: Factorial calculator (Chapter 4 input + Chapter 5 if + Chapter 6 loops)
        Console.Write("Enter a number from 1 to 20: ");
        int number;
        bool valid = int.TryParse(Console.ReadLine(), out number);
        if (!valid || number < 1 || number > 20)              // 21! is too big for a long
        {
            Console.WriteLine("Invalid number");
        }
        else
        {
            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;                               // 5! = 1 * 2 * 3 * 4 * 5
            }
            Console.WriteLine(number + "! = " + factorial);
        }

        Console.ReadKey();
        
        //10. Work-on: Guessing game (Chapter 4 input + Chapter 5 if + Chapter 6 loops)

        Random random = new Random();
        int no_to_guess = random.Next(1, 101);
        bool play_again = true;

        while (play_again)
        {
            Console.WriteLine("Guess a number between 1 and 100: ");
            int guess = Convert.ToInt32(Console.ReadLine());

            if (guess > 100 || guess < 1)
            {
                Console.WriteLine("Invalid guess. Please enter a number between 1 and 100.");
            }
            else if (guess < no_to_guess)
            {
                Console.WriteLine("Too low!, Guess again");
            }
            else if (guess > no_to_guess)
            {
                Console.WriteLine("Too high!,guess again");
            }
            else 
            {
                Console.WriteLine("Congratulations! You guessed the number.It is " + no_to_guess);
                Console.WriteLine("                ");
                Console.WriteLine("Do you want to play again? (y/n): ");
                String response = Console.ReadLine();
                if (response.ToLower() == "y")
                {
                    no_to_guess = random.Next(1, 101);
                }
                else
                {
                    play_again = false;
                    Console.WriteLine("Thanks for playing!");
                }
            }
        }
        Console.ReadKey();

        //11. Work-on: Rock, Paper, Scissors game (Chapter 4 input + Chapter 5 if + Chapter 6 loops)

        //Random random = new Random();
        bool play_Again = true;
        String player_choice;
        String comp_choice;
        String responce;
        int comp_value;
        int player_score = 0;
        int comp_score = 0;

        while (play_Again)
        {
            player_choice = "";
            comp_choice = "";
            Console.WriteLine("Enter your choice (rock, paper, scissors): ");
            player_choice = Console.ReadLine().ToLower();

            while (player_choice != "rock" && player_choice != "paper" && player_choice != "scissors")
            {
                Console.WriteLine("Invalid choice. Please enter rock, paper, or scissors: ");
                player_choice = Console.ReadLine().ToLower();
            }

            comp_value = random.Next(1, 3);

            switch (comp_value)
            {
                case 1:
                    comp_choice = "rock";
                    break;
                case 2:
                    comp_choice = "paper";
                    break;
                case 3:
                    comp_choice = "scissors";
                    break;
            }

            Console.WriteLine("Player Choice: " + player_choice);
            Console.WriteLine("Computer Choice: " + comp_choice);

            switch (player_choice)
            {
                case "rock":
                    if (comp_choice == "scissors")
                    {
                        Console.WriteLine("You win!");
                        player_score++;
                    }
                    else if (comp_choice == "paper")
                    {
                        Console.WriteLine("Computer wins!");
                        comp_score++;
                    }
                    else
                    {
                        Console.WriteLine("It's a tie!");
                    }
                    break;
                case "paper":
                    if (comp_choice == "rock")
                    {
                        Console.WriteLine("You win!");
                        player_score++;
                    }
                    else if (comp_choice == "scissors")
                    {
                        Console.WriteLine("Computer wins!");
                        comp_score++;
                    }
                    else
                    {
                        Console.WriteLine("It's a tie!");
                    }
                    break;
                case "scissors":
                    if (comp_choice == "paper")
                    {
                        Console.WriteLine("You win!");
                        player_score++;
                    }
                    else if (comp_choice == "rock")
                    {
                        Console.WriteLine("Computer wins!");
                        comp_score++;
                    }
                    else
                    {
                        Console.WriteLine("It's a tie!");
                    }
                    break;
            }

            Console.WriteLine("Player Score: " + player_score);
            Console.WriteLine("Computer Score: " + comp_score);

            Console.WriteLine("Do you want to play again? (y/n): ");
            responce = Console.ReadLine();

            if (responce.ToLower() != "y")
            {
                play_Again = false;
                Console.WriteLine("Thanks for playing!");
            }
            else
            {
                comp_value = random.Next(1, 3);
                continue;
            }
        }
        Console.ReadKey();
    }
}
