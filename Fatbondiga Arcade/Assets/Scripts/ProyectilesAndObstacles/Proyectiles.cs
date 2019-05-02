
using UnityEngine;

public class Proyectiles : MonoBehaviour
{
    Rigidbody rb;
    public float fuerzaL;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, fuerzaL, 0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
