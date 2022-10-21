using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxController : MonoBehaviour
{
    int nbTriggerActive = 0;

    List<GameObject> objectsIn = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        nbTriggerActive++;
        objectsIn.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        nbTriggerActive--;
        objectsIn.Remove(other.gameObject);
    }

    public bool IsTriggering(int minimumTrigger = 1)
    {
        return nbTriggerActive >= minimumTrigger;
    }

    public void RemoveAllTriggerIn()
    {
        foreach(GameObject obj in objectsIn)
        {
            Destroy(obj.transform.parent.gameObject);
        }

        objectsIn.Clear();

        nbTriggerActive = 0;
    }
}
