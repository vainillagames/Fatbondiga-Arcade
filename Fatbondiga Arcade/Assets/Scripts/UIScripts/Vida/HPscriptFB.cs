using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPscriptFB : MonoBehaviour
{
    public Image currentHPbar;
    int puntuacion;
    private float HP = 100;
    private float maxHP = 100;

    private void Start()
    {
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        float hpNumber = HP / maxHP;
        currentHPbar.rectTransform.localScale = new Vector3(hpNumber, 1, 1);

    }

    private void TakeDamage(float damage)
    {
        FindObjectOfType<AudioManager>().Play("hit");
        HP -= damage;
        if (HP < 0)
        {
            HP = 0;
            Debug.Log("Dead");
            //TODO HACER TRANSICIONES FADE IN FADE OUT AL MORIR
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
            FindObjectOfType<AudioManager>().Play("muerte");
            Invoke("muerteDelay", 0.5f);
            

        }
        UpdateHPBar();
    }
    private void HealFB(float heal)
    {
        FindObjectOfType<AudioManager>().Play("eat");
        HP += heal;
        if(HP>maxHP)
        {
            HP = maxHP;
        }
        UpdateHPBar();

    }
    private void muerteDelay()
    {
        SceneManager.LoadScene("Game Over");
    }
}
