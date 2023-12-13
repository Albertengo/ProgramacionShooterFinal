using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jugador
{
    public class JugadorMov : MonoBehaviour
    {
        #region Variables
        //movimiento
        public float velocidad;
        [SerializeField] public float velocidadBoost = 5;
        private bool booster = false;
        private float tiempoBooster = 3f;

        //animaciones
        public Animator animator;
        Vector2 Playermov;
        #endregion

        #region funciones basicas
        void Update()
        {
            movimiento();
        }
        #endregion

        #region code
        void movimiento ()
        {
            float movimientohorizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
            float movimientovertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
            transform.Translate(movimientohorizontal, movimientovertical, 0);
            
            //animacion
            Playermov = new Vector2(movimientohorizontal,movimientovertical).normalized; //.normalized para normalizar el num del vector
            animator.SetFloat("X", Playermov.x);
            animator.SetFloat ("Y", Playermov.y);
            animator.SetFloat("Speed", Playermov.sqrMagnitude);
        }
        private void OnTriggerEnter2D(Collider2D collision) //para boostear la velocidad del pj
        {
            if (collision.gameObject.CompareTag("Boost"))
            {
                booster = true;
                if (booster == true)
                {
                    velocidad = velocidadBoost;
                    Invoke("EndBoost", tiempoBooster);
                    //Debug.Log("Boosteando, velocidad: " + velocidad);
                }
                collision.gameObject.SetActive(false);
            }
        }
        void EndBoost()
        {
            booster = false;
            velocidad = 3;
            //Debug.Log("Terminó el Boost, velocidad: " + velocidad);
        }
        #endregion
    }
}
