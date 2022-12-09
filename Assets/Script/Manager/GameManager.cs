using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singletone
    public static GameManager instance;


    public static GameManager GetInstance()
    {
        if (instance == null)   //  null로 제한
        {
            GameObject go = new GameObject("@GameManager");   // 골뱅이는 그냥 구분을 쉽게 하기 위해 그냥 넣은것
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go); // 신이 전환될때 오브젝트 파괴 방지
        }
        return instance;
    }
    #endregion

    public int level = 1;

    public string playerName = "jong";

    public int gold = 500;
    
    public int totalhp = 100;
    public int curhp = 100;


    public void AddGold(int gold)
    {
        this.gold += gold;
    }
    public bool SpendGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalhp += addHp;
    }

    public void SetCurrentHP(int hp)
    {
        curhp += hp;

        if (curhp > totalhp)
            curhp = totalhp;

        if (curhp < 0)
            curhp = 0;

        //curhp = Mathf.Clamp(hp, 0, 100);  // 간편식
    }
}
