
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePorCaida : MonoBehaviour
{
    int puntuacion;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //TODO guardar max score
            puntuacion = ProyectilesAOD.points;
            
            if (PlayerPrefs.HasKey("HighScore"))
            {
                if (PlayerPrefs.GetInt("HighScore") < puntuacion)
                {
                    PlayerPrefs.SetInt("HighScore", puntuacion);
                }
            }
            else
            {
                PlayerPrefs.SetInt("HighScore", puntuacion);
            }
            PlayerPrefs.SetInt("GameScore", puntuacion);
            
            
            Invoke("Muerte", 1.6f);
            FindObjectOfType<AudioManager>().Play("muerteCaida");
        }
    }
    public void Muerte()
    {
        SceneManager.LoadScene("Game Over");
        //FindObjectOfType<AudioManager>().Play("");

    }
}
