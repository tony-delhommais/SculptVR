using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SevenSegmentsDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject Segment1;

    [SerializeField]
    GameObject Segment2;

    [SerializeField]
    GameObject Segment3;

    [SerializeField]
    GameObject Segment4;

    [SerializeField]
    GameObject Segment5;

    [SerializeField]
    GameObject Segment6;

    [SerializeField]
    GameObject Segment7;

    [NonSerialized]
    public Color displayColor;

    private void Start()
    {
        SetColor(displayColor);

        SetTo0();
    }

    public void SetColor(Color newDisplayColor)
    {
        displayColor = newDisplayColor;
        
        if (Segment1) Segment1.GetComponent<Renderer>().material.color = displayColor;
        if (Segment2) Segment2.GetComponent<Renderer>().material.color = displayColor;
        if (Segment3) Segment3.GetComponent<Renderer>().material.color = displayColor;
        if (Segment4) Segment4.GetComponent<Renderer>().material.color = displayColor;
        if (Segment5) Segment5.GetComponent<Renderer>().material.color = displayColor;
        if (Segment6) Segment6.GetComponent<Renderer>().material.color = displayColor;
        if (Segment7) Segment7.GetComponent<Renderer>().material.color = displayColor;
    }

    public void SetToN(int n)
    {
        if (n < 0 || n >= 10)
            return;

        switch(n)
        {
            case 0:
                SetTo0();
                break;
            case 1:
                SetTo1();
                break;
            case 2:
                SetTo2();
                break;
            case 3:
                SetTo3();
                break;
            case 4:
                SetTo4();
                break;
            case 5:
                SetTo5();
                break;
            case 6:
                SetTo6();
                break;
            case 7:
                SetTo7();
                break;
            case 8:
                SetTo8();
                break;
            case 9:
                SetTo9();
                break;
            default:
                break;
        }
    }

    public void SetToNone()
    {
        if (Segment1 != null) Segment1.SetActive(false);
        if (Segment2 != null) Segment2.SetActive(false);
        if (Segment3 != null) Segment3.SetActive(false);
        if (Segment4 != null) Segment4.SetActive(false);
        if (Segment5 != null) Segment5.SetActive(false);
        if (Segment6 != null) Segment6.SetActive(false);
        if (Segment7 != null) Segment7.SetActive(false);
    }

    void SetTo0()
    {
        if(Segment1 != null) Segment1.SetActive(true);
        if(Segment2 != null) Segment2.SetActive(true);
        if(Segment3 != null) Segment3.SetActive(true);
        if(Segment4 != null) Segment4.SetActive(true);
        if(Segment5 != null) Segment5.SetActive(true);
        if(Segment6 != null) Segment6.SetActive(true);
        if(Segment7 != null) Segment7.SetActive(false);
    }

    void SetTo1()
    {
        if (Segment1 != null) Segment1.SetActive(false);
        if (Segment2 != null) Segment2.SetActive(true);
        if (Segment3 != null) Segment3.SetActive(true);
        if (Segment4 != null) Segment4.SetActive(false);
        if (Segment5 != null) Segment5.SetActive(false);
        if (Segment6 != null) Segment6.SetActive(false);
        if (Segment7 != null) Segment7.SetActive(false);
    }

    void SetTo2()
    {
        if (Segment1 != null) Segment1.SetActive(true);
        if (Segment2 != null) Segment2.SetActive(true);
        if (Segment3 != null) Segment3.SetActive(false);
        if (Segment4 != null) Segment4.SetActive(true);
        if (Segment5 != null) Segment5.SetActive(true);
        if (Segment6 != null) Segment6.SetActive(false);
        if (Segment7 != null) Segment7.SetActive(true);
    }

    void SetTo3()
    {
        if (Segment1 != null) Segment1.SetActive(true);
        if (Segment2 != null) Segment2.SetActive(true);
        if (Segment3 != null) Segment3.SetActive(true);
        if (Segment4 != null) Segment4.SetActive(true);
        if (Segment5 != null) Segment5.SetActive(false);
        if (Segment6 != null) Segment6.SetActive(false);
        if (Segment7 != null) Segment7.SetActive(true);
    }

    void SetTo4()
    {
        if (Segment1 != null) Segment1.SetActive(false);
        if (Segment2 != null) Segment2.SetActive(true);
        if (Segment3 != null) Segment3.SetActive(true);
        if (Segment4 != null) Segment4.SetActive(false);
        if (Segment5 != null) Segment5.SetActive(false);
        if (Segment6 != null) Segment6.SetActive(true);
        if (Segment7 != null) Segment7.SetActive(true);
    }

    void SetTo5()
    {
        if (Segment1 != null) Segment1.SetActive(true);
        if (Segment2 != null) Segment2.SetActive(false);
        if (Segment3 != null) Segment3.SetActive(true);
        if (Segment4 != null) Segment4.SetActive(true);
        if (Segment5 != null) Segment5.SetActive(false);
        if (Segment6 != null) Segment6.SetActive(true);
        if (Segment7 != null) Segment7.SetActive(true);
    }

    void SetTo6()
    {
        if (Segment1 != null) Segment1.SetActive(true);
        if (Segment2 != null) Segment2.SetActive(false);
        if (Segment3 != null) Segment3.SetActive(true);
        if (Segment4 != null) Segment4.SetActive(true);
        if (Segment5 != null) Segment5.SetActive(true);
        if (Segment6 != null) Segment6.SetActive(true);
        if (Segment7 != null) Segment7.SetActive(true);
    }

    void SetTo7()
    {
        if (Segment1 != null) Segment1.SetActive(true);
        if (Segment2 != null) Segment2.SetActive(true);
        if (Segment3 != null) Segment3.SetActive(true);
        if (Segment4 != null) Segment4.SetActive(false);
        if (Segment5 != null) Segment5.SetActive(false);
        if (Segment6 != null) Segment6.SetActive(false);
        if (Segment7 != null) Segment7.SetActive(false);
    }

    void SetTo8()
    {
        if (Segment1 != null) Segment1.SetActive(true);
        if (Segment2 != null) Segment2.SetActive(true);
        if (Segment3 != null) Segment3.SetActive(true);
        if (Segment4 != null) Segment4.SetActive(true);
        if (Segment5 != null) Segment5.SetActive(true);
        if (Segment6 != null) Segment6.SetActive(true);
        if (Segment7 != null) Segment7.SetActive(true);
    }

    void SetTo9()
    {
        if (Segment1 != null) Segment1.SetActive(true);
        if (Segment2 != null) Segment2.SetActive(true);
        if (Segment3 != null) Segment3.SetActive(true);
        if (Segment4 != null) Segment4.SetActive(true);
        if (Segment5 != null) Segment5.SetActive(false);
        if (Segment6 != null) Segment6.SetActive(true);
        if (Segment7 != null) Segment7.SetActive(true);
    }
}
