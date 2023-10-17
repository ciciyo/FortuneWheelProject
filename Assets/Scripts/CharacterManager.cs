using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<CharacterScriptable> characterList = new();
    public List<Character> allCharacterList { get; private set; } = new();
    public List<Character> characterSpin { get; private set; } = new();

    public static CharacterManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        foreach (var character in characterList)
        {
            allCharacterList.AddRange(character.characterList);
        }
    }

    private List<Character> GetCharacterType(string characterTypeInList)
    {
        foreach (var charType in characterList)
        {
            if (charType.typeCharacter == characterTypeInList)
                return charType.characterList;
        }

        return null;
    }

    public void CharacterSpinManager(string combinationType)
    {
        List<Character> commonList = GetCharacterType("Common");
        List<Character> rareList = GetCharacterType("Rare");
        List<Character> epicList = GetCharacterType("Epic");
        List<Character> legendaryList = GetCharacterType("Legendary");

        characterSpin.Clear();

        if (combinationType == "Common")
        {
            for (int i = 1; i <= 12; i++)
            {
                int random = UnityEngine.Random.Range(0, 5);

                if (i <= 10)
                    characterSpin.Add(commonList[random]);
                else
                    characterSpin.Add(rareList[random]);
            }
        }

        if (combinationType == "Rare")
        {
            for (int i = 1; i <= 12; i++)
            {
                int random = UnityEngine.Random.Range(0, 5);

                if (i <= 8)
                    characterSpin.Add(commonList[random]);
                else
                    characterSpin.Add(rareList[random]);
            }
        }

        if (combinationType == "Epic")
        {
            for (int i = 1; i <= 12; i++)
            {
                int random = UnityEngine.Random.Range(0, 5);

                if (i <= 6)
                    characterSpin.Add(commonList[random]);
                else if (i > 6 && i <= 9)
                    characterSpin.Add(rareList[random]);
                else
                    characterSpin.Add(epicList[random]);
            }
        }

        if (combinationType == "Legendary")
        {
            for (int i = 1; i <= 12; i++)
            {
                int random = UnityEngine.Random.Range(0, 5);

                if (i <= 4)
                    characterSpin.Add(commonList[random]);
                else if (i > 4 && i <= 7)
                    characterSpin.Add(rareList[random]);
                else if (i > 7 && i <= 10)
                    characterSpin.Add(epicList[random]);
                else
                    characterSpin.Add(legendaryList[random]);
            }
        }
    }
}
