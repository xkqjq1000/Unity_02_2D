using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProfile : MonoBehaviour
{
    public Slider hpbar;
    public Image Fill;

    public TMP_Text txthp;

    public TMP_Text txtLevel;
    public TMP_Text txtGold;
    public TMP_Text txtName;

    private void Start()
    {

        RefreshState();
    }

    public void RefreshState()
    {
        txtLevel.text = $"Lv. {GameManager.GetInstance().level}";
        txtName.text = $"{GameManager.GetInstance().playerName}";
        txtGold.text = $"{GameManager.GetInstance().gold}g";

        hpbar.maxValue = GameManager.GetInstance().totalhp;
        hpbar.value = GameManager.GetInstance().curhp;
        txthp.text = $"{hpbar.value} / {hpbar.maxValue}";
    }
}
