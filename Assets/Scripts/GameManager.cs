using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text damageSwordText;
    [SerializeField] private Text damageSpearText;
    [SerializeField] private Text valueSpearOnPlayerText;

     private int currentDamageSwordText;
     private int currentDamageSpearText;
     private int currentvalueSpearOnPlayerText;

    private void Update()
    {
        damageSwordText.text = currentDamageSwordText.ToString();
        damageSpearText.text = currentDamageSpearText.ToString();
        valueSpearOnPlayerText.text = currentvalueSpearOnPlayerText.ToString();
    }


    public int GetCurrentDamageSwordText()
    {
        return this.currentDamageSwordText;
    }

    public void SetCurrentDamageSwordText(int value)
    {
        this.currentDamageSwordText = value;
    }

    public int GetCurrentDamageSpearText()
    {
        return this.currentDamageSpearText;
    }

    public void SetCurrentDamageSpearText(int value)
    {
        this.currentDamageSpearText = value;
    }

    public int GetCurrentvalueSpearOnPlayerText()
    {
        return this.currentvalueSpearOnPlayerText;
    }

    public void SetCurrentvalueSpearOnPlayerText(int value)
    {
        this.currentvalueSpearOnPlayerText = value;
    }
}
