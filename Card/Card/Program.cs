namespace Exercise
{
    using System;

    class Card
    {
        // private fields for backing storage 
        //public char suit;
        //public char value;
        //public bool facing;
        public int suit;
        public int value;
        public bool facing;



        // constructors (2) :  
        public Card(int number)
        {

            this.suit = number / 13;
            this.value = number % 13;
            this.facing = false;

          //  if (number >= 0 && number <= 12)
          //  {
          //      //this.suit = 'C';
          //      this.suit = 0;
          //  }
          //else if (number >= 13 && number <= 25)
          //  {
          //      //this.suit = 'D';
          //      this.suit = 1;
          //  }
          //  else if (number >= 26 && number <= 38)
          //  {
          //      //this.suit = 'H';
          //      this.suit = 2;
          //  }
          //  else if (number >= 39 && number <= 51)
          //  {
          //      //this.suit = 'S';
          //      this.suit = 3;

          //  }

            //switch (number)
            //{
            //    case 0: case 13: case 26: case 39:
            //        //this.value = 'A';
            //        this.value = 0;
            //        break;
            //    case 1: case 14: case 27: case 40:
            //        //this.value = '2';
            //        this.value = 1;
            //        break;
            //    case 2: case 15: case 28: case 41:
            //        //this.value = '3';
            //        this.value = 2;
            //        break;
            //    case 3: case 16: case 29: case 42:
            //        //this.value = '4';
            //        this.value = 3;
            //        break;
            //    case 4: case 17: case 30: case 43:
            //        //this.value = '5';
            //        this.value = 4;
            //        break;
            //    case 5: case 18: case 31: case 44:
            //        //this.value = '6';
            //        this.value = 5;
            //        break;
            //    case 6: case 19: case 32: case 45:
            //        //this.value = '7';
            //        this.value = 6;
            //        break;
            //    case 7: case 20: case 33: case 46:
            //        //this.value = '8';
            //        this.value = 7;
            //        break;
            //    case 8: case 21: case 34: case 47:
            //        //this.value = '9';
            //        this.value = 8;
            //        break;
            //    case 9: case 22: case 35: case 48:
            //        //this.value = 'T';
            //            this.value = 9;
            //        break;
            //    case 10: case 23: case 36: case 49:
            //        //this.value = 'J';
            //        this.value = 10;
            //        break;
            //    case 11: case 24: case 37: case 50:
            //        //this.value = 'Q';
            //        this.value = 11;
            //        break;
            //    case 12: case 25: case 38: case 51:
            //        //this.value = 'K';
            //        this.value = 12;
            //        break;
            //    default:
            //        this.facing = false;
            //        break;
            //}

        }
        public Card(int faceValue,
                    int suit,
                    bool facing)
        {
            
            this.suit = suit;
            this.value = faceValue;
            this.facing = facing;
        }

        // public properties
        int Value
        {
            // what goes here
            get
            {
                return this.value;  
            } 
            set
            {
                this.value = value;
            }
        }
        int Suit
        {
            // what goes here
            get
            {
                return this.suit;
            }
            set
            {
                this.suit = value;
            }
        }
        bool Facing
        {
            // what goes here
            get
            {
                return this.Facing;
            }
            set
            {
                this.Facing = value;
            }
        }
        // methods 
        public void Flip()
        {
             this.facing = !this.facing;
        }
        public void Reveal()
        {
            this.facing = true;
        }
        public void Hide()
        {
            this.facing = false;
        }
        public override string ToString()
        {
            // condition?true-stuff:false-stuff;

            // facing is the condition: 
            //   it is either true (show)
            //   or false (hide)
            // "A23456789TJQK"[Value] is the 
            //   character to return 
            //   if facing is true
            // '?' is the character to 
            //   return if facing is false

            // similar thing for suit

            char v = Facing
                     ? "A23456789TJQK"[Value]
                     : '?';
            char s = Facing
                     ? "CDHS"[Suit]
                     : '?';

            return $"{v}{s}";
        }

    }
}


/*
 Create a Card class which represents a playing card from a standard deck. It should have the following properties:

Suit: an integer 0 - 3 representing one of 4 suits:
0 = clubs, 1 = diamonds, 2 = hearts, 3 = spades
Value: an integer 0-12 representing the face value of the card:
ace = 0, deuce = 1, ..., jack = 10 , queen = 11, king = 12
Facing: bool representing if the card is
face up (true) or face down (false)

the following behaviors should be reflected: Constructor #1 from a single integer (0 - 51) constructs all 52 cards
0 = ace of clubs, ..., 12 = king of clubs
13 = ace of diamonds, ..., 25 = king of diamonds
26 = ace of hearts, ..., 38 = king of hearts
39 = ace of spades, ..., 51 = king of spades
Default is Face Up

Constructor #2 taking 3 params:
2 integers, and a bool
constructs a specific card (face up or down depending on the bool).
Make Console.WriteLine work
it should print out value(A23456789TJQK)
and suit(CDHS) (if face up)

or

?? (if face down):
ace of clubs would print out
AC if face up and ?? if face down
10 of Diamonds would print out
TD if face up and ?? if face down

provide methods Flip(), Reveal(), and Hide()
to modify the facing of the card.

You only have to provide the card class. The test harness will then create several cards and test them to see if they are correct.

Expected Output:
AC 2C 3C 4C 5C 6C 7C 8C 9C TC JC QC KC
AD 2D 3D 4D 5D 6D 7D 8D 9D TD JD QD KD
AH 2H 3H 4H 5H 6H 7H 8H 9H TH JH QH KH
AS 2S 3S 4S 5S 6S 7S 8S 9S TS JS QS KS
?? ?? ?? AC 5C
KH 5D 5S ?? ??
KH 5D 5S AC 5C
?? ?? ?? ?? ??

Hints: integer division(/) by 13 will return a number 0-4
representing a suit if provided a number 0 - 51
integer modulus(%) by 13 will return a number 0-12
representing the remainder (the value) if provided a number 0 - 51
the string "A23456789TJQK" can be treated as an array of 13 elements:
indexed as 0-12

the string "CDHS" can be treated as an array of 4 elements:
indexed as 0-3
 
 */