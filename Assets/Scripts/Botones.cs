using BotsEnemigos;
using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace interfaz
{
    public class Botones : MonoBehaviour
    {
        //lógica para los botones usados dentro del juego
        public void Restart()
        {
            SceneManager.LoadScene("Game");
            Enemies.Kills = 0;
            ControlJuego.CantidadEnemigos = 0;
            Time.timeScale = 1f;
        }
        public void Menu()
        {
            SceneManager.LoadScene("Menu de Inicio");
        }
        public void PlayButton()
        {
            SceneManager.LoadScene("Game");
            Enemies.Kills = 0;
            ControlJuego.CantidadEnemigos = 0;
            Time.timeScale = 1f;
        }
        public void QuitGame()
        {
            Debug.Log("Saliste.");
            Application.Quit();
        }
    }
}
