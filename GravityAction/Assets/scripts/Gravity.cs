using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Vector3 localGravity;
    public Rigidbody rb;
    private bool isReverse = false;
    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReverse == true)
        {
            rb.AddForce(localGravity, ForceMode.Acceleration);

        }
        else
        {
            rb.AddForce(-localGravity, ForceMode.Acceleration);
        }
    }
    public void setFalse()
    {
        isReverse = false;
    }
    public void setTrue()
    {
        isReverse = true;
    }
}
