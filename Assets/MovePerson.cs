using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerson : MonoBehaviour
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
        float mV = Input.GetAxis("Horizontal");


        if (mV > 0)
        {
            anim.SetBool("Foreword", true);
            MovePlayer(mV);
        }
        else if (mV < 0)
        {
            anim.SetBool("Backword", true);
            MovePlayer(mV);
        }
        else
        {
        }

        if (Input.GetKey(KeyCode.G)) anim.SetBool("AttackKickL1", true);
        if (Input.GetKey(KeyCode.H)) anim.SetBool("AttackKickR1", true);
        if (Input.GetKey(KeyCode.J)) anim.SetBool("AttackR1", true);
        if (Input.GetKey(KeyCode.K)) anim.SetBool("AttackR2", true);
        if (Input.GetKey(KeyCode.O)) anim.SetBool("Death", true);

    }

    public void EndForeward()
    {
        anim.SetBool("Foreword", false);
    }

    public void EndBackword()
    {
        anim.SetBool("Backword", false);
    }

    public void EndAttackKickL1()
    {
        anim.SetBool("AttackKickL1", false);
    }

    public void EndAttackKickR1()
    {
        anim.SetBool("AttackKickR1", false);
    }

    public void EndAttackR1()
    {
        anim.SetBool("AttackR1", false);
    }

    public void EndAttackR2()
    {
        anim.SetBool("AttackR2", false);
    }

    public void EndDeath()
    {
        anim.SetBool("Death", false);
    }

    public void Hit()
    {

    }

    public void FootL()
    {

    }

    public void FootR()
    {

    }

    public void MovePlayer(float coeff)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.y, rigidBody.velocity.x, coeff * speed);
    }
}
