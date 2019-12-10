using System;

namespace CommandPatternArmy
{
    public class Army
    {
        readonly int _maxFatality;
        Random _r;

        public Army(int count, int maxFatality)
        {
            _maxFatality = maxFatality;
            _r = new Random();

            Count = count;
        }

        public int Count { get; private set; }

        public void Attack(Army target)
        {
            int attack = _r.Next(1, _maxFatality);

            if (Chance())
            {
                if (attack > target.Count)
                {
                    target.Count -= attack;
                    Annihilation();
                }
                else
                {
                    target.Count -= attack;
                    AttackSuccessful(attack);
                }
            }
            else
                AttackFailed();
        }

        protected bool Chance() => _r.Next(0, 6) > 0;

        protected virtual void Annihilation()
        {
            Console.WriteLine($"You annihilated the enemy army.");
        }

        protected virtual void AttackSuccessful(int attack)
        {
            Console.WriteLine($"You destroyed {attack} enemy soldiers.");
        }

        protected virtual void AttackFailed()
        {
            Console.WriteLine($"Your attack failed.");
        }
    }

    public class HomeArmy : Army
    {
        public HomeArmy(int count, int maxFatality) : base(count, maxFatality)
        {
            Moves = 0;
        }

        public int Moves { get; private set; }

        public void MoveForward()
        {
            if (Chance())
            {
                ++Moves;
                Console.WriteLine("Your army moved one pace closer to enemy fort.");
            }
            else
                Console.WriteLine("Your army failed to progress to enemy fort.");
        }
    }

    public class EnemyArmy : Army
    {
        public EnemyArmy(int count, int maxFatality) : base(count, maxFatality) {}

        protected override void Annihilation()
        {
            Console.WriteLine($"The enemy annihilated your army.");
        }

        protected override void AttackSuccessful(int attack)
        {
            Console.WriteLine($"Enemy destroyed {attack} of your soldiers.");
        }

        protected override void AttackFailed()
        {
            Console.WriteLine($"Enemy attack failed.");
        }
    }
}
