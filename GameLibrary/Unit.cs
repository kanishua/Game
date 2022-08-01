using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    /*Create class Unit and derived Warrior and Archer
    Both can Attack(Unit) and Defense();
    Warrior will have 50% of attack damage.(Воин получает 50% от наносимого ему урона)
    ....Archer will have 70% chance to dodge attack at all but will have 120% damage.
    (Есть 70% шанс уклона от атаки, но лучник получает 120% от наносимого ему урона)
    ....Archer has 33% chance to have critical strike(crit damage = 200 % of base damage)
    (Есть 33% шанс нанести двойной урон)
    ....Warrior will get only 70% of attack damage.
    (Воин получает 70% от наносимого ему двойного урона)
    Base stats: Warrior(200HP, 20 AD),  Archer(120 HP, 35 AD)
    Simulate game with random unit turn first until death of opponent;
    Simulate game with 3x3 parties(attack random unit in opponent party) until full death of enemies.
    Simulate battle-royal N units vs all.*/


    public abstract class Unit
    {
        private int _healthPoints; //очки жизни
        private int _attackDamage; //сила атаки

        public int HealthPoints
        {
            get => _healthPoints;
            set
            {
                if (value > 0)
                {
                    _healthPoints = value;
                }
                else
                {
                    _healthPoints = 0;
                }
            }
        }

        public int AttackDamage
        {
            get => _attackDamage;
            set => _attackDamage = value;
        }

        public Unit(int healthPoints, int attackDamage)
        {
            HealthPoints = healthPoints;
            AttackDamage = attackDamage;
        }

        public virtual void Attack(Unit unit)
        {
        }

        public virtual int Defense(int attackDamage, bool chanceCriticalStrike)
        {
            return attackDamage;
        }
    }

    public class Warrior : Unit
    {
        public Warrior() : base(200, 20) { }

        public override void Attack(Unit unit)
        {
            if (unit.HealthPoints > 0)
            {
                unit.HealthPoints -= unit.Defense(AttackDamage, false);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override int Defense(int attackDamage, bool chanceCriticalStrike)
        {
            float percentDefenseFromCriticalDamage = 0.7f;
            float percentDefenseFromNormalDamage = 0.5f;

            if (chanceCriticalStrike == true)
            {
                attackDamage = (int)(attackDamage * percentDefenseFromCriticalDamage);
            }
            else
            {
                attackDamage = (int)(attackDamage * percentDefenseFromNormalDamage);
            }

            return attackDamage;
        }
    }

    public class Archer : Unit
    {
        private const int _percentDodgeAttack = 70; // уклон от атаки
        private const int _percentCriticalStrike = 33; //критический урон        

        public Archer() : base(120, 35) { }

        public override void Attack(Unit unit)
        {
            bool chanceCriticalStrike = Random.GenerateRandomForChanceOfGet(_percentCriticalStrike);

            if (unit.HealthPoints > 0)
            {
                if (chanceCriticalStrike == true)
                {
                    int attackDamageWhifCrit = AttackDamage * 2;

                    unit.HealthPoints -= unit.Defense(attackDamageWhifCrit, chanceCriticalStrike);
                }
                else
                {
                    unit.HealthPoints -= unit.Defense(AttackDamage, chanceCriticalStrike);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override int Defense(int attackDamage, bool chanceCriticalStrike = false)
        {
            bool chancDodgeAttack = Random.GenerateRandomForChanceOfGet(_percentDodgeAttack);
            float percentDefenseFromNormalDamage = 1.2f;

            if (chancDodgeAttack == true)
            {
                attackDamage = 0;
            }
            else
            {
                attackDamage = (int)(attackDamage * percentDefenseFromNormalDamage);
            }

            return attackDamage;
        }
    }
}