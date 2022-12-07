using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScenes : MonoBehaviour
{
    
    void Start()
    {
        UiManager.GetInstance().SetEventSystem();
        UiManager.GetInstance().OpenUI("UIMainMenu");
    }
    
}
