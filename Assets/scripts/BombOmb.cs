using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombOmb : body
{
    // Start is called before the first frame update
    Vector3 rotateAngle = new Vector3(0.0f, 1.0f, 0.0f);
    public float m_CurrentLaunchForce = 1.0f;
    float speed = 0.2f;
    bool isGrounded;
    Rigidbody m_Rigidbody;
    public Rigidbody Bomb;
    public Transform m_FireTransform;

  
    public override void Attack()
    {
        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody Ball = Instantiate(Bomb, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        Ball.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

    }

    public override void Jump()
    {

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
