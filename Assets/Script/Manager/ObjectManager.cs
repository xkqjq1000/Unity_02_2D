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
        if (instance == null)   //  null�� ����
        {
            GameObject go = new GameObject("@ObjectManager");   // ����̴� �׳� ������ ���� �ϱ� ���� �׳� ������
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go); // ���� ��ȯ�ɶ� ������Ʈ �ı� ����
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
