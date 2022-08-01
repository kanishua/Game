using System;

namespace GameLibrary
{
    public class Games
    {
        public static Unit[] GenerateArrayOfUnits(int length)
        {
            Unit[] unit = new Unit[length];

            for (int i = 0; i < unit.Length; i++)
            {
                unit[i] = Random.GenerateRandomForСreateUnit();
            }

            return unit;
        }

        public static void GameOneVsOne()
        {
            Unit[] unit = GenerateArrayOfUnits(2);

            do
            {
                bool chancAttack = Random.GenerateRandomForChanceOfGet(50);

                if (chancAttack == true)
                {
                    unit[0].Attack(unit[1]);
                }
                else
                {
                    unit[1].Attack(unit[0]);
                }
            } while (unit[0].HealthPoints > 0 && unit[1].HealthPoints > 0);
        }

        public static bool CheckHealthPoints(Unit[] army)
        {
            bool result = false;

            for (int i = 0; i < army.Length; i++)
            {
                if (army[i].HealthPoints > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public static int CheckIndex(Unit[] army)
        {
            int index = Random.GenerateRandomIndexOfArray(army.Length);

            if (army[index].HealthPoints > 0)
            {
                return index;
            }
            else
            {
                return CheckIndex(army);
            }
        }

        public static void GameThreeVsThree()
        {
            Unit[] armyOne = GenerateArrayOfUnits(3);
            Unit[] armyTwo = GenerateArrayOfUnits(3);

            do
            {
                bool chancAttack = Random.GenerateRandomForChanceOfGet(50);

                if (chancAttack == true)
                {
                    int indexArmyOne = CheckIndex(armyOne);
                    int indexArmyTwo = CheckIndex(armyTwo);
                    armyOne[indexArmyOne].Attack(armyTwo[indexArmyTwo]);
                }
                else
                {
                    int indexArmyOne = CheckIndex(armyOne);
                    int indexArmyTwo = CheckIndex(armyTwo);
                    armyTwo[indexArmyTwo].Attack(armyOne[indexArmyOne]);
                }
            } while (CheckHealthPoints(armyOne) == true && CheckHealthPoints(armyTwo) == true);
        }
    }
}