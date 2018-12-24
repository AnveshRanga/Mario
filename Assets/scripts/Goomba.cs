using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : body
{
    Vector3 rotateAngle = new Vector3(0.0f, 1.0f, 0.0f);
    public float m_CurrentLaunchForce = 1.0f;
    float speed = 1.0f;
    bool isGrounded;
    Rigidbody m_Rigidbody;
    public Vector3 jump;
    public float jumpForce = 50.0f;

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
        Debug.Log("turn" + turn);
        Quaternion deltaRotation = Quaternion.Euler(rotateAngle * turn);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }

    public override void Walk(int walk) // 1-- forward , 2 -- left, 3 -- back , 4 --right
    {
        Vector3 moveDistance = Vector3.zero;

        switch (walk)
        {
            case 1:
                moveDistance = m_Rigidbody.transform.forward * speed;
                break;
            case 2:
                moveDistance = -m_Rigidbody.transform.right * speed;
                break;
            case 3:
                moveDistance = -m_Rigidbody.transform.forward * speed;
                break;
            case 4:
                moveDistance = m_Rigidbody.transform.right * speed;
                break;

        }
        m_Rigidbody.MovePosition(m_Rigidbody.position + moveDistance);
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.tag == "Smasher")
        //{
        //    GameObject.Destroy(gameObject);
        //}
    }
}
