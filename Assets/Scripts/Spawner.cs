using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

[RequireComponent(typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{
    bool isShaked = false;

    Vector3 previousVelocity;

    Rigidbody rb;

    [SerializeField]
    float minShakeVelocityMatch = 0.4f;

    [SerializeField]
    int minGoodShakeVelocityCount = 7;

    [SerializeField]
    int minBadShakeVelocityCount = 7;

    int goodShakeVelocityCount = 0;
    int badShakeVelocityCount = 0;

    [SerializeField]
    GameObject caplaPrefab;

    [SerializeField]
    [Min(1)]
    int spawnPerSeconds = 5;

    bool spawnCaplaCoroutineIsStarted = false;

    List<float> randomX = new List<float>();
    List<float> randomY = new List<float>();
    List<float> randomZ = new List<float>();

    List<Color> randomColor = new List<Color>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        randomX.Add(0.15f);
        randomX.Add(0.2f);
        randomX.Add(0.25f);

        randomY.Add(0.01355f);
        randomY.Add(0.0267f);
        randomY.Add(0.03f);

        randomZ.Add(0.035f);
        randomZ.Add(0.04f);
        randomZ.Add(0.06f);

        randomColor.Add(new Color(0, 0, 0, 1.0f));
        randomColor.Add(new Color(1, 0, 0, 0.5f));
        randomColor.Add(new Color(0, 1, 0, 0.5f));
        randomColor.Add(new Color(0, 0, 1, 0.5f));
        randomColor.Add(new Color(1, 1, 0, 0.5f));
        randomColor.Add(new Color(1, 0, 1, 0.5f));
        randomColor.Add(new Color(0, 1, 1, 0.5f));
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
                goodShakeVelocityCount = Mathf.Clamp(++goodShakeVelocityCount, 0, minGoodShakeVelocityCount);

                badShakeVelocityCount = Mathf.Clamp(--badShakeVelocityCount, 0, minBadShakeVelocityCount);
            }
            else
            {
                goodShakeVelocityCount = Mathf.Clamp(--goodShakeVelocityCount, 0, minGoodShakeVelocityCount);

                badShakeVelocityCount = Mathf.Clamp(++badShakeVelocityCount, 0, minBadShakeVelocityCount);
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
                yield return new WaitForSeconds(1.0f / spawnPerSeconds);

                Vector3 randomScale = new Vector3(RandomInList(randomX), RandomInList(randomY), RandomInList(randomZ));

                GameObject spawned = Instantiate(caplaPrefab);
                spawned.transform.position = transform.position;
                spawned.GetComponentsInChildren<Transform>()[1].localScale = randomScale;
                spawned.GetComponentInChildren<Renderer>().material.color = RandomInList(randomColor);
                spawned.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.8f;
            }
        }

        yield return null;
    }

    float RandomInList(List<float> possibilities)
    {
        int randomPos = Random.Range(0, possibilities.Count);

        return possibilities[randomPos];
    }

    Color RandomInList(List<Color> possibilities)
    {
        int randomPos = Random.Range(0, possibilities.Count);

        return possibilities[randomPos];
    }
}
