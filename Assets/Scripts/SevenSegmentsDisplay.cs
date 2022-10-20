using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenSegmentsDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject Tick1;

    [SerializeField]
    GameObject Tick2;

    [SerializeField]
    GameObject Tick3;

    [SerializeField]
    GameObject Tick4;

    [SerializeField]
    GameObject Tick5;

    [SerializeField]
    GameObject Tick6;

    [SerializeField]
    GameObject Tick7;

    private void Start()
    {
        SetTo0();
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

    void SetTo0()
    {
        if(Tick1 != null) Tick1.SetActive(true);
        if(Tick2 != null) Tick2.SetActive(true);
        if(Tick3 != null) Tick3.SetActive(true);
        if(Tick4 != null) Tick4.SetActive(true);
        if(Tick5 != null) Tick5.SetActive(true);
        if(Tick6 != null) Tick6.SetActive(true);
        if(Tick7 != null) Tick7.SetActive(false);
    }

    void SetTo1()
    {
        if (Tick1 != null) Tick1.SetActive(false);
        if (Tick2 != null) Tick2.SetActive(true);
        if (Tick3 != null) Tick3.SetActive(true);
        if (Tick4 != null) Tick4.SetActive(false);
        if (Tick5 != null) Tick5.SetActive(false);
        if (Tick6 != null) Tick6.SetActive(false);
        if (Tick7 != null) Tick7.SetActive(false);
    }

    void SetTo2()
    {
        if (Tick1 != null) Tick1.SetActive(true);
        if (Tick2 != null) Tick2.SetActive(true);
        if (Tick3 != null) Tick3.SetActive(false);
        if (Tick4 != null) Tick4.SetActive(true);
        if (Tick5 != null) Tick5.SetActive(true);
        if (Tick6 != null) Tick6.SetActive(false);
        if (Tick7 != null) Tick7.SetActive(true);
    }

    void SetTo3()
    {
        if (Tick1 != null) Tick1.SetActive(true);
        if (Tick2 != null) Tick2.SetActive(true);
        if (Tick3 != null) Tick3.SetActive(true);
        if (Tick4 != null) Tick4.SetActive(true);
        if (Tick5 != null) Tick5.SetActive(false);
        if (Tick6 != null) Tick6.SetActive(false);
        if (Tick7 != null) Tick7.SetActive(true);
    }

    void SetTo4()
    {
        if (Tick1 != null) Tick1.SetActive(false);
        if (Tick2 != null) Tick2.SetActive(true);
        if (Tick3 != null) Tick3.SetActive(true);
        if (Tick4 != null) Tick4.SetActive(false);
        if (Tick5 != null) Tick5.SetActive(false);
        if (Tick6 != null) Tick6.SetActive(true);
        if (Tick7 != null) Tick7.SetActive(true);
    }

    void SetTo5()
    {
        if (Tick1 != null) Tick1.SetActive(true);
        if (Tick2 != null) Tick2.SetActive(false);
        if (Tick3 != null) Tick3.SetActive(true);
        if (Tick4 != null) Tick4.SetActive(true);
        if (Tick5 != null) Tick5.SetActive(false);
        if (Tick6 != null) Tick6.SetActive(true);
        if (Tick7 != null) Tick7.SetActive(true);
    }

    void SetTo6()
    {
        if (Tick1 != null) Tick1.SetActive(true);
        if (Tick2 != null) Tick2.SetActive(false);
        if (Tick3 != null) Tick3.SetActive(true);
        if (Tick4 != null) Tick4.SetActive(true);
        if (Tick5 != null) Tick5.SetActive(true);
        if (Tick6 != null) Tick6.SetActive(true);
        if (Tick7 != null) Tick7.SetActive(true);
    }

    void SetTo7()
    {
        if (Tick1 != null) Tick1.SetActive(true);
        if (Tick2 != null) Tick2.SetActive(true);
        if (Tick3 != null) Tick3.SetActive(true);
        if (Tick4 != null) Tick4.SetActive(false);
        if (Tick5 != null) Tick5.SetActive(false);
        if (Tick6 != null) Tick6.SetActive(false);
        if (Tick7 != null) Tick7.SetActive(false);
    }

    void SetTo8()
    {
        if (Tick1 != null) Tick1.SetActive(true);
        if (Tick2 != null) Tick2.SetActive(true);
        if (Tick3 != null) Tick3.SetActive(true);
        if (Tick4 != null) Tick4.SetActive(true);
        if (Tick5 != null) Tick5.SetActive(true);
        if (Tick6 != null) Tick6.SetActive(true);
        if (Tick7 != null) Tick7.SetActive(true);
    }

    void SetTo9()
    {
        if (Tick1 != null) Tick1.SetActive(true);
        if (Tick2 != null) Tick2.SetActive(true);
        if (Tick3 != null) Tick3.SetActive(true);
        if (Tick4 != null) Tick4.SetActive(true);
        if (Tick5 != null) Tick5.SetActive(false);
        if (Tick6 != null) Tick6.SetActive(true);
        if (Tick7 != null) Tick7.SetActive(true);
    }
}
