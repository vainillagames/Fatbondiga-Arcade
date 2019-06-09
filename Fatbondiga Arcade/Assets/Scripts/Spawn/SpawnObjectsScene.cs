
using UnityEngine;

public class SpawnObjectsScene : MonoBehaviour
{
    public GameObject[] obstacles;//3 vidres diferents
    public GameObject carnPicada;//només una variació de carn picada
    public float rangeX;
    public float rangeZ;

    float positionX;
    float positionZ;

    int ranR;
    int ranO;
    // Start is called before the first frame update
    void Start()
    {
        positionX=gameObject.transform.position.x;
        positionZ = gameObject.transform.position.z;

        for (int i = 1; i < rangeX; i+=2)
        {
            for (int j = 1; j < rangeZ; j += 2)
            {
                ranR = Random.Range(0, 10);
                //Debug.Log("random " + ranR);
                if (ranR <= 7)
                {
                    //carn
                    Vector3 posicionesCarneP = new Vector3(i+positionX, 0.56f, j+positionZ);
                    Instantiate(carnPicada, posicionesCarneP, Quaternion.identity);
                    
                   // Debug.Log("posicions " + posicionesCarneP);
                }
                else
                {
                    //obstacles;
                    ranO = Random.Range(0, 3);
                    Vector3 posicionesObstaculos = new Vector3(i+positionX, 0.70f, j+positionZ);
                    Instantiate(obstacles[ranO], posicionesObstaculos, Quaternion.identity);//TODO canviar posicionesObstaculos per gameObject.transform.localposition+ posicionesObstaculos(i,1,j);
                }
                
            
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
