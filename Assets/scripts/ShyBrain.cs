using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyBrain : MonoBehaviour
{
    public bool activeBrain;
    public GameObject Hero;
    public float minDistance = 20.0f;
    public float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeBrain) {
            if (Vector3.Distance(transform.position, Hero.transform.position) > minDistance)
            {
                MoveAway();
            }
        }
    }


    void MoveAway ()
    {
        // The step size is equal to speed times frame time.
        float step = -1* speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, Hero.transform.position, step);
    }
}
