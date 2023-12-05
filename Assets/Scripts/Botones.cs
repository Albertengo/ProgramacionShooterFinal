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
        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
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
            SceneManager.LoadScene("SampleScene");
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
