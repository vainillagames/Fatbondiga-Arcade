using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosMobiles : MonoBehaviour
{
    public float puntsMaxToOpen;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (ProyectilesAOD.points >= puntsMaxToOpen)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }



}
