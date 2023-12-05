using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace interfaz
{
    public class SliderHealth : MonoBehaviour
    {
        public Slider slider;
        private void Start ()
        {
            slider = GetComponent<Slider>();
        }
        public void SetMaxHealth(float vidaMax)
        {
            slider.maxValue = vidaMax;
            slider.value = vidaMax;
        }
        public void SetHealth (float vida)
        {
            slider.value = vida;
        }
        public void startHealthBar (float vida)
        {
            SetMaxHealth(vida);
            SetHealth(vida);
        }
    }
}
