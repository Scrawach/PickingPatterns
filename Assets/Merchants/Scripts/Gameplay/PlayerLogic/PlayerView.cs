using Merchants.UserInput;
using UnityEngine;

namespace Merchants.Gameplay.PlayerLogic
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private InteractWithTrader _interactWithTrader;
        
        private IInput _input;
        
        public Player Player { get; private set; }

        public void Construct(IInput input, Player player)
        {
            _input = input;
            Player = player;
        }

        private void Update()
        {
            _movement.Move(_input.MovementAxis);
            
            if (_input.InteractPressed())
                _interactWithTrader.Interact();
        }
    }
}