using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public Rigidbody rigi;
    public float movementSpeed;
    public float rotationSpeed;
    public GameObject poop;
    public bool canHold;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        canHold = false;
    }
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
        if (Input.GetKeyDown(KeyCode.Space) && !canHold)
        {
            ShootPoop();
        }
    }
    void ShootPoop()
    {
        //poop.transform.Translate();
        transform.GetChild(1).parent = null;
       
        poop.GetComponent<Rigidbody>().velocity = transform.forward * 10;
        canHold = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Poop")
        {
            if (canHold)
            {
                poop.gameObject.GetComponent<Transform>().SetParent(transform);
                canHold = false;
            }
        }
    }
}
