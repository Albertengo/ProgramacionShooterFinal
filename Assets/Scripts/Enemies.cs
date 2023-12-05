using disparos;
using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace BotsEnemigos
{
    public class Enemies : MonoBehaviour
    {
        #region variables
        [Header("ESPECIFICACIONES ENEMIGO")]
        [SerializeField] private string NombreEnemigo;
        public float da�oInflingido;
        [SerializeField] private float velocidad;
        [SerializeField] private float SaludMax;
        public float saludEn;
        [SerializeField] private float RangoAtaque;

        [Header("INTERACCION")]
        public VidaJugador VidaJugador;
        private Transform objetivo;
        public GameObject[] Drops;
        public static int Kills;
        #endregion

        #region funciones basicas
        void Start()
        {
            saludEn = SaludMax;
            objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        }

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
        public void recibirDa�o()
        {
            saludEn = saludEn - 5;
            if (saludEn <= 0)
            {
                Destroy(gameObject);
                Kills++;
                
                Vector2 position = transform.position; //chequea la posicion
                int dropsIndex = Random.Range(0, Drops.Length); //randomiza la loot
                Instantiate(Drops[dropsIndex], position, Quaternion.identity); //instancia loot a recolectar
                
                Debug.Log("Enemigos eliminados: " + Kills);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) //para cuando es atacado por el jugador
        {
            if (collision.gameObject.CompareTag("Bala"))
            {
                recibirDa�o();
            }
        }
        private void OnCollisionEnter2D(Collision2D collision) //para atacar al jugador
        {
            //if (collision.gameObject.CompareTag("Player"))
            //{
            //    VidaJugador.Da�o(da�oInflingido);
            //    Debug.Log("Estoy da�ando al jugador -" + da�oInflingido);
            //}
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player Hit");

                if (VidaJugador != null)
                {
                    VidaJugador.Da�o(da�oInflingido);
                }
            }
        }
        #endregion
    }
}
