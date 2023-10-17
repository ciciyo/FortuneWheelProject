using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PlayerManager
{
    static readonly string jsonPath = Application.dataPath + "/PlayerData.json";

    public static void SaveData(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(jsonPath, json);
    }

    public static PlayerData LoadData()
    {
        if (!File.Exists(jsonPath))
        {
            return null;
        }

        string json = File.ReadAllText(jsonPath);
        return JsonUtility.FromJson<PlayerData>(json);
    }
}

[Serializable]
public class PlayerData
{
    public int coin;
    public int diamond;
    public string[] characters;
}
