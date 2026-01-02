using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    Camera _mainCamera;

    void OnLoadLobbySceneCompleted()
    {
        Debug.Log("Lobby Scene Load Completed");
        _mainCamera.enabled = true;
    }

    void Start()
    {
        _mainCamera.enabled = false;
        LoadingSystem._onSceneLoadCompleted += OnLoadLobbySceneCompleted;
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        LoadingSystem._onSceneLoadCompleted -= OnLoadLobbySceneCompleted;
    }
}
