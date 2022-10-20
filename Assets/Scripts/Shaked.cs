using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

[RequireComponent(typeof(Rigidbody))]
public class Shaked : MonoBehaviour
{
    bool isShaked = false;

    Vector3 previousVelocity;

    Rigidbody rb;

    [SerializeField]
    float minShakeVelocityMatch = 0.02f;

    [SerializeField]
    int minGoodShakeVelocityCount = 15;

    [SerializeField]
    int minBadShakeVelocityCount = 15;

    int goodShakeVelocityCount = 0;
    int badShakeVelocityCount = 0;

    [SerializeField]
    GameObject caplaPrefab;

    bool spawnCaplaCoroutineIsStarted = false;

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
            previousVelocity = rb.velocity;

            if (velocityMatch > minShakeVelocityMatch)
            {
                if (++goodShakeVelocityCount > minGoodShakeVelocityCount) goodShakeVelocityCount = minGoodShakeVelocityCount;

                if (--badShakeVelocityCount < 0) badShakeVelocityCount = 0;
            }
            else
            {
                if (--goodShakeVelocityCount < 0) goodShakeVelocityCount = 0;

                if (++badShakeVelocityCount > minBadShakeVelocityCount) badShakeVelocityCount = minBadShakeVelocityCount;
            }

            if (goodShakeVelocityCount >= badShakeVelocityCount)
            {
                isShaked = true;
            }
            else
            {
                isShaked = false;
            }
        }

        if (isShaked)
        {
            if(!spawnCaplaCoroutineIsStarted)
            {
                StartCoroutine(SpawnCapla());
                spawnCaplaCoroutineIsStarted = true;
            }
        }
        else
        {
            if(spawnCaplaCoroutineIsStarted)
            {
                StopAllCoroutines();
                spawnCaplaCoroutineIsStarted = false;
            }
        }
    }

    IEnumerator SpawnCapla()
    {
        if(caplaPrefab)
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);

                GameObject spawned = Instantiate(caplaPrefab);

                spawned.transform.position = transform.position;
                spawned.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.8f;
            }
        }

        yield return null;
    }
}
