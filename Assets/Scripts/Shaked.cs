using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

[RequireComponent(typeof(Rigidbody))]
public class Shaked : MonoBehaviour
{
    bool isShaked = false;
    bool previousIsShaked = false;

    Vector3 previousVelocity;

    Rigidbody rb;

    [SerializeField]
    float minShakeVelocityMatch = 0.0015f;

    [SerializeField]
    int minGoodShakeVelocityCount = 12;

    [SerializeField]
    int minBadShakeVelocityCount = 30;

    int goodShakeVelocityCount = 0;
    int badShakeVelocityCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb)
        {
            float velocityMatch = Vector3.Magnitude(previousVelocity - rb.velocity);

            if(velocityMatch > minShakeVelocityMatch)
            {
                goodShakeVelocityCount++;
            }
            else
            {
                badShakeVelocityCount++;

                if(badShakeVelocityCount > minBadShakeVelocityCount)
                {
                    goodShakeVelocityCount = 0;
                    badShakeVelocityCount = 0;
                    isShaked = false;
                }
            }

            if(goodShakeVelocityCount > minGoodShakeVelocityCount)
            {
                isShaked = true;
            }
        }

        if (isShaked != previousIsShaked)
        {
            previousIsShaked = isShaked;

            Debug.Log(isShaked);
        }
    }
}
