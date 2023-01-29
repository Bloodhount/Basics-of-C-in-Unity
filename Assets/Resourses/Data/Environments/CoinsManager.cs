using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private int _numberOfCoins;
    [SerializeField] private int _coordinatesCoinGeneration;

    public GameObject CoinPrefab;
    public List<Loot> CoinsList = new List<Loot>();
    public Text CoinsText;

    void Start()
    {
        for (int i = 0; i < _numberOfCoins; i++)
        {
            int rnd1 = UnityEngine.Random.Range(-_coordinatesCoinGeneration, _coordinatesCoinGeneration);
            int rnd2 = UnityEngine.Random.Range(-_coordinatesCoinGeneration, _coordinatesCoinGeneration);
            GameObject newCoin = Instantiate(CoinPrefab, new Vector3(rnd1, 0.5f, rnd2), Quaternion.identity);
            CoinsList.Add(newCoin.GetComponent<Loot>());
        }
        UpdateText();
    }

    public void CollectCoin(Loot coin)
    {
        CoinsList.Remove(coin);
        Destroy(coin.gameObject);
        UpdateText();
    }

    private void UpdateText()
    {
        CoinsText.text = "Осталось: " + CoinsList.Count.ToString("0");
    }

    public Loot GetLoot(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Loot closestLoot = null;

        for (int i = 0; i < CoinsList.Count; i++)
        {
            float distance = Vector3.Distance(point, CoinsList[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestLoot = CoinsList[i];
            }
        }
            return closestLoot;
    }
}