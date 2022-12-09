using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScenes : MonoBehaviour
{
    
    void Start()
    {
        GameObject go = ObjectManager.GetInstance().CreateMonster();  // ��ü�� ���ͷ� �ν�
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        go.transform.localPosition = new Vector3(0, 0.6f, 0);

        UiManager.GetInstance().SetEventSystem();
        UiManager.GetInstance().OpenUI("UIProfile");

        BattleManager.GetInstance().BattleStart(new Monster1());
    }

    
   
}
