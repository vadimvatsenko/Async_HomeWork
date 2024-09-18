using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundBtn : MonoBehaviour
{
    public event Action _playSoundAction;

    public void PlaySound()
    {
        _playSoundAction?.Invoke();
    }
}
