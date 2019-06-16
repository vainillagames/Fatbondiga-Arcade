using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continuara : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Continuara");
            FindObjectOfType<AudioManager>().Stop("lvl1music");
            FindObjectOfType<AudioManager>().Play("continuara");
        }
    }
}
