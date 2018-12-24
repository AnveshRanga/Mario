using System.Collections;
using UnityEngine;

public class RandomBrain : MonoBehaviour
{
    int m_randomDirection;
    int m_currentDirection = 1;
    public GameObject Hero;
    public float minDistance = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_randomDirection = 1;
        StartCoroutine(PickNewDirection());
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (m_randomDirection == m_currentDirection)
        {
            GetComponent<body>().Walk(1);
        }
        else {
            if (m_randomDirection > m_currentDirection) {
                GetComponent<body>().Turn(1);
                m_currentDirection++;
            } else {
                GetComponent<body>().Turn(-1);
                m_currentDirection--;    
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Border") {
            m_randomDirection = Random.Range(1, 4);
        }
    }

    IEnumerator PickNewDirection()
    {
        yield return new WaitForSeconds(5.0f);
        m_randomDirection = Random.Range(1, 4);
        Debug.Log(m_randomDirection +","+ m_currentDirection);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2.0f);
        if (Vector3.Distance(transform.position, Hero.transform.position) > minDistance)
        {
            transform.LookAt(Hero.transform);
            GetComponent<body>().Attack();
        }
    }
}
