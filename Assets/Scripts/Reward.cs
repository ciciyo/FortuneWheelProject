using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int coin;
    public int diamond;
    public List<string> rewardList = new();

    private void Start()
    {
        LoadData();
    }

    public void AddReward(string rewardCharacter)
    {
        if (rewardList.Contains(rewardCharacter)) return;

        rewardList.Add(rewardCharacter);
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();

        data.coin = coin;
        data.diamond = coin;
        data.characters = rewardList.ToArray();

        PlayerManager.SaveData(data);
    }

    public void LoadData()
    {
        PlayerData playerData = PlayerManager.LoadData();

        coin = playerData.coin;
        diamond = playerData.diamond;
        rewardList = playerData.characters.ToList();
    }
}
