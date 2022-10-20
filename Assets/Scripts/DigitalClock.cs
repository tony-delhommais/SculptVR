using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    [SerializeField]
    GameObject Minutes1;

    [SerializeField]
    GameObject Minutes2;

    [SerializeField]
    GameObject Secondes1;

    [SerializeField]
    GameObject Secondes2;

    SevenSegmentsDisplay Minutes1SevenSegment;
    SevenSegmentsDisplay Minutes2SevenSegment;
    SevenSegmentsDisplay Secondes1SevenSegment;
    SevenSegmentsDisplay Secondes2SevenSegment;

    // Start is called before the first frame update
    void Start()
    {
        if(Minutes1) Minutes1SevenSegment = Minutes1.GetComponent<SevenSegmentsDisplay>();
        if(Minutes2) Minutes2SevenSegment = Minutes2.GetComponent<SevenSegmentsDisplay>();
        if(Secondes1) Secondes1SevenSegment = Secondes1.GetComponent<SevenSegmentsDisplay>();
        if(Secondes2) Secondes2SevenSegment = Secondes2.GetComponent<SevenSegmentsDisplay>();

        SetMinutes(2);
        SetSecondes(0);
    }

    public void SetMinutes(int n)
    {
        if (n < 0 || n >= 100)
            return;

        int unite = n % 10;
        int dizaine = (int)((n - unite) / 10);

        if (Minutes1SevenSegment != null)
            Minutes1SevenSegment.SetToN(dizaine);

        if (Minutes2SevenSegment != null)
            Minutes2SevenSegment.SetToN(unite);
    }

    public void SetSecondes(int n)
    {
        if (n < 0 || n >= 100)
            return;

        int unite = n % 10;
        int dizaine = (int)((n - unite) / 10);

        if (Secondes1SevenSegment != null)
            Secondes1SevenSegment.SetToN(dizaine);

        if (Secondes2SevenSegment != null)
            Secondes2SevenSegment.SetToN(unite);
    }
}
