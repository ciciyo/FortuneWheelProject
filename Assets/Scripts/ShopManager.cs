using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    private CharacterManager characterManager;
    private Reward reward;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI diamondText;

    public TextMeshProUGUI panelInfoText;
    public GameObject panelInfo;

    private void Awake()
    {
        characterManager = FindAnyObjectByType<CharacterManager>();
        reward = FindAnyObjectByType<Reward>();
    }

    private void Start()
    {
        coinText.text = reward.coin.ToString();
        diamondText.text = reward.diamond.ToString();
    }

    public void SetCharacter(string type)
    {
        characterManager.CharacterSpinManager(type);
    }

    public void SetCostCoin(int cost)
    {
        if (reward.coin - cost < 0)
        {
            string infoText = "your coin is not enough to pay this cost";
            panelInfoText.text = infoText;
            panelInfo.SetActive(true);
            return;
        }

        reward.coin -= cost;
        reward.SaveData();
        SceneManager.LoadScene("LuckySpinScene");
    }

    public void SetCostDiamond(int cost)
    {
        if (reward.diamond - cost < 0)
        {
            string infoText = "your diamond is not enough to pay this cost";
            panelInfoText.text = infoText;
            panelInfo.SetActive(true);
            return;
        }

        reward.diamond -= cost;
        reward.SaveData();
        SceneManager.LoadScene("LuckySpinScene");
    }
}
