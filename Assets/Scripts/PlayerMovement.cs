using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variables and such
    public Rigidbody rb;
    public float forwardForce = 500f;
    public float sidewaysForce = 100f;
    

    // FixedUpdate is called once per frame (using Fixed because physics are involved)
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);


        //if (Input.GetKey("w"))
        //{
        //    rb.AddForce(0, 0, 500 * Time.deltaTime);
        //}
        //if (Input.GetKey("s"))
        //{
        //    rb.AddForce(0, 0, -500 * Time.deltaTime);
        //}
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < .9f)
        {
            GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<GameManager>().EndGame("fall");
        }
    }
}
