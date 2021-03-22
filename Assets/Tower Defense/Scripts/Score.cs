using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
     public TMPro.TextMeshProUGUI currentCoins;
     int coins;
     // Start is called before the first frame update
     void Start()
     {
          coins = 0;
     }

     // Update is called once per frame
     void Update()
     {
          currentCoins.SetText("Current Money: " + coins.ToString());
     }

     public void UpdateScore(int coinsFromEnemy)
     {
          coins += coinsFromEnemy;
     }
}
