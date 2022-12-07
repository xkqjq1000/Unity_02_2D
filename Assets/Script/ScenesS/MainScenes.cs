using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenes : MonoBehaviour
{
    
    void Start()
    {
        ObjectManager.GetInstance().CreateCharacter();

        UiManager.GetInstance().SetEventSystem();
        UiManager.GetInstance().OpenUI("UIProfile");
        UiManager.GetInstance().OpenUI("UIActionMenu");
    }

    
    void Update()
    {
        
    }
}
