using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxController : MonoBehaviour
{
    List<GameObject> objectsIn = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent)
        {
            if (other.transform.parent.gameObject.CompareTag("Capla"))
            {
                objectsIn.Add(other.transform.parent.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent)
        {
            if (other.transform.parent.gameObject.CompareTag("Capla"))
            {
                objectsIn.Remove(other.transform.parent.gameObject);
            }
        }
    }

    public bool IsTriggering(int minimumTrigger = 1)
    {
        return objectsIn.Count >= minimumTrigger;
    }

    public void RemoveAllTriggerIn()
    {
        foreach(GameObject obj in objectsIn)
        {
            Destroy(obj);
        }

        objectsIn.Clear();
    }
}
