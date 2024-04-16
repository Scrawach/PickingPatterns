using System;

namespace Merchants.Gameplay.PlayerLogic
{
    public class Reputation
    {
        public Reputation(int value) => 
            Value = value;

        public int Value { get; private set; }

        public void Add(int value)
        {
            CheckPositiveValue(value);
            Value += value;
        }

        public void Remove(int value)
        {
            CheckPositiveValue(value);
            Value -= value;
        }

        private void CheckPositiveValue(int value)
        {
            if (Value < 0)
                throw new ArgumentOutOfRangeException($"{nameof(Add)}: only positive numbers!");
        }
        
        public static implicit operator int(Reputation reputation) => reputation.Value;
        public static explicit operator Reputation(int value) => new Reputation(value);
    }
}