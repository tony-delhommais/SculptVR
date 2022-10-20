using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capla : MonoBehaviour
{
    float height = 0;

    public float GetHeight()
    {
        return height;
    }

    void ComputeHeight()
    {
        height = transform.position.y - GameManager.instance.GetHeightOrigin();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.AddNewCapla(this);
    }

    private void OnDestroy()
    {
        GameManager.instance.RemoveCapla(this);
    }

    // Update is called once per frame
    void Update()
    {
        ComputeHeight();
    }
}
