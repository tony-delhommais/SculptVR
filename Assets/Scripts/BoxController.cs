using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxController : MonoBehaviour
{
    int nbTriggerActive = 0;

    private void OnTriggerEnter(Collider other)
    {
        nbTriggerActive++;
    }

    private void OnTriggerExit(Collider other)
    {
        nbTriggerActive--;
    }

    public bool IsTriggering(int minimumTrigger = 1)
    {
        return nbTriggerActive >= minimumTrigger;
    }
}
