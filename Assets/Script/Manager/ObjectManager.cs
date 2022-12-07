using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectManager : MonoBehaviour
{
    #region Singletone
    public static ObjectManager instance;


    public static ObjectManager GetInstance()
    {
        if (instance == null)   //  null로 제한
        {
            GameObject go = new GameObject("@ObjectManager");   // 골뱅이는 그냥 구분을 쉽게 하기 위해 그냥 넣은것
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go); // 신이 전환될때 오브젝트 파괴 방지
        }
        return instance;
    }
    #endregion

    public GameObject CreateCharacter()
    {
        Object CharacterObj = Resources.Load("Sprite/Character");
        GameObject Character = (GameObject)Instantiate(CharacterObj);

        return Character;
    }
}
