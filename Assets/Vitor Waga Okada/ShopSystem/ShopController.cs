using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;
    [SerializeField] TMPro.TextMeshProUGUI moneyShopText;
    [SerializeField] UnityEngine.UI.Button item1Buy;
    [SerializeField] UnityEngine.UI.Button item1Equip;
    [SerializeField] int item1Price;
    [SerializeField] TMPro.TextMeshProUGUI item1PriceText;
    bool item1Bought;
    [SerializeField] UnityEngine.UI.Button item2Buy;
    [SerializeField] UnityEngine.UI.Button item2Equip;
    [SerializeField] int item2Price;
    [SerializeField] TMPro.TextMeshProUGUI item2PriceText;

    Scene currentScene;
    string currentSceneName;
    bool item2Bought;

    private void Awake()
    {
        Instance = this;

        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

        item1PriceText.text = item1Price.ToString();
        item2PriceText.text = item2Price.ToString();  

        item2Equip.gameObject.SetActive(false);

        item1Bought = true;
        item2Bought = false;

        getMoney();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backslash)) {
            Debug.Log("Loading Game Scene");
            SceneManager.LoadScene("GameDemo");
        }

        if (SceneManager.GetActiveScene().name != "ShopScene") {
            Destroy(gameObject);
        }

        if (currentSceneName == "ShopScene") {
            if (item2Bought == false) {
                if (MoneyController.money < item2Price) {
                    item2Buy.interactable = false;
                    item2Equip.gameObject.SetActive(false);
                } else {
                    item2Buy.interactable = true;
                }
            }
        }
    }

    public void buySkin1() {
        if (MoneyController.money >= item2Price) {
            item2Bought = true;
            item2Buy.gameObject.SetActive(false);
            item2Equip.gameObject.SetActive(true);
            MoneyController.Instance.loseMoney(item2Price);
            getMoney();
        }
    }

    public void equipSkin0() {
        SledSkinController.currentSkin = 0;
        SledSkinController.Instance.changeSkin();
    }

    public void equipSkin1() {
        SledSkinController.currentSkin = 1;
        SledSkinController.Instance.changeSkin();
    }

    public void getMoney() {
        int tempMoney = MoneyController.money;
        moneyShopText.text = tempMoney.ToString();
    }

}
