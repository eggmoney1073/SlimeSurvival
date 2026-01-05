using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : SingletonDontDestroyOnLoad<PopUpManager>
{
    Stack<PopUpBase> _popUpQueue = new Stack<PopUpBase>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
