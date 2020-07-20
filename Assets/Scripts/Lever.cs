using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : Interactible
{
    public UnityEvent OnLeverEnabled;
    public UnityEvent OnLeverDisabled;

    public override void Interact()
    {
    }


    private void EnableLever()
    {
        if (OnLeverEnabled != null)
        {
            OnLeverEnabled.Invoke();
        }
    }

    private void DisableLever()
    {
        if (OnLeverDisabled != null)
        {
            OnLeverDisabled.Invoke();
        }
    }

    public void LeverChanged(string newState)
    {
        switch (newState)
        {
            case "On":
                EnableLever();
                break;
            case "Off":
                DisableLever();
                break;
            default:
                Debug.Log("unknown value");
                break;
        }
    }
}