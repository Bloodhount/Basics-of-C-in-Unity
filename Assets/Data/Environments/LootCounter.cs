using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootCounter : MonoBehaviour
{
    public int Count { get; private set; }
    public int LootToWin;

    public Text countText;
    public GameObject VictoryText;

    void Start()
    {
        VictoryText.SetActive(false);
        Count = 0;
        TextUpdate();
        LootToWin = FindObjectsOfType<Loot>().Length; //Debug.Log(LootToWin);
    }

    internal void TextUpdate()
    {
        countText.text = "COINS: " + Count.ToString();
    }

    internal void AddCoin()
    {
        Count++;
        TextUpdate();
        if (Count >= LootToWin)
        {
            VictoryText.SetActive(true);

        }
    }
}
