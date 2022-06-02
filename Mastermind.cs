using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermindtest
{
      public class Mastermind
    {
        List<string> answer = new List<string>();
        int NumberOfChances = 2;
        string start = "Yes"; 

        // check on colours in input
        public string ShouldCheckIfColoursIsCorrect(List<Ball> inputformastermind, List<Ball> generatecolour)
        {
            Ball[] converttoarray = generatecolour.ToArray();
            Ball[] inputarray = inputformastermind.ToArray();
            string[] generateinputarray = new string[3];
            string[] userinputarray = new string[3];
            List<string> generateinput = new List<string>();
            List<string> userinput = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                generateinput.Add(converttoarray[i].colour.ToString());
                generateinputarray = generateinput.ToArray();
                userinput.Add(inputarray[i].colour.ToString());
                userinputarray = userinput.ToArray();
            }

                for (int i = 0; i < 4; i++) 
                {
                    if (generateinputarray[i] == userinputarray[i])
                    {
                        answer.Add("black");
                    }
                    else if (generateinputarray[i] != userinputarray[i] && generateinputarray.Contains(userinputarray[i]))
                    {
                        answer.Add("white");
                    }
                }
              
            var result = string.Join(",", answer.ToArray());            
            return result;
        }
        // Create Randomcolour
        public List<Ball> CreateRandomColour()
        {
            int count = 4;
            Random random = new Random();
            Ball ball = new Ball();
            Ball[] colurs = { new(BallColour.Red), new(BallColour.Yellow), new(BallColour.Green), new(BallColour.Blue), new(BallColour.White), new(BallColour.Black) };
            List<Ball> listoutput = new List<Ball>();

            for (int i = 0; i < count; i++)
            {
                int index = random.Next(colurs.Length);
                listoutput.Add(colurs[index]);
            }
            return listoutput;
        }


        // this function will start the game
        public void Excecutegame(List<Ball> generatecolour)
        {
            string[] colourinput = new string[3]; 
            List<Ball> inputformastermind = new List<Ball>();

            try
            {
                Console.WriteLine("Enter Mastermindinput:");
                string Mastermindinput = Console.ReadLine();
                colourinput = Mastermindinput.Split(",");
                inputformastermind = Giveinput(colourinput);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(ShouldCheckIfColoursIsCorrect(inputformastermind, generatecolour));
            Console.ReadLine();
        }
        //This function will run the game
        public void Runprogram()
        {
          
            while (start == "Yes")
            {
                var generatecolour = CreateRandomColour(); 

                for (int i = 0; i < NumberOfChances; i++)
                {
                    Console.WriteLine($"Chances left: {NumberOfChances - i}");
                    Excecutegame(generatecolour);
                    answer.Clear();
                }             
  
                    Console.WriteLine("Sorry, but you didn't find the correct solution within the needed number of chances.");
                //  var result = string.Join(",", generatecolour.ToString()); 

                foreach (var item in generatecolour)
                {
                    Console.WriteLine(item.colour);
                }
                    Console.WriteLine("Would you like to try another round");
                    AskIfYouWantToTryAgain();
            }
            Console.WriteLine("Thank you for using the Game.");
            Console.ReadKey();
        }

        // show game info 
        public void ShowInfo()
        {
            Console.WriteLine("This is Mastermind game.Type your input like: Black,Blue,Black,Red");
        } 

        // try Again
        public void AskIfYouWantToTryAgain()
        {
            try
            {
                Console.WriteLine("Do you want to enter another example? [Yes/No]");
                start = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Ball> Giveinput(string[] colourinput)
        {
            List<Ball> yourinput = new List<Ball>();

            foreach (var item in colourinput)
            {
                string output = item;
                switch (output)
                {
                    case "Red":
                        yourinput.Add(new(BallColour.Red));
                        break;
                    case "Blue":
                        yourinput.Add(new(BallColour.Blue));
                        break;
                    case "Green":
                        yourinput.Add(new(BallColour.Green));
                        break;
                    case "Yellow": 
                        yourinput.Add(new (BallColour.Yellow)); 
                       break;
                    case "Black":
                        yourinput.Add(new(BallColour.Black)); 
                       break;
                    case "White":
                        yourinput.Add(new(BallColour.White));
                        break;
                }
            }  
            return yourinput;
        }
    }
}
