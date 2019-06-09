
using UnityEngine;
using UnityEngine.UI;

public class ManagerEstats : MonoBehaviour {
    public static int estats;
    public float rampageTotal=500f;//inicialitzo a 500 pro es podrà modificar
    float rampage;
    float timer;
    


    public string[] textIaia;
    public string[] textFatBondiga;
    public string[] textIncognita;

    public Text textTimer;
    public Image imageRampage;
    public Image[] imagePersonatges;//0 iaia 1 fatbondiga 2 incognita
    public Text[] textPersonatges;//0 iaia 1 fatbondiga 2 incognita


	// Use this for initialization
	void Start ()
    {
        timer = 0.0f;
        estats = 0;
        DialogoControler();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        textTimer.text = timer.ToString();
        

		
	}
    public void UpdateRampage(int points)
    {
        rampage =  points;
        imageRampage.rectTransform.localScale =new Vector3( rampage/rampageTotal,1,1);
        if(rampage<=rampageTotal)
        {
            rampage = rampageTotal;
        }
        Debug.Log("points: "+ points);
        //controlador de estados TODO mejorarlo
        if ((points / 100.00f) == 1 || (points / 100f )== 2 || (points / 100f) == 3 || (points / 100f) == 4 /*|| (points / 100f) == 5*/)
        {
            estats++;
            DialogoControler();
            Debug.Log("estat? " + estats);
        }

    }
    
    public void DialogoControler()
    {
        //TODO MAS TEXTO I ACTIVAR O DESACTIVAR SPRITES DE LAS CARAS DE CADA PERSONAJE JUNTO CON UN FONDO PARA QUE SE VEA MEJOR LA LETRA
        //switch case
        switch (estats)
        {
            case 0:
                textPersonatges[1].text = textFatBondiga[0];
                Invoke("RespuestaE1", 4);
                break;
            case 1:
                textPersonatges[0].text = textIaia[0];
                Invoke("CleanText", 4);
                break;
            case 2:
                textPersonatges[1].text = textFatBondiga[1];
                Invoke("CleanText", 4);
                break;


        }
    }
    void RespuestaE1()
    {
        textPersonatges[1].text = "";
        textPersonatges[2].text = textIncognita[0];
        Invoke("CleanText",4);
        
    }
    void RespuestaE2()
    {
    }
    void CleanText()
    {
        textPersonatges[0].text = "";
        textPersonatges[1].text = "";
        textPersonatges[2].text = "";
    }
    
}
