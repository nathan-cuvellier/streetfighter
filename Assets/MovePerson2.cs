using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerson2 : MonoBehaviour
{

    public Rigidbody rigidBody;
    public float speed;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        if (rigidBody == null) rigidBody = GetComponent<Rigidbody>();

        if (anim == null) anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float mV = Input.GetAxis("Vertical");


        if (mV > 0)
        {
            //anim.SetInteger("Walk", 1);
            MovePlayer(mV);
        }
        else if (mV < 0)
        {
            //anim.SetInteger("Walk", -1);
            MovePlayer(mV);
        }
        else
        {
            //anim.SetInteger("Walk", 0);
        }

    }

    public void MovePlayer(float coeff)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.y, rigidBody.velocity.x, coeff * speed);
    }
}
