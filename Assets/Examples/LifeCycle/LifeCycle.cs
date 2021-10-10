using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private readonly AssetMgr _assetMgr = new AssetMgr();

    // Start is called before the first frame update
    async void Start()
    {
        UnityEngine.Debug.LogError("Before Await");
        await _assetMgr.InstantiateAsync("Assets/RawResources/Cube.prefab");
        UnityEngine.Debug.LogError("After Await");


        //��Console �۲��������ں����ĵ���˳��
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
