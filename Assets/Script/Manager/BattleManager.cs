using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone
    public static BattleManager instance;


    public static BattleManager GetInstance()
    {
        if (instance == null)   //  null로 제한
        {
            GameObject go = new GameObject("@BattleManager");   // 골뱅이는 그냥 구분을 쉽게 하기 위해 그냥 넣은것
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go); // 신이 전환될때 오브젝트 파괴 방지
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

            
            Debug.Log($"몬스터가 플레이어를 공격했습니다 - 데미지: {damage}   남은 체력 : {GameManager.GetInstance().curhp}");

            
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
        Debug.Log("게임에서 승리하였습니다.");
        StopCoroutine("BattleProgress");
        UiManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterDeta.gold);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        Debug.Log("게임에서 패배했습니다.");
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
