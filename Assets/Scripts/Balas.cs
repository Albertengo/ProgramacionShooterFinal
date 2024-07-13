using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace disparos
{
    public class Balas : MonoBehaviour
    {
        //este script sirve para manejar la velocidad del disparo y su autodestrucción
        #region variables
        public float velocidad = 1f;
        public Rigidbody2D rbBala;
        public float tiempo = 3; //el alcance que va a tener la bala antes de desaparecer
        #endregion

        #region funciones basicas
        void Start()
        {
            rbBala.velocity = transform.right * velocidad;
            Destroy(gameObject, tiempo);
        }

        #endregion

        #region code
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3")
            {
                Destroy(gameObject);
            }
        }
            #endregion
    }
}