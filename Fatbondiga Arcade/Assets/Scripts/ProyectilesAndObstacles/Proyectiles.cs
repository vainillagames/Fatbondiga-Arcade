
using UnityEngine;

public class Proyectiles : MonoBehaviour
{
    Rigidbody rb;
    public float fuerzaL;
    public int tipoDeProyectil;

    public GameObject spawner;
    

    public GameObject[] proyectilesFantasma;
    public Transform[] canonsProyectiles ;

   void Awake()
    {
        spawner=GameObject.Find("SpawnProyectilesCocina");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (tipoDeProyectil == 5)
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 0, -fuerzaL));
            Invoke("destroyMandibula", 5);

        }
        else
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, fuerzaL, 0));
        }
       /* if (tipoDeProyectil == 5)
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 0, fuerzaL));
        }*/
        

        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Suelo")
        {
            if (tipoDeProyectil == 4)
            {
                CuchillosFantasma();

                /*  float comprova = 0;
                  comprova++;
                  Debug.Log("comprova" + comprova);*/
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void destroyMandibula()
    {
        spawner.SendMessage("ResetDentadura");
        Destroy(gameObject);
    }
    void CuchillosFantasma()
    {
        for (int i = 0; i < canonsProyectiles.Length; i++)
        {
            //int randomCF;
           // randomCF=Random.Range(0, 1);
            GameObject clone;
            Debug.Log("cuchillos fantasma for" + i);
            //TODO HACER VARIOS PROYECTILESFANTASMA
             clone=Instantiate(proyectilesFantasma[0], canonsProyectiles[i].position, canonsProyectiles[i].rotation);
            clone.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 2000);
            // Instantiate(proyectilesFantasma[0], canonsProyectiles[i].position, canonsProyectiles[i].rotation);
            //clone.GetComponent<Rigidbody>().velocity = transform.TransformVector(Vector3.forward * 10);

            // for (int j = 1; j < 34; j += 2)
        }
        
    }
}