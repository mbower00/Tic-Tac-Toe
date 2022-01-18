/*
Assignment:
CSE 210 01 Prove: Developer - Solo Code Submission

Author:
Mitchell B. Bower

helps:
https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-5.0
https://byui-cse.github.io/cse210-course-csharp/module01/solo_prep_3_prepare.html
https://byui-cse.github.io/cse210-course-csharp/module01/solo_prep_4_prepare.html
https://byui-cse.github.io/cse210-course-csharp/module01/solo_prep_1_prepare.html
https://byui-cse.github.io/cse210-course-csharp/module01/solo_prep_2_prepare.html
https://m.youtube.com/watch?v=GhQdlIFylQ8
*/

class TicTacToe
{   
    //create the main fuction
    static void Main(string[] args)
    {
        //create the defult places list with the correct starting values.
        List<string> places = new List<string>();
        places.Add("1");
        places.Add("2");
        places.Add("3");
        places.Add("4");
        places.Add("5");
        places.Add("6");
        places.Add("7");
        places.Add("8");
        places.Add("9");

        //set is_x_turn to true because x always starts
        bool is_x_turn = true;
        string current_player = "x";
        string choice = "0";
        bool is_input_valid = false;
        int turn_count = 0;

        //link the while loop to the true is_gaming variable
        bool is_gaming = true;
        while (is_gaming == true)
        {
            //increase the turn counter by 1
            turn_count++;

            //display the board
            BuildBoard(places);
            
            //assign the correct player to current_player
            if (is_x_turn)
            {
                current_player = "x"; 
            }
            else
            {
                current_player = "o";
            }
            
            //obtain a valid move from the player
            is_input_valid = false;
            while (is_input_valid == false)
            {
                Console.Write($"{current_player}'s turn to choose a square (1-9): ");
                choice = Console.ReadLine();
                if (places.Contains(choice) && choice != "x" && choice != "o")
                {
                    is_input_valid = true;
                }
            }
            
            //iterate until we find the choice and replace it with the player's symbol
            for (int i = 0; i < places.Count; i++)
            {
                if (places[i] == choice)
                {
                    places[i] = current_player;
                    break;
                }
            }

            //win, tie, or continue
            if (IsWinner(places)) //win
            {
                BuildBoard(places);
                Console.WriteLine($"Well done, {current_player}, you win! GG");
                is_gaming = false;
            }
            else if (turn_count == 9) //tie
            {
                BuildBoard(places);
                Console.WriteLine($"Tied game! GG");
                is_gaming = false;
            }
            else //continue
            {
                is_x_turn = !is_x_turn;
            }
        }
    }

    //a function that displays the current board
    static void BuildBoard(List<string> places)
    {
        Console.WriteLine($"\n{places[0]}|{places[1]}|{places[2]}\n-+-+-\n{places[3]}|{places[4]}|{places[5]}\n-+-+-\n{places[6]}|{places[7]}|{places[8]}\n");
    }

    //a function that returns true/false whether the player wins
    static bool IsWinner(List<string> places)
    {
        if (
                /*
                Here is the index locations of the places list in tic-tac-toe format:
                0|1|2
                -+-+-
                3|4|5
                -+-+-
                6|7|8
                */
                
                //horizontal wins
                (places[0] == places[1] && places[1] == places[2]) ||
                (places[3] == places[4] && places[4] == places[5]) ||
                (places[6] == places[7] && places[7] == places[8]) ||

                //vertical wins
                (places[0] == places[3] && places[3] == places[6]) ||
                (places[1] == places[4] && places[4] == places[7]) ||
                (places[2] == places[5] && places[5] == places[8]) ||

                //diagonal wins
                (places[0] == places[4] && places[4] == places[8]) ||
                (places[2] == places[4] && places[4] == places[6])
            )
        {
            return true;
        }
        else //no win
        {
            return false;
        }
    }
}