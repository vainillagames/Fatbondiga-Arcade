
using UnityEngine;
using UnityEngine.SceneManagement;
public class MyMenuScript : MonoBehaviour
{
    public GameObject optionsOFON;
    bool flagActive=false;
    public void onTouchPlay()
    {
        ProyectilesAOD.points = 0;
        //optionsOFON.SetActive(true);

        //SceneManager.MoveGameObjectToScene(optionsOFON, SceneManager.GetSceneByBuildIndex(4));
        SceneManager.LoadScene("Loading");
        

    }
    
    public void onTouchExit()
    {
        Application.Quit();
    }
    public void onTouchMenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
    public void onTochOptions()
    {
        if (!flagActive)
        {

            optionsOFON.SetActive(true);
            flagActive = true;
        }
        else
        {
            optionsOFON.SetActive(false);
            flagActive = false;
        }

    }
}
