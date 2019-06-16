
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
    public GameObject imageDialag;
    public GameObject[] imagePersonatges;//0 iaia 1 fatbondiga 2 incognita
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
        textTimer.text = timer.ToString("f2");
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
                imageDialag.SetActive(true);
                imagePersonatges[1].SetActive(true);
                textPersonatges[1].text = textFatBondiga[0];
                Invoke("RespuestaE1", 4);
                break;
            case 1:
                imageDialag.SetActive(true);
                imagePersonatges[0].SetActive(true);
                textPersonatges[0].text = textIaia[0];
                Invoke("CleanText", 4);
                break;
            case 2:
                imageDialag.SetActive(true);
                imagePersonatges[1].SetActive(true);
                textPersonatges[1].text = textFatBondiga[1];
                Invoke("RespuestaE2", 4);
                break;
            case 3:
                imageDialag.SetActive(true);
                imagePersonatges[0].SetActive(true);
                textPersonatges[0].text = textIaia[2];
                Invoke("RespuestaE3", 4.5f);
                break;
            case 4:
                imageDialag.SetActive(true);
                imagePersonatges[1].SetActive(true);
                textPersonatges[1].text = textFatBondiga[3];
                Invoke("CleanText", 3);
                break;


        }
    }
    void RespuestaE1()
    {
        imagePersonatges[1].SetActive(false);
        imagePersonatges[2].SetActive(true);
        textPersonatges[1].text = "";
        textPersonatges[2].text = textIncognita[0];
        Invoke("CleanText",4);
        
    }
    void RespuestaE2()
    {
        imagePersonatges[1].SetActive(false);
        imagePersonatges[2].SetActive(true);
        textPersonatges[1].text = "";
        textPersonatges[2].text = textIncognita[1];
        Invoke("CleanText", 5);
    }
    void RespuestaE3()
    {
        imagePersonatges[0].SetActive(false);
        imagePersonatges[1].SetActive(true);
        textPersonatges[0].text = "";
        textPersonatges[1].text = textFatBondiga[2];
        Invoke("CleanText", 4.5f);

    }
    void CleanText()
    {
        imageDialag.SetActive(false);
        imagePersonatges[0].SetActive(false);
        imagePersonatges[1].SetActive(false);
        imagePersonatges[2].SetActive(false);

        textPersonatges[0].text = "";
        textPersonatges[1].text = "";
        textPersonatges[2].text = "";
    }
    
}
