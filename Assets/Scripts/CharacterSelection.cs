using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private CharacterManager characterManager;
    private Reward reward;

    public GameObject cardPrefab;
    public GameObject contentContainerGO;

    private void Awake()
    {
        characterManager = FindObjectOfType<CharacterManager>();
        reward = FindObjectOfType<Reward>();
    }

    private void Start()
    {
        foreach (var character in characterManager.allCharacterList)
        {
            GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity, contentContainerGO.transform);
            newCard.name = character.characterName;
            newCard.transform.GetChild(0).GetComponent<Image>().sprite = character.characterSprite;
            newCard.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = character.characterName;
        }

        foreach (string character in reward.rewardList)
        {
            foreach (Transform characterGO in contentContainerGO.transform)
            {
                if (characterGO.name == character)
                {
                    characterGO.GetChild(2).gameObject.SetActive(false);
                }
            }
        }
    }
}
