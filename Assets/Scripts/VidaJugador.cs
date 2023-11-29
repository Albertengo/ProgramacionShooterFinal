using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jugador
{
    public class VidaJugador : MonoBehaviour
    {
        #region variables
        [SerializeField] private float SaludMax;
        private float salud;
        [SerializeField] private float HPdropHealing; //lo que cure el objeto de curacion, valga la redundancia

        #endregion

        #region funciones basicas
        void Start()
        {
            salud = SaludMax;
            Debug.Log("Nivel de vida: " + salud);
        }

        #endregion

        #region code

        public void OnCollisionEnter2D(Collision2D collision) //funcion collision para que cuando colisiones con enemigo, tome daño.
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("jugador: estoy recibiendo daño");
            }
        }

        public void daño(int dañoRecibido) //funcion con la mecanica de tomar daño.
        {
            salud = salud - dañoRecibido;
            if (salud <= 0)
            {
                //this.desaparecer();
                Debug.Log("Moriste"); //hacer desp una linea que sea para activar la pantalla de muerte acá
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) //para hacer curar y hacer desaparecer
        {
            if (collision.gameObject.CompareTag("Coleccionable"))
            {
                salud += HPdropHealing;
                Debug.Log("El nuevo nivel de vida es:" + salud);
                collision.gameObject.SetActive(false);
            }

        }
        #endregion
    }
}
