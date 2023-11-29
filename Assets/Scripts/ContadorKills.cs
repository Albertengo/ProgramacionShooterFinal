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
        void Start()
        {
           // Contador = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            Contador.text = Enemies.Kills + "/8 asesinatos";
        }
    }
}
