using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace disparos
{
    public class Balas : MonoBehaviour
    {
        #region variables
        public float velocidad = 1f;
        public Rigidbody2D rbBala;
        public GameObject HitEffect; //para la animacion desp
        public float tiempo = 3; //el alcance que va a tener la bala antes de desaparecer
        #endregion

        #region funciones basicas
        void Start()
        {
            rbBala.velocity = transform.right * velocidad;
        }

        #endregion

        #region code
        private void OnCollisionEnter2D(Collision2D hitInfo) //antes era OnTriggerEnter2D(Collider2D hitInfo)
        {
            //Instantiate(hitEffect, transform.position, Quaternion.Identity);
            Destroy(gameObject); //(gameObject, tiempo); esto funcionaba pero traspasaba los enemigos, queria cambiar eso
        }
        #endregion
    }
}
