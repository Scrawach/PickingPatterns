using Merchants.Gameplay.Merchants;
using UnityEngine;

namespace Merchants.Gameplay.PlayerLogic
{
    public class InteractWithTrader : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private float _interactRadius;

        public void Interact()
        {
            var objects = Physics.OverlapSphere(transform.position, _interactRadius);
            
            foreach (var unit in objects)
            {
                if (unit.TryGetComponent(out MerchantView merchantView))
                    merchantView.TradeWith(_playerView.Player);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _interactRadius);
        }
    }
}