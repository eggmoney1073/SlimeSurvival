using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public static class LoadingSystem
{
    public enum SceneState
    {
        None = -1,
        Title,
        Lobby,
        Game,
        Max
    }

    static AsyncOperation _loadingState;

    /// <summary>
    /// 로딩 진행률
    /// </summary>
    public static float _loadingProcess 
    { get 
        {
            if (_loadingState != null)
                return _loadingState.progress;
            else
                return 0f;
        }
    }

    public static Action _adreessableInitialize;

    /// <summary>
    /// 비동기 씬 로드 인덱스
    /// </summary>
    /// <param name="sceneIndex"></param>
    public static void LoadScneneAsync(int sceneIndex)
    {
        if (_loadingState != null)
            return;

        _loadingState = SceneManager.LoadSceneAsync(sceneIndex);
    }

    /// <summary>
    /// 비동기 씬 로드 이름
    /// </summary>
    /// <param name="sceneName"></param>
    public static void LoadScneneAsync(SceneState sceneName)
    {
        if (_loadingState != null)
            return;

        _loadingState = SceneManager.LoadSceneAsync((int)sceneName);
    }

    //IEnumerator Co_LoadScene()
    //{
    //    assetHandle = Addressables.LoadAssetAsync<GameObject>("PlayerPrefab");
    //}

    //IEnumerator Co_LoadAddressable()
    //{
    //    if (_adreessableInitialize != null)
    //        _adreessableInitialize.Invoke();
    //    yield return null;
    //}
}
