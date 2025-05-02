using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace VGP133_Supplement_Karlsson_Vincent
{
    internal class Questions
    {
        public void Question1()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 101);
            int gameInput = 0;
            int counter = 0;

            Console.WriteLine("Guess a number between 1-100!");
            while (counter < 10 || gameInput == randomNum)
            {
                if (Int32.TryParse(Console.ReadLine(), out gameInput) == false)
                {
                    continue;
                }

                if (gameInput == randomNum)
                {
                    Console.WriteLine("Congrats you guessed the right number!");
                    break;
                }
                else if (gameInput < randomNum)
                {
                    Console.WriteLine("You guessed too low!");
                }
                else if (gameInput > randomNum)
                {
                    Console.WriteLine("You guessed too high!");
                }

                counter++;

                if (counter >= 10)
                {
                    Console.WriteLine($"You ran out of guesses!\nThe correct answer was {randomNum}!\n");
                    break;
                }
            }
        }

        private string ReturnScrambledString(string stringToScramble)
        {
            List<char> stringList = new List<char>();
            string returnString = "";

            foreach (char c in stringToScramble)
            {
                stringList.Add(c);
            }

            Random random = new Random();
            while (stringList.Count > 0)
            {
                int index = random.Next(0, stringList.Count);

                returnString += stringList[index];

                stringList.RemoveAt(index);
            }

            return returnString;
        }

        public void Question2()
        {
            string[] stringArray = { "trampoline", "airplane", "gravity", "climbing", "velocity", "royalty", "defenestration", "ruminating", "topology", "gyroscope" };
            string stringInput = "";
            Random random = new Random();
            int randomIndex = random.Next(0, stringArray.Length);

            string scrambledString = ReturnScrambledString(stringArray[randomIndex]);

            Console.WriteLine($"Your Scrambled Word: {scrambledString}");
            Console.WriteLine("Unscrambled guess: ");

            stringInput = Console.ReadLine().ToLower();

            if (stringInput != stringArray[randomIndex])
            {
                Console.WriteLine($"You lost the game! The word was: {stringArray[randomIndex]}");
            }
            else
            {
                Console.WriteLine($"You won the game!");
            }
        }

        private void PrintHangManProgress(ref string[] hangmanArt, char[] hangmanProgress, List<char> guessedLetters, int guesses)
        {
            switch (guesses)
            {
                case 1:
                    hangmanArt[2] = " O   |";
                    break;
                case 2:
                    hangmanArt[3] = " |   |";
                    break;
                case 3:
                    hangmanArt[3] = "/|   |";
                    break;
                case 4:
                    hangmanArt[3] = "/|\\  |";
                    break;
                case 5:
                    hangmanArt[4] = "/    |";
                    break;
                case 6:
                    hangmanArt[4] = "/ \\  |";
                    break;
                case 7:
                    hangmanArt[2] = "o_o  |";
                    break;
                case 8:
                    hangmanArt[2] = "X_X  |";
                    break;
                default:
                    break;
            }

            foreach (string s in hangmanArt)
            {
                Console.WriteLine(s);
            }

            if (guessedLetters.Count > 0)
            {
                Console.Write("Guessed letters: ");
                foreach (char c in guessedLetters)
                {
                    Console.Write($"{c} ");
                }
            }
            Console.WriteLine();

            Console.Write("\nWord: ");
            foreach (char c in hangmanProgress)
            {
                Console.Write(c);
            }
            Console.WriteLine("\n");
        }

        private bool IsHangmanComplete(char[] hangmanProgress)
        {
            foreach (char c in hangmanProgress)
            {
                if (c == '_')
                {
                    return false;
                }
            }

            return true;
        }

        public void Question3()
        {
            string[] stringArray = { "kelp", "plane", "ball", "sword", "melee", "destroy", "defense", "think", "topology", "round" };
            string[] hangmanArt = { " +---+",
                                     " |   |",
                                     "     |",
                                     "     |",
                                     "     |",
                                     "     |",
                                     " ____|"};
            List<char> guessedChars = new List<char>();
            char charInput;
            int guessCounter = 0;

            Random random = new Random();
            int randomIndex = random.Next(0, stringArray.Length);
            string hangmanWord = stringArray[randomIndex];

            char[] hangmanProgress = new char[hangmanWord.Length];

            for (int i = 0; i < hangmanProgress.Length; i++)
            {
                hangmanProgress[i] = '_';
            }

            while (guessCounter < 8)
            {
                PrintHangManProgress(ref hangmanArt, hangmanProgress, guessedChars, guessCounter);
                Console.WriteLine($"{8 - guessCounter} guesses remaining\n");
                Console.WriteLine("Guess a letter: ");

                charInput = Console.ReadLine().ToLower()[0]; // I thought this was pretty nifty, not sure if it's the best way.

                guessedChars.Add(charInput);

                for (int i = 0; i < hangmanProgress.Length; i++)
                {
                    if (charInput == hangmanWord[i])
                    {
                        hangmanProgress[i] = charInput;
                    }
                }

                guessCounter++;

                Console.Clear();

                if (IsHangmanComplete(hangmanProgress) == true)
                {
                    PrintHangManProgress(ref hangmanArt, hangmanProgress, guessedChars, guessCounter - 1);
                    Console.WriteLine("Congrats you won game!\n");
                    break;
                }
                else if (guessCounter >= 8)
                {
                    PrintHangManProgress(ref hangmanArt, hangmanProgress, guessedChars, guessCounter);
                    Console.WriteLine($"You ran out of guesses! The word was: {hangmanWord}!\n");
                }
            }
        }

        static void Shuffle<T>(List<T> list) // Fisher Yates shuffle, got it from stack
        {
            Random random = new Random();
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private int ReturnHandValue(List<Card> hand)
        {
            int value = 0;
            int aceCounter = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                if (hand[i].rank == "Ace")
                {
                    aceCounter++;
                }
                else
                {
                    value += hand[i].numberValue;
                }
            }

            if (aceCounter > 0)
            {
                for (int i = 0; i < aceCounter; i++)
                {
                    if (value + 11 > 21)
                    {
                        value += 1;
                    }
                    else
                    {
                        value += 11;
                    }
                }
            }

            return value;
        }

        public void Question4()
        {
            List<Card> deckOfCards = new List<Card>();
            List<Card> dealersHand = new List<Card>();
            List<Card> playersHand = new List<Card>();
            int dealersHandValue = 0;
            int playersHandValue = 0;

            int playerInput = 0;

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Card card = new Card(i, j);
                    deckOfCards.Add(card);
                }
            }

            Shuffle(deckOfCards);

            for (int i = 0; i < 2; i++)
            {
                int index = random.Next(0, deckOfCards.Count);
                playersHand.Add(deckOfCards[index]);
                deckOfCards.RemoveAt(index);
            }

            for (int i = 0; i < 2; i++)
            {
                int index = random.Next(0, deckOfCards.Count);
                dealersHand.Add(deckOfCards[index]);
                deckOfCards.RemoveAt(index);
            }

            Console.WriteLine("Your Hand: ");
            foreach (Card card in playersHand)
            {
                Console.WriteLine($"{card.rank} of {card.suit}");
            }
            playersHandValue = ReturnHandValue(playersHand);
            Console.WriteLine($"Your Value: {playersHandValue}");

            Console.WriteLine("\nDealers Hand: ");
            foreach (Card card in dealersHand)
            {
                Console.WriteLine($"{card.rank} of {card.suit}");
            }
            dealersHandValue = ReturnHandValue(dealersHand);
            Console.WriteLine($"House Value: {dealersHandValue}\n");

            if (playersHandValue > 21)
            {
                Console.WriteLine("You busted!");
                return;
            }
            else if (dealersHandValue > 21)
            {
                Console.WriteLine("The House busted!");
                return;
            }
            else if (playersHandValue == 21)
            {
                Console.WriteLine("You won!");
                return;
            }
            else if (dealersHandValue == 21)
            {
                Console.WriteLine("The House wins!");
                return;
            }

            while (true)
            {
                Console.WriteLine("1 to Hit, 2 to Stand");
                if (Int32.TryParse(Console.ReadLine(), out playerInput) == false)
                {
                    playerInput = 2;
                    Console.WriteLine("Invalid input! Defaulted choice to Stand!");
                }

                if (playerInput == 1)
                {
                    Console.WriteLine("You chose to Hit!");
                    int index = random.Next(0, deckOfCards.Count);
                    playersHand.Add(deckOfCards[index]);
                    deckOfCards.RemoveAt(index);

                    Console.WriteLine("Your Hand: ");
                    foreach (Card card in playersHand)
                    {
                        Console.WriteLine($"{card.rank} of {card.suit}");
                    }

                    playersHandValue = ReturnHandValue(playersHand);
                    Console.WriteLine($"Your Value: {playersHandValue}\n");

                    if (playersHandValue > 21)
                    {
                        Console.WriteLine("You busted!");
                        return;
                    }

                    continue;
                }
                else if (playerInput == 2)
                {
                    Console.WriteLine("You chose to Stand!");

                    while (dealersHandValue <= 17)
                    {
                        int index = random.Next(0, deckOfCards.Count);
                        dealersHand.Add(deckOfCards[index]);
                        deckOfCards.RemoveAt(index);
                        dealersHandValue = ReturnHandValue(dealersHand);
                    }
                }

                Console.WriteLine("\nFinal:");
                Console.WriteLine($"Your Value: {playersHandValue}\n");
                Console.WriteLine($"House Value: {dealersHandValue}\n");

                if (playersHandValue > 21)
                {
                    Console.WriteLine("You busted!");
                }
                else if (dealersHandValue > 21)
                {
                    Console.WriteLine("The House busted!");
                }
                else if (playersHandValue > dealersHandValue)
                {
                    Console.WriteLine("You won!");
                }
                else if (playersHandValue < dealersHandValue)
                {
                    Console.WriteLine("The House wins!");
                }
                else
                {
                    Console.WriteLine("Its a draw!");
                }
                break;
            }
        }
    }
}
