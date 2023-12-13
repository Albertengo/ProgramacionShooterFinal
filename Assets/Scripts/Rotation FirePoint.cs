using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace disparos
{
    public class RotationFirePoint : MonoBehaviour
    {
        //este script sirve para poder rotar la fuente del disparo
        private Camera mainCam;
        private Vector3 mouseposition;

        #region funciones básicas
        private void Start()
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
        void Update()
        {
            Rotation();
        }
        #endregion

        #region code
        private void Rotation()
        {
            mouseposition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mouseposition - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        #endregion
    }
}
