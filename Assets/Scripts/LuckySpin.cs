using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.PickerWheelUI;
using TMPro;
using UnityEngine.SceneManagement;

public class LuckySpin : MonoBehaviour
{
    public Button spinButton;
    public PickerWheel pickerWheel;
    public List<WheelPiece> wheelPieces;
    private CharacterManager characterManager;
    private Reward reward;

    public GameObject panelInfo;
    public TextMeshProUGUI characterLabel;
    public Image characterSprite;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI diamondText;

    private void Awake()
    {
        characterManager = FindAnyObjectByType<CharacterManager>();
        reward = FindAnyObjectByType<Reward>();
    }

    public void GainCharacter()
    {
        SceneManager.LoadScene("ShopScene");
        reward.SaveData();
    }

    private void Start()
    {
        SetupWheel();
        reward.LoadData();
        coinText.text = reward.coin.ToString();
        diamondText.text = reward.diamond.ToString();

        spinButton.onClick.AddListener(() =>
        {
            pickerWheel.OnSpinStart(() =>
            {
                spinButton.interactable = false;
                Debug.Log("Spin start...");
            });

            pickerWheel.OnSpinEnd(wheelPiece =>
            {
                spinButton.interactable = true;
                Debug.Log("Spin end...\n");

                panelInfo.SetActive(true);
                characterLabel.text = wheelPiece.Label;
                characterSprite.sprite = wheelPiece.Icon;

                reward.AddReward(wheelPiece.Label);
            });

            pickerWheel.Spin();
        });
    }

    private void SetupWheel()
    {
        wheelPieces.Clear();

        foreach (var character in characterManager.characterSpin)
        {
            WheelPiece wheelPiece = new() { Icon = character.characterSprite, Label = character.characterName };
            wheelPieces.Add(wheelPiece);
        }

        pickerWheel.wheelPieces = wheelPieces.ToArray();
    }
}
