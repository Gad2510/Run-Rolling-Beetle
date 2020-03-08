using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    Animator animBeetle;
    Rigidbody rigi;
    public Rigidbody poopRigid;

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
        animBeetle = GetComponent<Animator>();

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
        float tringulate = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        isMoving = (!poopRigid.IsSleeping())&& tringulate>0.1f;
        animBeetle.SetBool("isWalking", tringulate > 0.1f);

        if (Input.GetKeyDown(KeyCode.Space) && !canHold)
        {
            animBeetle.SetTrigger("shoot");
            //ShootPoop();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animBeetle.SetTrigger("dead");
        }
    }
    public void ShootPoop()
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
                animBeetle.SetTrigger("holding");
                poopRigid.transform.SetParent(transform);
                canHold = false;
            }
        }
    }
}
