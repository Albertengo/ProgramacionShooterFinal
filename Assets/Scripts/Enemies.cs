using disparos;
using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotsEnemigos
{
    public class Enemies : MonoBehaviour
    {
        #region variables
        [Header("ESPECIFICACIONES ENEMIGO")]
        [SerializeField] private string NombreEnemigo;
        public float dañoInflingido;
        [SerializeField] private float velocidad;
        [SerializeField] private float SaludMax;
        public float saludEn; //Salud Enemigo
        [SerializeField] private float RangoAtaque; //rango en que los enemigos detecten al jugador
        public Animator animator;


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
            if (Vector2.Distance(transform.position, objetivo.position) < RangoAtaque) //mientras jugador esté dentro de rango, perseguir
            {
                transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
            }
            //animacion
            Vector2 position = transform.position;
            animator.SetFloat("Speed", position.sqrMagnitude);
        }
        public void recibirDaño()
        {
            saludEn = saludEn - 5;
            if (saludEn <= 0)
            {
                Destroy(gameObject);
                Kills++;
                Loot();
                //Debug.Log("Enemigos eliminados: " + Kills);
            }
        }
        public void Loot()
        {
            Vector2 position = transform.position; //chequea la posicion
            int dropsIndex = Random.Range(0, Drops.Length); //randomiza la loot
            Instantiate(Drops[dropsIndex], position, Quaternion.identity); //instancia loot a recolectar
        }

        private void OnTriggerEnter2D(Collider2D collision) //para cuando es atacado por el jugador
        {
            if (collision.gameObject.CompareTag("Bala"))
            {
                recibirDaño();
            }
        }
        
        #endregion
    }
}
