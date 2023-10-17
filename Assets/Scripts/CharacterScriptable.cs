using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characters", menuName = "Data/TypeCharacter", order = 0)]
public class CharacterScriptable : ScriptableObject
{
    public string typeCharacter;
    public List<Character> characterList;
}

[Serializable]
public class Character
{
    public string characterName;
    public Sprite characterSprite;
}