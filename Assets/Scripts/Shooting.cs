using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace disparos
{
    public class Shooting : MonoBehaviour
    {
        #region variables
        //se necesita agregar un nuevo code para que el firepoint siga al jugador
        //ya que parece que el firepoint se queda quieto en su lugar apenas toca con el enemigo.
        //private Vector3 target;
        public Texture2D CrossHair;
        private Vector2 mouseposition;
        public Transform FirePoint;
        public GameObject BalaPrefab;
        public Rigidbody2D rbFirePoint;
        #endregion

        #region funciones basicas
        private void Start()
        {
            Cursor.SetCursor(CrossHair, Vector2.zero, CursorMode.Auto);
        }
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
            //if (FirePoint == null)
            //{
            //    return; //Erases error
            //}
            Instantiate(BalaPrefab, FirePoint.position, FirePoint.rotation);
            
           
        }
        #endregion
    }
}
