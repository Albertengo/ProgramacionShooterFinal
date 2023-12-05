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
       // public Enemies dañoInflingido;
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

        //public void OnCollisionEnter2D(Collision2D collision) //funcion collision para que cuando colisiones con enemigo, tome daño.
        //{
        //    if (collision.gameObject.CompareTag("Enemy"))
        //    {
        //        Daño(dañoInflingido);
        //        Debug.Log("jugador: estoy recibiendo daño un daño de: " + dañoInflingido);
        //    }
        //}

        public void Daño(float dañoRecibido) //funcion con la mecanica de tomar daño.
        {
            Debug.Log("Antes - Salud: " + Salud + ", Daño Recibido: " + dañoRecibido);
            Salud -= dañoRecibido;
            Debug.Log("Después - Salud: " + Salud);
            //Salud = Mathf.Max(0, Salud - dañoRecibido);
            // salud -= dañoRecibido; //el problema esta en este calculo, pasa de 15 de salud a -27, -30 ????
            Debug.Log("daño recibido: " + dañoRecibido);
            Debug.Log("salud: " + Salud);
            healthbar.SetHealth(Salud);
            if (Salud <= 0)
            {
                //this.desaparecer();
                Debug.Log("Moriste. Nivel de salud: " + Salud); //hacer desp una linea que sea para activar la pantalla de muerte acá
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
