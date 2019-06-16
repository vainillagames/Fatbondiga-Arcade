using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    protected DashButton joyButton;
    protected Joystick joystick;

	private Rigidbody rb;
    public float velocidad;

    public Transform handle;
    protected bool dash;

    bool coolDown;
    void Start()
	{
       
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<DashButton>();
        coolDown = true;


		//rb=GetComponent<Rigidbody>();
	}
	void FixedUpdate()
	{
        
        /*float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical =Input.GetAxis("Vertical");

		Vector3 movement= new Vector3(moveHorizontal,0.0f,moveVertical);

		rb.AddForce(movement*velocidad*Time.deltaTime);*/
        var rigidbody = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(((joystick.Horizontal + Input.GetAxis("Horizontal"))*velocidad)*Time.deltaTime, rigidbody.velocity.y, ((joystick.Vertical  + Input.GetAxis("Vertical"))*velocidad)*Time.deltaTime);
        rigidbody.velocity=(movement);

        //massa rapid i no rota bé//rigidbody.velocity = new Vector3(joystick.Horizontal *velocidad, rigidbody.velocity.y, joystick.Vertical * velocidad);

        if (!dash && (joyButton.Pressed||Input.GetButton("Jump")))
        {
            dash = true;
            //dependiendo de la dirección del joystick haremos un dash hacia arriba abajo o izquierda i derecha. lo he limitado ha estos 4 lados el joistic mismo indica los 4 lados del dash
            //de este modo si vas en diagonal podras hacer un dash hacia uno de estos lados solo miviendo un poco el joystick hacia arriva o hacia abajo de manera milimetrica i rapida
            if(coolDown)
            {
                FindObjectOfType<AudioManager>().Play("dash");
                coolDown = false;
                Invoke("resetCooldown", 1);
                if (handle.transform.localPosition.x > 0 & handle.transform.localPosition.x > Mathf.Abs(handle.transform.localPosition.y))
                {

                    rigidbody.velocity += Vector3.right * 200f;
                    Debug.Log("3");
                    //Debug.Log("x" + handle.transform.localPosition.x + " y" + Mathf.Abs(handle.transform.localPosition.y));
                }

                if (handle.transform.localPosition.x < 0 & Mathf.Abs(handle.transform.localPosition.x) > Mathf.Abs(handle.transform.localPosition.y))
                {
                    rigidbody.velocity = Vector3.left * 200f;
                    Debug.Log("4");
                }
                if (handle.transform.localPosition.y > 0 & handle.transform.localPosition.y > Mathf.Abs(handle.transform.localPosition.x))
                {
                    rigidbody.velocity += Vector3.forward * 200f;
                    Debug.Log("1");
                }

                if (handle.transform.localPosition.y < 0 & Mathf.Abs(handle.transform.localPosition.y) > Mathf.Abs(handle.transform.localPosition.x))
                {
                    rigidbody.velocity = Vector3.back * 200f;
                    Debug.Log("2");
                }
            }
                      
          
          
          
            
        }
        if( dash && !(joyButton.Pressed || Input.GetButton("Jump")))
        {
            dash = false;
        }





	}
    void resetCooldown()//para conseguir que no se pueda espamear el dash 1 s
    {
        coolDown = true;
    }
}
