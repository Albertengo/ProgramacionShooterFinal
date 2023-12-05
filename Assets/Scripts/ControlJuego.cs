using System.Collections;
using UnityEngine;
using BotsEnemigos;
using interfaz;

public class ControlJuego : MonoBehaviour
{
    #region Variables
    public GameObject jugador;
    public GameObject[] enemyPrefabs; 
    
    public Win_Lose screenW;
    public Win_Lose screenL;
    public static float tiempoRestante;
    private int xPos;
    private int zPos;
    public static int CantidadEnemigos; //objetivo de enemigos a eliminar dentro del juego
    #endregion

    #region voids basicos
    void Start()
    {
        ComenzarJuego();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoRestante == 0) //si se acaba el tiempo, gameover.
        {
            ComenzarJuego();
            screenL.ActiveScreen();
        }
        if (Enemies.Kills == 8) //si se eliminan 8 enemigos, gameover.
        {
            screenW.ActiveScreen();
        }
    }
    #endregion

    #region Code
    void ComenzarJuego()
    {
        jugador.transform.position = new Vector2(0f, 1.07f);
        StartCoroutine(SpawnEnemigos());
        StartCoroutine(Cronometro(30));
        Random.Range(1, 10);
    }
    IEnumerator SpawnEnemigos()
    {
        while (CantidadEnemigos < 8)
        {
            xPos = Random.Range(-5, 5); //randomiza posicion de enemigos
            zPos = Random.Range(-5, 5);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length); //randomiza tipo de enemigo a spawnear
            Instantiate(enemyPrefabs[enemyIndex], new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            CantidadEnemigos += 1; //para que no sean más de 8 enemigos
        }
    }
    public IEnumerator Cronometro(float valorCronometro = 30)
    {
        tiempoRestante = valorCronometro;
        while (tiempoRestante > 0)
        {
            yield return new WaitForSeconds(1.0f);
            tiempoRestante--;
        }
    }
    #endregion
}
