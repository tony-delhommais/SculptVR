using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    [SerializeField]
    GameObject clockDisplay;

    [SerializeField]
    GameObject scoreDisplay;

    DigitalClock digitalClock;

    DigitalClock digitalScoreDisplay;

    [SerializeField]
    GameObject resetBox;

    BoxController resetBoxController;
    Material resetBoxMaterial;

    [SerializeField]
    GameObject MenuExit;

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

        StopCoroutine(UpdateTimer());

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

    void UpdateClockTime()
    {
        if(digitalClock)
        {
            digitalClock.SetMinutes(minutes);
            digitalClock.SetSecondes(secondes);
        }
    }

    void DisplayScore(int score)
    {
        digitalScoreDisplay.SetEntireNumber(score);
    }

    void OnAButtonRightPressed(bool isPressed)
    {
        if (isPressed)
        {
            if(menuToggle)
            {
                Application.Quit();
            }

            else if (resetBoxController)
            {
                if (resetBoxController.IsTriggering())
                {
                    RestartTimer();

                    resetBoxController.RemoveAllTriggerIn();

                    if(digitalScoreDisplay) digitalScoreDisplay.SetEntireNumber(0);
                }
            }
        }
    }
    bool menuToggle = false;
    void OnXButtonLeftPressed(bool isPressed)
    {
        if(isPressed)
        {
            if(!menuToggle)
            {
                menuToggle = true;
            }
            else
            {
                menuToggle = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(clockDisplay != null) digitalClock = clockDisplay.GetComponent<DigitalClock>();
        if(scoreDisplay != null) digitalScoreDisplay = scoreDisplay.GetComponent<DigitalClock>();

        if(resetBox != null) resetBoxController = resetBox.GetComponent<BoxController>();
        if(resetBox != null) resetBoxMaterial = resetBox.GetComponentInChildren<Renderer>().material;

        PrimaryButtonWatcher.instance.primaryButtonPressRight.AddListener(OnAButtonRightPressed);
        PrimaryButtonWatcher.instance.primaryButtonPressLeft.AddListener(OnXButtonLeftPressed);

        ResetTimer();

        DisplayScore(0);

        StartCoroutine(ComputeNewMaxHeight());

        StartCoroutine(TesterResetGame());
    }

    private void Update()
    {
        if(MenuExit) MenuExit.SetActive(menuToggle);
    }

    IEnumerator ComputeNewMaxHeight()
    {
        while(true)
        {
            if(caplaList.Count > 0)
            {
                caplaList = caplaList.OrderBy(w => w.GetHeight()).ToList();

                currentHighestCapla = caplaList[caplaList.Count - 1];
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator UpdateTimer()
    {
        while(minutes != 0 || secondes != 0)
        {
            UpdateClockTime();

            if (secondes == 0)
            {
                minutes--;
                secondes = 59;
            }
            else
            {
                secondes--;
            }

            yield return new WaitForSeconds(1);
        }

        UpdateClockTime();

        if (currentHighestCapla) DisplayScore((int)(currentHighestCapla.GetHeight() * 100));

        yield return null;
    }

    IEnumerator TesterResetGame()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);

            if(resetBoxController)
            {
                bool isTrigger = resetBoxController.IsTriggering();

                if(isTrigger)
                {
                    resetBoxMaterial.color = new Color(0, 1, 0);
                }
                else
                {
                    resetBoxMaterial.color = new Color(1, 0, 0);
                }
            }
        }
    }
}
