using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace disparos
{
    public class Shooting : MonoBehaviour
    {
        //este script maneja la lógica del disparo
        #region variables
        public Texture2D CrossHair;
        public Transform FirePoint;
        public GameObject BalaPrefab;
        #endregion

        #region funciones basicas
        private void Start()
        {
            Cursor.SetCursor(CrossHair, Vector2.zero, CursorMode.Auto);
        }
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                disparar();
            }
        }
        #endregion

        #region code
        void disparar()
        {
            Instantiate(BalaPrefab, FirePoint.position, FirePoint.rotation);
        }
        #endregion
    }
}
