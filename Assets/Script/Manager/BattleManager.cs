using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone
    public static BattleManager instance;


    public static BattleManager GetInstance()
    {
        if (instance == null)   //  null�� ����
        {
            GameObject go = new GameObject("@BattleManager");   // ����̴� �׳� ������ ���� �ϱ� ���� �׳� ������
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go); // ���� ��ȯ�ɶ� ������Ʈ �ı� ����
        }
        return instance;
    }
    #endregion

    public Monster1 monsterDeta;


    GameObject uiTab;
    public void BattleStart(Monster1 monster)
    {
        monsterDeta = monster;

        UiManager.GetInstance().OpenUI("UITab");
        //uiTab = UiManager.GetInstance().GetUI("UITab"); == UiManager.GetInstance().CloseUI("UITab");

        StartCoroutine("BattleProgress");
    }

    
    IEnumerable BattleProgress()
    {
        while(GameManager.GetInstance().curhp > 0) 
        {
            yield return new WaitForSeconds(monsterDeta.delay);

            int damage = monsterDeta.atk;
            GameManager.GetInstance().SetCurrentHP(-damage);

            GameObject ui = UiManager.GetInstance().GetUI("UIProfile");
            if(ui != null)
            {
                ui.GetComponent<UIProfile>().RefreshState();
            }

            
            Debug.Log($"���Ͱ� �÷��̾ �����߽��ϴ� - ������: {damage}   ���� ü�� : {GameManager.GetInstance().curhp}");

            
        }

        Lose();

        
    }

    public void AttackMonster()
    {
        float randX = Random.Range(-0.5f, 0.5f);
        float randY = Random.Range(-0.5f, 0.5f);

        var particle = ObjectManager.GetInstance().CreateHitEffect();
        particle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        particle.transform.localPosition = new Vector3(0+ randX,0.7f + randY, -0.5f);

        monsterDeta.hp -= 10;
        
        if(monsterDeta.hp <= 0 ) 
        {
            Victory();
        }
    }
    void Victory()
    {
        Debug.Log("���ӿ��� �¸��Ͽ����ϴ�.");
        StopCoroutine("BattleProgress");
        UiManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterDeta.gold);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        Debug.Log("���ӿ��� �й��߽��ϴ�.");
        UiManager.GetInstance().CloseUI("UITab");

        if(GameManager.GetInstance().SpendGold(500))
            GameManager.GetInstance().SetCurrentHP(30);

        else
            GameManager.GetInstance().SetCurrentHP(10);

        Invoke("MoveToMain", 2.5f);

    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
