using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class mario : body
{
    public Vector3 jump;
    public float jumpForce = 50.0f;
    public Vector3 rotateAngle = new Vector3(0.0f, 2.0f, 0.0f);
    public bool isGrounded;
    Rigidbody m_Rigidbody;
    public GameObject Hero;

    public override void Attack()
    {
        
    }

    public override void Jump()
    {
        if (isGrounded)
        {
            m_Rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public override void Turn(int turn)
    {
        Quaternion deltaRotation = Quaternion.Euler(rotateAngle * turn);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }

    public override void Walk(int walk) // 1-- forward , 2 -- left, 3 -- back , 4 --right
    {

        Vector3 moveDistance = Vector3.zero;
        switch (walk) {
            case 1:
                moveDistance = m_Rigidbody.transform.forward;
                break;
            case 2:
                moveDistance = -m_Rigidbody.transform.right;
                break;
            case 3:
                moveDistance = -m_Rigidbody.transform.forward;
                break;
            case 4:
                moveDistance = m_Rigidbody.transform.right;
                break;

        }
        m_Rigidbody.MovePosition(m_Rigidbody.position + moveDistance);
    }
    
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        // die by touching enemy
        //if (transform.position.y == 0.5f)
        //{
        //    if (collision.collider.tag == "Enemy")
        //    {
        //        GameObject.Destroy(gameObject);
        //    }
        //}


        // possess body 
        if (collision.collider.tag == "Enemy")
        {
            Hero.GetComponent<hero>().SetPossesionBody( collision.collider.gameObject);
            gameObject.SetActive(false);
        }
    }

}
