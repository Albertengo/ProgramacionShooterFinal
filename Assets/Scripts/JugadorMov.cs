using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jugador
{
    public class JugadorMov : MonoBehaviour
    {
        #region Variables
        public Rigidbody2D rb;
        public float velocidad;
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
        }

        #endregion
    }
}
