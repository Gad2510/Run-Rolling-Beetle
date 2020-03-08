using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    Rigidbody rigi;
    Rigidbody poopRigid;

    [SerializeField]
    float movementSpeed, rotationSpeed;    
    bool canHold, isMoving;

    public bool IsMoving
    {
        get { return isMoving; }
    }

    public bool CanHold
    {
        get { return canHold; }
    }

    void Start()
    {
        poopRigid = transform.GetChild(1).GetComponent<Rigidbody>();
        rigi = GetComponent<Rigidbody>();
        canHold = false;
        isMoving = false;
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0,  y* Time.deltaTime * movementSpeed);

        isMoving = (!poopRigid.IsSleeping())&& y>0.1f;

        if (Input.GetKeyDown(KeyCode.Space) && !canHold)
        {
            ShootPoop();
        }
    }
    void ShootPoop()
    {
        poopRigid.transform.parent = null;
       
        poopRigid.velocity = transform.forward * 10;
        canHold = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Poop")
        {
            if (canHold)
            {
                poopRigid.transform.SetParent(transform);
                canHold = false;
            }
        }
    }
}
