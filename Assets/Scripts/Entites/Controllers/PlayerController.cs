using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<float> OnMoveEvent;
    public PaddleSO paddleSO;

    public void CallMoveEvent(float input)
    {
        OnMoveEvent?.Invoke(input);
    }

    public void CallCopyBallEvent()
    {

    }

}
