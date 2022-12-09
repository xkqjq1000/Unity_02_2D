using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenes : MonoBehaviour
{
    
    void Start()
    {
        

        GameObject go = ObjectManager.GetInstance().CreateCharacter();
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0, 1.1f, 0);


        UiManager.GetInstance().SetEventSystem();
        UiManager.GetInstance().OpenUI("UIProfile");
        UiManager.GetInstance().OpenUI("UIActionMenu");
    }

    
    void Update()
    {
        
    }
}
