
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinHandler : MonoBehaviour
{
    private int playerCoins;
    public int PlayerCoins
    {
        get => playerCoins;
    }

    public void AddCoin(int amount)
    {
        playerCoins += amount;
    }


}
