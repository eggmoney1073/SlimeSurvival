using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressTestClass : MonoBehaviour
{
    void Start()
    {
        Addressables.InitializeAsync();
        //assetHandle = Addressables.LoadAssetAsync<GameObject>("PlayerPrefab");

        Addressables.LoadAssetAsync<GameObject>("Assets/4.Prefabs/Guns/Bullet.prefab").Completed += handle =>
        {
            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                GameObject playerPrefab = handle.Result;
                Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            }
        };
    }


    private void OnDestroy()
    {
        Addressables.ReleaseInstance(this.gameObject);
    }
}
