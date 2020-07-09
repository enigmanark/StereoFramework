using System;
namespace StereoFramework.GameApp
{
    public class Util
    {
        public static string GenerateUniqueId()
        {
            string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                                "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            Random rand = new Random();
            string d = "";
            for (var i = 0; i < 25; i++)
            {
                string k;
                var choose = rand.Next(0, 1 + 1);
                if (choose == 0)
                {
                    k = numbers[rand.Next(0, 9 + 1)];
                }
                else
                {
                    k = letters[rand.Next(0, 25 + 1)];
                }
                d = d + k;
            }

            return d;
        }
    }
}
