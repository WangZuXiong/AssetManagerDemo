using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleUI : BaseUI
{   
    // Start is called before the first frame update
     void Start()
    {
        InitImage();

        LoadTexture();

        InstantiateGameObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        AssetMgr.Release();
    }


    async void InitImage()
    {
        var img = transform.Find("Image").GetComponent<Image>();
        img.sprite = await AssetMgr.LoadSpriteAsync("Assets/RawResources/Textures/Sprite Atlas.spriteatlas", "Texture1");
    }

    async void LoadTexture()
    {
        var texture2D = await AssetMgr.LoadAssetAsync<Texture2D>("Assets/RawResources/Textures/Texture1.png");
        var color = texture2D.GetPixel(0, 0);
        UnityEngine.Debug.LogError(color);
    }

    async void InstantiateGameObject()
    {
        var content = GameObject.Find("Content").transform;
        var go = await AssetMgr.InstantiateAsync("Assets/RawResources/Cube.prefab", content);
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one * 2;
    }
}
