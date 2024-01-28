using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kijScript : MonoBehaviour
{
    public Rigidbody kijRigBod;

    [SerializeField]
    private LineRenderer kijThrowArc;
    [SerializeField]
    private Transform ReleasePosition;

    [Header("Arc Settings")]
    [SerializeField]
    [Range(10, 100)]
    private int resolution = 10;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    public float timeBetweenPoints = 0.1f;

    [Header("Throw Variables")]
    [SerializeField]
    [Range(0, 50)]
    private float kijThrowStr = 25;

    public float startX = 2;
    public float startY = 5;
    public float startZ = -12;


    void Start()
    {
        kijRigBod.position.Set(startX, startY, startZ);
    }


    void Update()
    {
        drawArc();

        if (Input.GetKeyDown(KeyCode.Space))
        {  
            kijRigBod.velocity = new Vector3(0, 0, 1) * kijThrowStr;   
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            kijRigBod.position = new Vector3(2, 3, -21f);
        }
    }


    private void drawArc()
    {
        kijThrowArc.enabled = true;

        kijThrowArc.positionCount = Mathf.CeilToInt( resolution/timeBetweenPoints ) + 1;
        Vector3 startPosition = kijRigBod.position;
        Vector3 startVelocity = kijThrowStr * kijRigBod.transform.forward / kijRigBod.mass;
        int i = 0;
        kijThrowArc.SetPosition(i, startPosition);

        for(float time = 0; time < resolution; time += timeBetweenPoints) 
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);

            kijThrowArc.SetPosition(i, point);
        }
    }
}
