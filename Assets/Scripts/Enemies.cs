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
        [SerializeField] public int dañoInflingido;
        [SerializeField] private float velocidad;
        [SerializeField] private float SaludMax;
        private float salud;
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
            salud = SaludMax;
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
        public void recibirDaño()
        {
            salud = salud - 5;
            if (salud <= 0)
            {
                Destroy(gameObject);
                Kills++;
                Vector2 position = transform.position;
                int dropsIndex = Random.Range(0, Drops.Length);
                Instantiate(Drops[dropsIndex], position, Quaternion.identity);
                Debug.Log("Enemigos eliminados: " + Kills);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) //para cuando es atacado por el jugador
        {
            if (collision.gameObject.CompareTag("Bala"))
            {
                recibirDaño();
            }
        }
        private void OnCollisionEnter2D(Collision2D collision) //para atacar al jugador
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                VidaJugador.daño(dañoInflingido);
                Debug.Log("Estoy dañando al jugador ");
            }
        }
        #endregion
    }
}
