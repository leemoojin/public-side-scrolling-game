using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MonsterHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;

        public void UpdateHealthBar(float healthPercentage)
        {
            healthSlider.value = healthPercentage;
        }
    }
}

