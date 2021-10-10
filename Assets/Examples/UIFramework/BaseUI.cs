using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    private AssetMgr _assetMgr;
    protected AssetMgr AssetMgr
    {
        get
        {
            if (_assetMgr == null)
            {
                _assetMgr = new AssetMgr();
            }
            return _assetMgr;
        }
    }

    protected async Task<T> LoadAssetAsync<T>(string path) where T : UnityEngine.Object
    {
        Debug.Log("path:" + path);
        var result = await AssetMgr.LoadAssetAsync<T>(path);
        return result;
    }

    protected async Task<IList<T>> LoadAssetsAsync<T>(List<string> keys) where T : UnityEngine.Object
    {
        var result = await AssetMgr.LoadAssetsAsync<T>(keys);
        return result;
    }

    protected async Task<GameObject> InstantiateAsync(string path, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true)
    {
        var result = await AssetMgr.InstantiateAsync(path, parent, instantiateInWorldSpace, trackHandle);
        return result;
    }

    protected async Task<T> InstantiateAsync<T>(string path, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true)
    {
#if UNITY_EDITOR
        if (typeof(T) == typeof(GameObject))
        {
            Debug.LogError("请使用 InstantiateAsync()方法，而不是InstantiateAsync<T>()");
        }    
#endif

        var result = await AssetMgr.InstantiateAsync(path, parent, instantiateInWorldSpace, trackHandle);
        return result.GetComponent<T>(); ;
    }

    /// <summary>
    /// 加载图集中的某个精灵
    /// </summary>
    /// <param name="path"></param>
    /// <param name="spriteName"></param>
    /// <returns></returns>
    protected Task<Sprite> LoadSpriteAsync(string path, string spriteName)
    {
        return AssetMgr.LoadSpriteAsync(path, spriteName);
    }

    public virtual void Release()
    {
        if (_assetMgr != null)
        {
            _assetMgr.Release();
            _assetMgr.Dispose();
            _assetMgr = null;
        }
    }

    //protected virtual void Awake()
    //{

    //}

    //protected virtual void Start()
    //{

    //}

    //protected virtual void OnDestroy()
    //{

    //}

}

