using UnityEngine;

namespace Mediator.Scripts
{
    public class MediatorBootstrapper : MonoBehaviour
    {
        [SerializeField] private int _totalHealth;
        [SerializeField] private UIMediator _mediator;
        
        private void Start()
        {
            var player = new Health(_totalHealth);
            _mediator.Construct(player);
        }
    }
}