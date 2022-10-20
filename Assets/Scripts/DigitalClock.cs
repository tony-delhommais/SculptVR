using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    int minutes = 0;

    [SerializeField]
    GameObject Minutes1;

    [SerializeField]
    GameObject Minutes2;

    int secondes = 0;

    [SerializeField]
    GameObject Secondes1;

    [SerializeField]
    GameObject Secondes2;

    [SerializeField]
    GameObject Dot1;

    [SerializeField]
    GameObject Dot2;

    SevenSegmentsDisplay Minutes1SevenSegment;
    SevenSegmentsDisplay Minutes2SevenSegment;
    SevenSegmentsDisplay Secondes1SevenSegment;
    SevenSegmentsDisplay Secondes2SevenSegment;

    [SerializeField]
    Color displayColor;

    // Start is called before the first frame update
    void Start()
    {
        if(Minutes1) Minutes1SevenSegment = Minutes1.GetComponent<SevenSegmentsDisplay>();
        if(Minutes2) Minutes2SevenSegment = Minutes2.GetComponent<SevenSegmentsDisplay>();
        if(Secondes1) Secondes1SevenSegment = Secondes1.GetComponent<SevenSegmentsDisplay>();
        if(Secondes2) Secondes2SevenSegment = Secondes2.GetComponent<SevenSegmentsDisplay>();

        if(Minutes1SevenSegment) Minutes1SevenSegment.SetColor(displayColor);
        if(Minutes2SevenSegment) Minutes2SevenSegment.SetColor(displayColor);
        if(Secondes1SevenSegment) Secondes1SevenSegment.SetColor(displayColor);
        if(Secondes2SevenSegment) Secondes2SevenSegment.SetColor(displayColor);

        if (Dot1) Dot1.GetComponent<Renderer>().material.color = displayColor;
        if (Dot2) Dot2.GetComponent<Renderer>().material.color = displayColor;

        SetMinutes(2);
        SetSecondes(0);
    }

    public void SetEntireNumber(int n)
    {
        if (n < 0 || n >= 10000)
            return;

        int sec = n % 100;
        int min = (int)((n - sec) / 100);

        SetMinutes(min);
        SetSecondes(sec);
    }

    public void SetMinutes(int n)
    {
        if (n < 0 || n >= 100)
            return;

        minutes = n;

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

        secondes = n;

        int unite = n % 10;
        int dizaine = (int)((n - unite) / 10);

        if (Secondes1SevenSegment != null)
            Secondes1SevenSegment.SetToN(dizaine);

        if (Secondes2SevenSegment != null)
            Secondes2SevenSegment.SetToN(unite);
    }
}
