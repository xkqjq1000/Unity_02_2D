using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scene
{
    Menu,
    Main,
    Battle
        
}
public class ScenesManager : MonoBehaviour
{

    #region Singletone
    public static ScenesManager instance;


    public static ScenesManager GetInstance()
    {
        if (instance == null)   //  null로 제한
        {
            GameObject go = new GameObject("@ScenesManager");   // 골뱅이는 그냥 구분을 쉽게 하기 위해 그냥 넣은것
            instance = go.AddComponent<ScenesManager>();

            DontDestroyOnLoad(go); // 신이 전환될때 오브젝트 파괴 방지
        }
        return instance;
    }
    #endregion

    #region Scene Control
    public Scene currentScene;

    public void ChangeScene(Scene scene)
    {
        UiManager.GetInstance().ClearList();
        
        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());
    }


    #endregion

}
