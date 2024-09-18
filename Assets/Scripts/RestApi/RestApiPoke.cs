using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class RestApiPoke : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pokeName;
    [SerializeField] private TextMeshProUGUI _pokeWidth;
    [SerializeField] private TextMeshProUGUI _pokeHeight;

    private JsonToPokemon _jsonToPokemon;
    private PokeCreator _pokeCreator;
    private Sprite _pokeSprite;
    private AudioClip _pokeAudioClip;
    private ShowPokeBtn _showPokeBtn;
    GameObject _shoewBtn;

    private void Awake()
    {
        _showPokeBtn = FindAnyObjectByType<ShowPokeBtn>();
        _shoewBtn = FindAnyObjectByType<ShowPokeBtn>().gameObject;
        //_shoewBtn.SetActive(false);
    }

    private void OnEnable()
    {
        _showPokeBtn._loadPokeAction += LoadPoke;
    }

    private void OnDisable()
    {
        _showPokeBtn._loadPokeAction -= LoadPoke;
    }
    public void LoadPoke()
    {
        _pokeSprite = null;
        _pokeAudioClip = null;

        PokeObj pokeObj = FindAnyObjectByType<PokeObj>();

        if (pokeObj != null) // ?
        {
            Destroy(pokeObj.gameObject);
        }

        int random = UnityEngine.Random.Range(1, 800);
        StartCoroutine(GetPokeByIndexAsync(random));

        StartCoroutine(CreatePoke());

    }
    private IEnumerator GetPokeByIndexAsync(int index)
    {
        string url = $"https://pokeapi.co/api/v2/pokemon/{index.ToString()}";

        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest(); 

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("�������: " + req.error);
        }
        else
        {
            _jsonToPokemon = JsonUtility.FromJson<JsonToPokemon>(req.downloadHandler.text);

            string newPokeName = char.ToUpper(_jsonToPokemon.name[0]) + _jsonToPokemon.name.Substring(1).ToLower(); 

            _pokeName.text = "Name:" + " " + newPokeName;
            _pokeHeight.text = "Height:" + " " + _jsonToPokemon.height;
            _pokeWidth.text = "Weight:" + " " + _jsonToPokemon.weight; 

            StartCoroutine(DownLoadPokeImg(_jsonToPokemon.sprites.front_default));
            StartCoroutine(DownLoadPokeCry(_jsonToPokemon.cries.latest));
        }
    }

    private IEnumerator DownLoadPokeImg(string url)
    {
        UnityWebRequest reqImg = UnityWebRequestTexture.GetTexture(url);
        yield return reqImg.SendWebRequest();

        if (reqImg.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("�������: " + reqImg.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(reqImg);
            texture.filterMode = FilterMode.Point;
            Rect rect = new Rect(0, 0, texture.width, texture.height);
            _pokeSprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        }
    }

    private IEnumerator DownLoadPokeCry(string url)
    {
        UnityWebRequest reqClip = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.OGGVORBIS);
        yield return reqClip.SendWebRequest();

        if (reqClip.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("�������: " + reqClip.error);
        }
        else
        {
            _pokeAudioClip = DownloadHandlerAudioClip.GetContent(reqClip);
        }
    }

    public IEnumerator CreatePoke()
    {

        _shoewBtn.SetActive(false);

        while (_jsonToPokemon == null || _pokeSprite == null || _pokeAudioClip == null)
        {
            yield return new WaitForSeconds(0.1f);
        }

        _shoewBtn.SetActive(true);
        string newPokeName = char.ToUpper(_jsonToPokemon.name[0]) + _jsonToPokemon.name.Substring(1).ToLower();
        PokeCreator pokemon = new PokeCreator(newPokeName, _jsonToPokemon.height, _jsonToPokemon.weight, _pokeSprite, _pokeAudioClip);
        pokemon.CreatePokemon();

    }

}
