using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace BotsEnemigos
{
    public class Enemies : MonoBehaviour
    {
        #region variables
        [SerializeField] private string NombreEnemigo;
        [SerializeField] private float velocidad;
        [SerializeField] private float SaludMax;
        private float salud;

        [SerializeField] private float RangoAtaque;
        private Transform objetivo;
        #endregion

        #region funciones basicas
        void Start()
        {
            salud = SaludMax;
            objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            Movimiento();
        }
        #endregion

        #region code
        private void Movimiento ()
        {
            if (Vector2.Distance(transform.position, objetivo.position) < RangoAtaque)
            {
                transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
            }
        }
        public void recibirDaño()
        {
            salud = salud - 5;
            if (salud <= 0)
            {
                //this.desaparecer();
                Destroy(gameObject);
                //Kills++;
                //Debug.Log("Enemigos eliminados: " + Kills);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Bala"))
            {
                recibirDaño();
            }
        }
        #endregion
    }
}
