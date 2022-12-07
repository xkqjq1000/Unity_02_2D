using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 이번 프로젝트에 사용할 싱글톤 방식
public class UiManager : MonoBehaviour
{
   
    
    #region Singletone
    public static UiManager instance;


    public static UiManager GetInstance()
    {
        if (instance == null)   //  null로 제한
        {
            GameObject go = new GameObject("@UiManager");   // 골뱅이는 그냥 구분을 쉽게 하기 위해 그냥 넣은것
            instance = go.AddComponent<UiManager>();

            DontDestroyOnLoad(go); // 신이 전환될때 오브젝트 파괴 방지
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
