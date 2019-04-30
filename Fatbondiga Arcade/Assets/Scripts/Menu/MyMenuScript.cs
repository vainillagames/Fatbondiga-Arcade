using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MyMenuScript : MonoBehaviour
{
    public void onTouchPlay()
    {
        SceneManager.LoadScene("Prototiping");
        ProyectilesAOD.points = 0;
    }
    
    public void onTouchExit()
    {
        Application.Quit();
    }
}
