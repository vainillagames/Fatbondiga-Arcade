using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPscriptFB : MonoBehaviour
{
    public Image currentHPbar;

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
        HP -= damage;
        if (HP < 0)
        {
            HP = 0;
            Debug.Log("Dead");
            //TODO HACER TRANSICIONES FADE IN FADE OUT AL MORIR
            //SceneManager.LoadScene("Game Over");

        }
        UpdateHPBar();
    }
    private void HealFB(float heal)
    {
        HP += heal;
        if(HP>maxHP)
        {
            HP = maxHP;
        }
        UpdateHPBar();

    }
}
