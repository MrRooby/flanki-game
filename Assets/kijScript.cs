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

    private Quaternion originalRotation;


    void Start()
    {
        originalRotation = transform.rotation;
        kijRigBod.position.Set(startX, startY, startZ);
        gravity(false);
    }

    // Zdecyduj czy wy³¹czaæ gravitacjê czy usypiaæ

    void Update()
    {
        drawArc();
        float rotationX = (float)kijRigBod.rotation.eulerAngles.x;
        float rotationZ = Mathf.Atan( rotationX * Mathf.Deg2Rad );
        float rotationY = -Mathf.Tan(rotationX * Mathf.Deg2Rad);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravity(true);
            if (kijRigBod.rotation.x == 0)
                kijRigBod.velocity = new Vector3(0, rotationY, 1) * kijThrowStr;
            else
            {
                kijRigBod.velocity = new Vector3(0, rotationY, rotationZ) * kijThrowStr;
                //kijRigBod.velocity = new Vector3(0, 0, 1) * kijThrowStr;
                print("Rotation y: " + rotationY);
                print("Rotation z: " + rotationZ);
            }

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            kijRigBod.Sleep();
            gravity(false);
            kijRigBod.position = new Vector3(2, 3, -21f);
            transform.rotation = originalRotation;
        }
    }

    private void gravity(bool isGrav)
    {
        if (isGrav)
            Physics.gravity = new Vector3(0, -9.8f, 0);
        else if (!isGrav)
            Physics.gravity = new Vector3(0, 0, 0);
    }

    private void drawArc()
    {
        kijThrowArc.enabled = true;

        kijThrowArc.positionCount = Mathf.CeilToInt( resolution/timeBetweenPoints ) + 1;
        Vector3 startPosition = kijRigBod.position;
        Vector3 startVelocity;

        // Pobaw siê z globalnymi zmiennymi bo jesteœ takim porz¹dnym programist¹
        float rotationX = (float)kijRigBod.rotation.eulerAngles.x;
        float rotationZ = Mathf.Atan(rotationX * Mathf.Deg2Rad);
        float rotationY = -Mathf.Tan(rotationX * Mathf.Deg2Rad);

        if (kijRigBod.rotation.x == 0)
            startVelocity = new Vector3(0, rotationY, 1) * kijThrowStr;
        else
            startVelocity = new Vector3(0, rotationY, rotationZ) * kijThrowStr;

        int i = 0;
        kijThrowArc.SetPosition(i, startPosition);

        for(float time = 0; time < resolution; time += timeBetweenPoints) 
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (-9.8f / 2f * time * time);

            kijThrowArc.SetPosition(i, point);
        }
    }
}
