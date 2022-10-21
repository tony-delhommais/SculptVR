using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class PrimaryButtonEvent : UnityEvent<bool> { }

public class PrimaryButtonWatcher : MonoBehaviour
{
    public static PrimaryButtonWatcher instance;

    public PrimaryButtonEvent primaryButtonPressRight;
    public PrimaryButtonEvent primaryButtonPressLeft;

    private bool lastButtonStateRight = false;
    private bool lastButtonStateLeft = false;
    private List<InputDevice> devicesWithPrimaryButton;

    private void Awake()
    {
        if (primaryButtonPressRight == null)
        {
            primaryButtonPressRight = new PrimaryButtonEvent();
        }

        if (primaryButtonPressLeft == null)
        {
            primaryButtonPressLeft = new PrimaryButtonEvent();
        }

        if (instance == null)
            instance = this;
        else
            Debug.LogError("Multiple instrance of PrimaryButtonWatcher");

        devicesWithPrimaryButton = new List<InputDevice>();
    }

    void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
        {
            InputDevices_deviceConnected(device);
        }

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithPrimaryButton.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out discardedValue))
        {
            devicesWithPrimaryButton.Add(device); // Add any devices that have a primary button.
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithPrimaryButton.Contains(device))
            devicesWithPrimaryButton.Remove(device);
    }

    void Update()
    {
        bool tempStateRight = false;
        foreach (var device in devicesWithPrimaryButton)
        {
            if (!device.name.Contains("Right"))
                continue;

            bool primaryButtonState = false;
            tempStateRight = device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState) // did get a value
                        && primaryButtonState // the value we got
                        || tempStateRight; // cumulative result from other controllers
        }

        if (tempStateRight != lastButtonStateRight) // Button state changed since last frame
        {
            primaryButtonPressRight.Invoke(tempStateRight);
            lastButtonStateRight = tempStateRight;
        }

        bool tempStateLeft = false;
        foreach (var device in devicesWithPrimaryButton)
        {
            if (!device.name.Contains("Left"))
                continue;

            bool primaryButtonState = false;
            tempStateLeft = device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState) // did get a value
                        && primaryButtonState // the value we got
                        || tempStateLeft; // cumulative result from other controllers
        }

        if (tempStateLeft != lastButtonStateLeft) // Button state changed since last frame
        {
            primaryButtonPressLeft.Invoke(tempStateLeft);
            lastButtonStateLeft = tempStateLeft;
        }
    }
}