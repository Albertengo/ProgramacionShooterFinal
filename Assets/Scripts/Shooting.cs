using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace disparos
{
    public class Shooting : MonoBehaviour
    {
        #region variables
        //private Vector3 target;
        private Vector2 mouseposition;
        public Transform FirePoint;
        public GameObject BalaPrefab;
        public Rigidbody2D rbFirePoint;
        #endregion

        #region funciones basicas
        void Update()
        {
            mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RotarDisparo();
            if (Input.GetButtonDown("Fire1"))
            {
                disparar();
            }
        }
        #endregion

        #region code
        private void RotarDisparo()
        {
            Vector2 directionlook = mouseposition - rbFirePoint.position;
            float angulo = Mathf.Atan2(directionlook.y, directionlook.x)* Mathf.Rad2Deg - 0f;
            rbFirePoint.rotation = angulo;
        }
        void disparar()
        {
            //if (target == null)
            //{
            //    return; //Erases error
            //}
            Instantiate(BalaPrefab, FirePoint.position, FirePoint.rotation);
            
           
        }
        #endregion
    }
}
