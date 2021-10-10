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


        //打开Console 观察生命周期函数的调用顺序
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
