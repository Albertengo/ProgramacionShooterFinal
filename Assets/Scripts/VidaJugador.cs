using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using interfaz;
using BotsEnemigos;

namespace Jugador
{
    public class VidaJugador : MonoBehaviour
    {
        #region variables
        public float SaludMax = 15;
        public float Salud;
        public SliderHealth healthbar;
        [SerializeField] private float HPdropHealing; //lo que cure el objeto de curacion, valga la redundancia
       // public Enemies da�oInflingido;
       // public Win_Lose screenL;
        #endregion

        #region funciones basicas
        void Start()
        {
            Salud = SaludMax;
            //healthbar.SetMaxHealth(SaludMax);
            healthbar.startHealthBar(Salud);
            Debug.Log("Nivel de vida: " + Salud);
        }

        #endregion

        #region code

        //public void OnCollisionEnter2D(Collision2D collision) //funcion collision para que cuando colisiones con enemigo, tome da�o.
        //{
        //    if (collision.gameObject.CompareTag("Enemy"))
        //    {
        //        Da�o(da�oInflingido);
        //        Debug.Log("jugador: estoy recibiendo da�o un da�o de: " + da�oInflingido);
        //    }
        //}

        public void Da�o(float da�oRecibido) //funcion con la mecanica de tomar da�o.
        {
            Debug.Log("Antes - Salud: " + Salud + ", Da�o Recibido: " + da�oRecibido);
            Salud -= da�oRecibido;
            Debug.Log("Despu�s - Salud: " + Salud);
            //Salud = Mathf.Max(0, Salud - da�oRecibido);
            // salud -= da�oRecibido; //el problema esta en este calculo, pasa de 15 de salud a -27, -30 ????
            Debug.Log("da�o recibido: " + da�oRecibido);
            Debug.Log("salud: " + Salud);
            healthbar.SetHealth(Salud);
            if (Salud <= 0)
            {
                //this.desaparecer();
                Debug.Log("Moriste. Nivel de salud: " + Salud); //hacer desp una linea que sea para activar la pantalla de muerte ac�
               // screenL.ActiveScreen();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) //para hacer curar y hacer desaparecer
        {
            if (collision.gameObject.CompareTag("Coleccionable"))
            {
                Salud += HPdropHealing;
                Debug.Log("El nuevo nivel de vida es:" + Salud);
                collision.gameObject.SetActive(false);
            }

        }
        #endregion
    }
}
