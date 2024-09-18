using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeCreator
{
    public string name { get; private set; }
    public string height { get; private set; }
    public string weight { get; private set; }
    public Sprite sprite { get; private set; }
    public AudioClip audio { get; private set; }
    public AudioSource audioSource { get; private set; }

    public PokeCreator(string name, string height, string weight, Sprite sprite, AudioClip audio)
    {
        this.name = name;
        this.height = height;
        this.weight = weight;
        this.sprite = sprite;
        this.audio = audio;
    }



    public void CreatePokemon()
    {
        GameObject poke = new GameObject(name);
        poke.AddComponent<SpriteRenderer>().sprite = sprite;
        poke.AddComponent<AudioSource>();
        poke.AddComponent<PokeObj>().AddAudio(audio);

        poke.transform.position = Vector3.zero;
        poke.transform.localScale = Vector3.one * 6f;
    }
}
