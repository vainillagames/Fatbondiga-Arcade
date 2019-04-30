
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuInGame : MonoBehaviour
{
    public GameObject menuPause;
   void Awake()
    {
        Time.timeScale = 1;//por defecto lo volvemos a poner a 1 al cargar  la escena
    }
    public void activateMenuPause()
    {
        Time.timeScale = 0;
        menuPause.SetActive(true);
    }
    public void seguirJugando()
    {
        Time.timeScale = 1;
        menuPause.SetActive(false);

    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void menuPrincipal()
    {
        SceneManager.LoadScene("Menu");
        ProyectilesAOD.points = 0;
    }
}
