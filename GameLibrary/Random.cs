using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    class Random
    {
        public static int GenerateRandomNumber(int maxValue)
        {
            System.Random random = new System.Random();
            int rand = random.Next(maxValue);
            return rand;
        }

        public static bool GenerateRandomForChanceOfGet(int a)
        {
            if (GenerateRandomNumber(100) < a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Unit GenerateRandomForСreateUnit()
        {
            if (GenerateRandomNumber(2) == 0)
            {
                return new Warrior();
            }
            else
            {
                return new Archer();
            }
        }

        public static int GenerateRandomIndexOfArray(int lengthArray)
        {
            return GenerateRandomNumber(lengthArray);
        }
    }
}