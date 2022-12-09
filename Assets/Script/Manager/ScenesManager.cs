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
        if (instance == null)   //  null�� ����
        {
            GameObject go = new GameObject("@ScenesManager");   // ����̴� �׳� ������ ���� �ϱ� ���� �׳� ������
            instance = go.AddComponent<ScenesManager>();

            DontDestroyOnLoad(go); // ���� ��ȯ�ɶ� ������Ʈ �ı� ����
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
