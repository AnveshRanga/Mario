using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class hero : MonoBehaviour
{
    public GameObject Mario; //always hero posses some body
    public GameObject PossesionBody; //always hero posses some body
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PossesionBody.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            PossesionBody.GetComponent<body>().Walk(2);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            PossesionBody.GetComponent<body>().Walk(4);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            PossesionBody.GetComponent<body>().Walk(3);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            PossesionBody.GetComponent<body>().Walk(1);
        }

        if (Input.GetAxis("Strafe") < 0)
        {
            PossesionBody.GetComponent<body>().Turn(1);
        }
        else if (Input.GetAxis("Strafe") > 0)
        {
            PossesionBody.GetComponent<body>().Turn(-1);
        }

        if (Input.GetButtonDown("Jump")) {
            PossesionBody.GetComponent<body>().Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            PossesionBody.GetComponent<body>().Attack();
        }


        if (Input.GetButtonDown("Fire2"))
        {
            if (PossesionBody.name != Mario.name)
            {
                Mario.SetActive(true);
                GameObject.DestroyObject(PossesionBody);
                SetPossesionBody(Mario);
            }
        }


    }
    void LateUpdate()
    {
        if (PossesionBody != null)
        {
            transform.position = PossesionBody.transform.position + offset;
            transform.rotation = PossesionBody.transform.rotation;
        }
    }

    public void SetPossesionBody( GameObject go)
    {
        PossesionBody = go;
    }
}
