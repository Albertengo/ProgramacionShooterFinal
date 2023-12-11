using BotsEnemigos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace interfaz
{
    public class ContadorKills : MonoBehaviour
    {
        public Text Contador;
        public Text Tiempo;
        void Update()
        {
            Tiempo.text = ControlJuego.tiempoRestante + "s restantes.";
            Contador.text = Enemies.Kills + "/8 asesinatos";
        }
    }
}
