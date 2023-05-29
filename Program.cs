using System;
using System.Collections;
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
            Console.WriteLine(GetEmotionalStatus());
            Console.ReadKey();
        }

        static Hashtable EmotionalStatus = new Hashtable()
        {
            { 1,"Numbness" },
            { 2, "Basic Emotions" },
            { 3, "Intermediate Emotions" },
            { 4, "Full Emotional Status" },
            { 5, "Intense Emotions" }
        };

        private static string GetEmotionalStatus()
        {
            double unclassifedES = 0;
            string prompt;
            
            prompt = "Do you feel emotions without thinking about them right now?";
            unclassifedES += Input.GetInt(prompt) / 10.0 * 20;

            prompt = "How much emotions are you able to feel?";
            unclassifedES += Input.GetInt(prompt) / 10.0 * 30;

            prompt = "Are you able to feel love or horny? (Just interest doesn't count)";
            unclassifedES += Input.GetInt(prompt) / 10.0 * 50;

            prompt = "Are you able to feel real hornyness without losing context and emotions?";
            unclassifedES += Convert.ToInt32(Input.GetBoolean(prompt)) / 10.0 * 50;

            prompt = "Are you able to remember a really bad emotion without losing your emotions.\n" +
                "Don't remember if it makes you loose all emotions, if so, answer with 0, else remember and desire to feel the emotions it produce";
            unclassifedES += Convert.ToInt32(Input.GetBoolean(prompt)) / 10.0 * 100;

            prompt = "How intense your emotions are?";
            unclassifedES += Input.GetInt(prompt) / 10.0 * 100;

            prompt = "Do you have stable emotions? i.e. You don't loose them. (If you don't know what is to loose emotiotions respond with \"No\")";
            unclassifedES += Convert.ToInt32(Input.GetBoolean(prompt)) / 10.0 * 50;

            int classifiedES = (int)Math.Round(unclassifedES / 100.0);
            Console.WriteLine(classifiedES);
            return (string)EmotionalStatus[classifiedES];
        }
    }

    internal static class Input
    {
        private static List<string> negativeBooleanOptions = new List<string>(new string[] { "no", "false", "0" });
        private static List<string> positiveBooleanOptions = new List<string>(new string[] { "yes", "true", "1" });

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
                    if (input <= minValue || input >= maxValue)
                        throw new ArgumentOutOfRangeException();
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

        public static bool GetBoolean(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                Console.WriteLine("Accepted options are booleans.");

                Console.WriteLine("Negative options:");
                Util.PrintList(negativeBooleanOptions);

                Console.WriteLine("Positive options:");
                Util.PrintList(positiveBooleanOptions);

                try
                {
                    string input = Console.ReadLine().ToLower();

                    if (negativeBooleanOptions.Contains(input))
                        return false;
                    if (positiveBooleanOptions.Contains(input))
                        return true;

                    throw new FormatException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input is not an option!");
                }
            }
        }
    }

    internal static class Util
    {
        public static void PrintList<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine("\t" + item);
            }
        }
    }
}
