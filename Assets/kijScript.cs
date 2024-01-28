using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kijScript : MonoBehaviour
{
    public Rigidbody kijRigBod;
    public float kijThrowStr = 25;
    public float startX = 2;
    public float startY = 5;
    public float startZ = -12;

    void Start()
    {
        kijRigBod.position.Set(startX, startY, startZ);
        //kijRigBod.velocity = new Vector3(0, 0, 1) * kijThrowStr;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            kijRigBod.velocity = new Vector3(0, 0, 1) * kijThrowStr;   
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            kijRigBod.position = new Vector3(2, 3, (float)-21);
        }
    }
}
