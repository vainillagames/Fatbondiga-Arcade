
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePorCaida : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //TODO guardar max score
            Invoke("Muerte", 1.6f);
            FindObjectOfType<AudioManager>().Play("muerteCaida");
        }
    }
    public void Muerte()
    {
        SceneManager.LoadScene("Game Over");
    }
}
