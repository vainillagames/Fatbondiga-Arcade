
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuInGame : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject menuOptions;
    bool flagActive = false;
    void Start()
    {
        Time.timeScale = 1;//por defecto lo volvemos a poner a 1 al cargar  la escena
       // menuOptions = GameObject.Find("Options");
        //menuPause.SetActive(false);
        //menuOptions.SetActive(false);

       
    }
    public void activateMenuPause()
    {
        Time.timeScale = 0;
        menuPause.SetActive(true);
    }
    public void activateOptions()
    {

        if (!flagActive)
        {

            menuOptions.SetActive(true);
            flagActive = true;
        }
        else
        {
            menuOptions.SetActive(false);
            flagActive = false;
        }
        

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
