using UnityEngine;
using UnityEngine.UI;

namespace Mediator.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        
        public void Fill(float ratio) => 
            _bar.fillAmount = ratio;
    }
}