using UnityEngine;
using Zenject;

namespace DiMediator
{
    public class Player : ITickable
    {
        private readonly Level _level;

        public Player(Level level) => 
            _level = level;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _level.OnDefeat();
        }
    }
}