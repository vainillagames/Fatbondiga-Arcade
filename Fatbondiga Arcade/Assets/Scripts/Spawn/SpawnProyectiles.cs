using System.Collections;
using UnityEngine;

public class SpawnProyectiles : MonoBehaviour
{
    public GameObject fb;
    public GameObject[] test1;//TODO canviarlo por array de game objects  CON TODOS LOS "PROYECTILES"
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    int estatsReciber;
    int randProyectil;
    
    public bool stop;
    bool flagReciver;

    Vector3 fbPosition;
    Vector3 pos;
    Vector3 pos2;//posición dentadura viviente

  
    
    //public Vector3 center;
    public Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        flagReciver = true;
        StartCoroutine(waitSpawner());
       
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        //test
        /*if (Input.GetButtonDown("Jump"))
        {
          
            Spawn();
        }*/
    }
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while(!stop)
        {
            //TODO crear case per fer augmentar la dificultat a partir duna puntuació //case del estado managerEstats
            estatsReciber = ManagerEstats.estats;
            

            randProyectil = Random.Range(0, estatsReciber+2); //estatsReciber + 2) linea de codigo a modificar, de momento para testear se queda asi;
            
           
            //Vector3 spawnPosition=new Vector3
            //Vector3 pos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Spawn();
            yield return new WaitForSeconds(spawnWait);
        }
    }
    public void Spawn()
    {
        fbPosition = new Vector3(fb.transform.position.x, gameObject.transform.position.y ,fb.transform.position.z);
       pos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        //switch case 5 al incrementar la dificultad la abuela hace mas ataques
        switch (estatsReciber)
        {
            default:
                  Instantiate(test1[randProyectil], pos, Quaternion.identity); // gameObject.transform.rotation
                Debug.Log("instanciate proyectil OJO DE AGUILA");
                Instantiate(test1[2], fbPosition, Quaternion.identity);
                break;
             
            case 0:
               
                Instantiate(test1[randProyectil], pos, Quaternion.identity); // gameObject.transform.rotation

                break;
            case 1:

                spawnMostWait = 1.5f;// parametro a valancear para hacer la curva de dificultad mejor
                if (randProyectil == 2)
                {
                    Debug.Log("instanciate proyectil OJO DE AGUILA");
                    Instantiate(test1[2], fbPosition, Quaternion.identity);
                }
                
                else
                    Instantiate(test1[randProyectil], pos, Quaternion.identity); // gameObject.transform.rotation

                break;
            case 2:

                spawnMostWait = 1.3f;
                if (randProyectil == 2)
                {
                    Debug.Log("instanciate proyectil OJO DE AGUILA");
                    Instantiate(test1[2], fbPosition, Quaternion.identity);
                }
                else if (randProyectil == 3)
                {
                    Invoke("CuchillosFantasma", 0.5f);//delay para instanciar el cuchillofantasma para controlar la curva de dificultad

                }
                else
                    Instantiate(test1[randProyectil], pos, Quaternion.identity);
                break;

            case 3:

                //spawnMostWait = 1.2f;
                if (randProyectil == 2)
                {
                    Debug.Log("instanciate proyectil OJO DE AGUILA");
                    Instantiate(test1[2], fbPosition, Quaternion.identity);
                }
                else if (randProyectil == 3)
                {
                    Invoke("CuchillosFantasma", 0.3f);//delay para instanciar el cuchillofantasma para controlar la curva de dificultad

                }
                else if(randProyectil==4)
                {
                    
                    Invoke("MilHojas", 0.5f);
                }
                else
                    Instantiate(test1[randProyectil], pos, Quaternion.identity);
                break;
            case 4:

               // spawnMostWait = 1.1f;
                if (randProyectil == 2)
                {
                    Debug.Log("instanciate proyectil OJO DE AGUILA");
                    Instantiate(test1[2], fbPosition, Quaternion.identity);
                }
                else if (randProyectil == 3)
                {
                    Invoke("CuchillosFantasma", 0.3f);//delay para instanciar el cuchillofantasma para controlar la curva de dificultad

                }
                else if (randProyectil == 4)
                {

                    Invoke("MilHojas", 0.5f);
                }
                else if (randProyectil == 5)

                {
                    Invoke("DentaduraViviente", 0.6f);
                }
                else
                    Instantiate(test1[randProyectil], pos, Quaternion.identity);
                break;
            case 5:
                //lluvia de de ataques
                spawnMostWait = 0.8f;
                if (randProyectil == 2)
                {
                    Debug.Log("instanciate proyectil OJO DE AGUILA");
                    Instantiate(test1[2], fbPosition, Quaternion.identity);
                }
                else if (randProyectil == 3)
                {
                    Invoke("CuchillosFantasma", 0.3f);//delay para instanciar el cuchillofantasma para controlar la curva de dificultad

                }
                else if (randProyectil == 4)
                {
                  
                    
                        Invoke("MilHojas", 0.5f);
                    
                }
                else if (randProyectil == 5)

                {
                    if (flagReciver)
                    {
                        Invoke("DentaduraViviente", 0.6f);
                    }

                }
                else
                    Instantiate(test1[randProyectil], pos, Quaternion.identity);
                break;

        }
            
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(32,8,0,0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
    void CuchillosFantasma()
    {
        Instantiate(test1[randProyectil], pos, Quaternion.identity);

    }
    void MilHojas()
    {
        Debug.Log("milhojas");
        int randomMH;
       
        for(int j = 0; j<5;j++)
        {
            
            for (int i = 0; i < 5; i++)
            {
                randomMH = Random.Range(0, 1);
                Vector3 positionR = new Vector3(i, 1, j);
                Instantiate(test1[randomMH],gameObject.transform.position + positionR , Quaternion.identity);//mil hojas
            }
        }
        
        //Instantiate(test1[randProyectil], pos, Quaternion.identity);
    }
    void DentaduraViviente()
    {
        Vector3 positionD = new Vector3(Random.Range(-size.x / 2, size.x / 2)+gameObject.transform.position.x, 1,35);
        Instantiate(test1[4], positionD, Quaternion.identity);
    }
    public void ResetDentadura()
    {
        flagReciver = true;

    }
}
