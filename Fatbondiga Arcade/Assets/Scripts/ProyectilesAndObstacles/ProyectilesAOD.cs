
using UnityEngine;

public class ProyectilesAOD : MonoBehaviour
{
    public bool isDamagingOrHeal;
    public static int points=0;
   
    public float damageOHeal = 10;//lo empiezo en 10 pero va a variar dependiendo del proyectil o obstaculo o trozo de carne picada
    public GameObject canvas;
    
   
    
   void Start()
    {
        
        if(!isDamagingOrHeal)
        {
           
            canvas = GameObject.Find("Canvas");
        }
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            
            col.SendMessage((isDamagingOrHeal) ? "TakeDamage" : "HealFB", damageOHeal);
            //TODO massa test massa amb objectes
            if (!isDamagingOrHeal)
            {
                col.GetComponent<Transform>().localScale += new Vector3(0.01f, 0.01f, 0.01f);
                col.GetComponent<Rigidbody>().mass += 0.1f;
                points+=10;//ajustar aixo
                
                
                Debug.Log("points avans cast: " + points);
                //ManagerEstats.points=points;
                canvas.GetComponent<ManagerEstats>().UpdateRampage(points);
                Destroy(gameObject);
            }
        }
    }


}
