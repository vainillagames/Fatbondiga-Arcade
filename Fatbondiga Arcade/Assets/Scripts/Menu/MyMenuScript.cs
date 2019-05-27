using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MyMenuScript : MonoBehaviour
{
    public GameObject optionsOFON;
    bool flagActive=false;
    public void onTouchPlay()
    {
        SceneManager.LoadScene("Prototiping");
        ProyectilesAOD.points = 0;
    }
    
    public void onTouchExit()
    {
        Application.Quit();
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
