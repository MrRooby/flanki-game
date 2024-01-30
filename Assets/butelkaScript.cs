using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butelkaScript : MonoBehaviour
{
    public Rigidbody butelkaRigBod;
    private Quaternion ogRotation;
    // Start is called before the first frame update
    void Start()
    {
        ogRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            butelkaRigBod.Sleep();
            butelkaRigBod.position = new Vector3(2, 1, (float)-1.5);
            transform.rotation = ogRotation;
        }
    }
}
