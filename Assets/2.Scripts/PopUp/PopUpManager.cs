using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : SingletonDontDestroyOnLoad<PopUpManager>
{
    Stack<PopUpBase> _activePopUpStack = new Stack<PopUpBase>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
