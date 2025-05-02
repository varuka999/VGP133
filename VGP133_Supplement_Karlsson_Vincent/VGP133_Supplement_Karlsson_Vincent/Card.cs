using System.Net.Http.Headers;

namespace VGP133_Supplement_Karlsson_Vincent
{
    public class Card
    {
        public string suit = "";
        public string rank = "";
        public int numberValue = 0;

        public Card(int suitIndex, int num)
        {
            switch (suitIndex)
            {
                case 0:
                    suit = "Clubs";
                    break;
                case 1:
                    suit = "Diamonds";
                    break;
                case 2:
                    suit = "Hearts";
                    break;
                case 3:
                    suit = "Spades";
                    break;
                default:
                    break;
            }

            switch (num)
            {
                case 1: 
                    rank = "Ace";
                    numberValue = 11;
                    break;
                case 2: 
                    rank = "2";
                    numberValue = 2;
                    break;
                case 3: 
                    rank = "3";
                    numberValue = 3;
                    break;
                case 4: 
                    rank = "4";
                    numberValue = 4;
                    break;
                case 5: 
                    rank = "5";
                    numberValue = 5;
                    break;
                case 6: 
                    rank = "6";
                    numberValue = 6;
                    break;
                case 7: 
                    rank = "7";
                    numberValue = 7;
                    break;
                case 8: 
                    rank = "8";
                    numberValue = 8;
                    break;
                case 9: 
                    rank = "9";
                    numberValue = 9;
                    break;
                case 10: 
                    rank = "10";
                    numberValue = 10;
                    break;
                case 11: 
                    rank = "Jack";
                    numberValue = 10;
                    break;
                case 12: 
                    rank = "Queen";
                    numberValue = 10;
                    break;
                case 13: 
                    rank = "King";
                    numberValue = 10;
                    break;
                default:
                    break;
            }
        }
    }
}
