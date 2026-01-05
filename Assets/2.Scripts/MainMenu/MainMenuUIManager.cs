using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    public void Button_Start()
    {
        MainMenuManager._Instance.GoToNextScene();
    }

    public void Button_Options()
    {

    }

    public void Button_Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();            
#endif
    }

}
