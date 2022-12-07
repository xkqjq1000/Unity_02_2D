using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// �̹� ������Ʈ�� ����� �̱��� ���
public class UiManager : MonoBehaviour
{
   
    
    #region Singletone
    public static UiManager instance;


    public static UiManager GetInstance()
    {
        if (instance == null)   //  null�� ����
        {
            GameObject go = new GameObject("@UiManager");   // ����̴� �׳� ������ ���� �ϱ� ���� �׳� ������
            instance = go.AddComponent<UiManager>();

            DontDestroyOnLoad(go); // ���� ��ȯ�ɶ� ������Ʈ �ı� ����
        }
        return instance;
    }
    #endregion

    #region UI Control

    public void SetEventSystem()
    {
        if(FindObjectOfType<EventSystem>() == false)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<EventSystem>();

        }    


    }

    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();
    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false)  // ContainsKey 
        {
            Object uiObj = Resources.Load("UI/" + uiName);

            GameObject go = (GameObject)Instantiate(uiObj);

            uiList.Add(uiName, go);
        }
        else 
            uiList[uiName].SetActive(true);
    }

    public void CloseUI(string uiName) 
    {
        if(uiList.ContainsKey(uiName))
            uiList[uiName].SetActive(false);
    }

    #endregion
}
