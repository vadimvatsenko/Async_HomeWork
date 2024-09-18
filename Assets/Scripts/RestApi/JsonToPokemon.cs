using System;

[Serializable]
public class JsonToPokemon
{
    public string name;
    public string height;
    public string weight;
    public Sprites sprites;
    public Cries cries;
}

[Serializable]
public class Sprites
{
    public string front_default;
    public string back_default;
}
[Serializable]

public class Cries
{
    public string latest;
    public string legacy;
}


