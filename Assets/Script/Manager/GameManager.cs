using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singletone
    public static GameManager instance;


    public static GameManager GetInstance()
    {
        if (instance == null)   //  null�� ����
        {
            GameObject go = new GameObject("@GameManager");   // ����̴� �׳� ������ ���� �ϱ� ���� �׳� ������
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go); // ���� ��ȯ�ɶ� ������Ʈ �ı� ����
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

        //curhp = Mathf.Clamp(hp, 0, 100);  // �����
    }
}
