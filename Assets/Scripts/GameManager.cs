using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    GameObject heightOrigin;

    List<Capla> caplaList = new List<Capla>();

    Capla currentHighestCapla = null;

    [SerializeField]
    int minutesStartTimer = 2;
    [SerializeField]
    int secondesStartTimer = 0;

    int minutes = 2;
    int secondes = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Multiple instances of GameManager");
    }

    public float GetHeightOrigin()
    {
        if (heightOrigin == null)
            return 0.0f;

        return heightOrigin.transform.position.y;
    }

    public void AddNewCapla(Capla newCapla)
    {
        caplaList.Add(newCapla);
    }

    public void RemoveCapla(Capla oldCapla)
    {
        caplaList.Remove(oldCapla);
    }

    public float GetCurrentMaxHeight()
    {
        if (!currentHighestCapla)
            return 0;

        return currentHighestCapla.GetHeight();
    }

    void ResetTimer()
    {
        minutes = minutesStartTimer;
        secondes = secondesStartTimer;
    }

    public void RestartTimer()
    {
        ResetTimer();

        StartCoroutine(UpdateTimer());
    }

    public int GetTimerMinutes()
    {
        return minutes;
    }

    public int GetTimerSecondes()
    {
        return secondes;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();

        StartCoroutine(ComputeNewMaxHeight());
    }

    IEnumerator ComputeNewMaxHeight()
    {
        while(true)
        {
            caplaList = caplaList.OrderBy(w => w.GetHeight()).ToList();

            currentHighestCapla = caplaList[caplaList.Count - 1];

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator UpdateTimer()
    {
        while(minutes != 0 || secondes != 0)
        {
            yield return new WaitForSeconds(1);

            Debug.Log(minutes + "  " + secondes);

            if (secondes == 0)
            {
                minutes--;
                secondes = 59;
            }
            else
            {
                secondes--;
            }
        }

        Debug.Log(minutes + "  " + secondes);

        yield return null;
    }
}
