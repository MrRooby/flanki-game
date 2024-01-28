using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butelkaScript : MonoBehaviour
{
    public Rigidbody butelkaRigBod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            butelkaRigBod.position = new Vector3(2, 1, (float)-1.5);
            butelkaRigBod.rotation = Quaternion.identity;
        }
    }
}
