using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionalIntelligence
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        enum EmotionalStatus
        {
            Numbness,
            BasicEmotions,
            IntermediateEmotions,
            FullEmotionalStatus,
            IntenseEmotions,
        }

        private static EmotionalStatus GetEmotionalStatus()
        {
            string prompt;
            prompt = "Do you feel emotions without thinking about them right now? 0 - 10";
            Input.GetInt(prompt, maxValue: 10);
        }
    }

    internal static class Input
    {
        public static int GetInt(string prompt, int minValue = 0, int maxValue = 10)
        {
            (minValue, maxValue) = (Math.Min(minValue, maxValue), Math.Max(minValue, maxValue));
            
            while (true)
            {
                Console.WriteLine(prompt);
                Console.WriteLine($"Accepted input is an Integer ranging from {minValue} to {maxValue}");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());

                    return input; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Argument out of range");
                }
            }
        }
    }
}
