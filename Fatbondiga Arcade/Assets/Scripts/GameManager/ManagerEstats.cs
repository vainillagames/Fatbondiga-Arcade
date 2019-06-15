
using UnityEngine;
using UnityEngine.UI;

public class ManagerEstats : MonoBehaviour {
    public static int estats;
    public float rampageTotal=500f;//inicialitzo a 500 pro es podrà modificar
    float rampage;
    float timer;
    int pointsGet;
    


    public string[] textIaia;
    public string[] textFatBondiga;
    public string[] textIncognita;

    public Text textPoints;
    public Text textTimer;
    public Image imageRampage;
    public Image[] imagePersonatges;//0 iaia 1 fatbondiga 2 incognita
    public Text[] textPersonatges;//0 iaia 1 fatbondiga 2 incognita


	// Use this for initialization
	void Start ()
    {
        timer = 0;
        estats = 0;
        DialogoControler();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        textTimer.text = timer.ToString();
        textPoints.text = pointsGet.ToString();
        

		
	}
    public void UpdateRampage(int points)
    {
       
        if(rampage<rampageTotal)
        {
            
            rampage = points/5;
            pointsGet = points;
            imageRampage.rectTransform.localScale = new Vector3(rampage / rampageTotal, 1, 1);
        }
        Debug.Log("points: "+ points);
        //controlador de estados TODO mejorarlo
        if ((rampage / 100.00f) == 1 || (rampage / 100f )== 2 || (rampage / 100f) == 3 || (rampage / 100f) == 4 /*|| (points / 100f) == 5*/)
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
