using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPokeBtn : MonoBehaviour
{
    public event Action _loadPokeAction;

    public void LoadPokemon()
    {
        _loadPokeAction?.Invoke();
    }
}
