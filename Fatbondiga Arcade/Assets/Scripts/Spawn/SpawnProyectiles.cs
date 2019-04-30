using System.Collections;
using UnityEngine;

public class SpawnProyectiles : MonoBehaviour
{
    public GameObject[] test1;//TODO canviarlo por array de game objects  CON TODOS LOS "PROYECTILES"
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randProyectil;
    
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
            randProyectil = Random.Range(0, 2); 
            //Vector3 spawnPosition=new Vector3
            //Vector3 pos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Spawn();
            yield return new WaitForSeconds(spawnWait);
        }
    }
    public void Spawn()
    {
        //switch case 5 
        Vector3 pos = transform.position + new Vector3(Random.Range(-size.x / 2,size.x/2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(test1[randProyectil], pos, Quaternion.identity); // gameObject.transform.rotation
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(32,8,0,0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
}
