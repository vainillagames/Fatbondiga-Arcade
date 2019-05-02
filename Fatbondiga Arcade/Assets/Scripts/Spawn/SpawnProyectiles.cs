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

    Vector3 fbPosition;

  
    
    //public Vector3 center;
    public Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        
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
            

            randProyectil = Random.Range(0, 2); //estatsReciber + 2) linea de codigo a modificar, de momento para testear se queda asi;
            
           
            //Vector3 spawnPosition=new Vector3
            //Vector3 pos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Spawn();
            yield return new WaitForSeconds(spawnWait);
        }
    }
    public void Spawn()
    {
        fbPosition = new Vector3(fb.transform.position.x, gameObject.transform.position.y ,fb.transform.position.z);
        Vector3 pos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
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
        }
            
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(32,8,0,0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
}
