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
    [SerializeField] UnityEngine.UI.Button item2Buy;
    [SerializeField] UnityEngine.UI.Button item2Equip;
    [SerializeField] int item2Price;
    [SerializeField] TMPro.TextMeshProUGUI item2PriceText;
    [SerializeField] UnityEngine.UI.Button item3Buy;
    [SerializeField] UnityEngine.UI.Button item3Equip;
    [SerializeField] int item3Price;
    [SerializeField] TMPro.TextMeshProUGUI item3PriceText;

    Scene currentScene;
    string currentSceneName;
    //bool item2Bought;

    private void Awake()
    {
        Instance = this;

        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

        item1PriceText.text = item1Price.ToString();
        item2PriceText.text = item2Price.ToString();  
        item3PriceText.text = item3Price.ToString();

        //item2Equip.gameObject.SetActive(false);

        //item2Bought = false;

        getMoney();
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Backslash)) {
            //Debug.Log("Loading Game Scene");
            SceneManager.LoadScene("GameDemo");
            Time.timeScale = 1f;
        }
        */

        if (SceneManager.GetActiveScene().name != "ShopScene") {
            Destroy(gameObject);
        }

        //This scene check is for no nullReferenceExceptions
        if (currentSceneName == "ShopScene") {
            if (SledSkinController.item2Bought == false) {
                if (MoneyController.money < item2Price) {
                    item2Buy.interactable = false;
                    item2Equip.gameObject.SetActive(false);
                } else {
                    item2Buy.interactable = true;
                }
            } else {
                item2Buy.gameObject.SetActive(false);
            }

            if (SledSkinController.item3Bought == false) {
                if (MoneyController.money < item3Price) {
                    item3Buy.interactable = false;
                    item3Equip.gameObject.SetActive(false);
                } else {
                    item3Buy.interactable = true;
                }
            } else {
                item3Buy.gameObject.SetActive(false);
            }
        }
    }

    public void goToLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1f;
    }

    public void buySkin1() {
        if (MoneyController.money >= item2Price) {
            SledSkinController.Instance.boughtSkin2();
            item2Buy.gameObject.SetActive(false);
            item2Equip.gameObject.SetActive(true);
            MoneyController.Instance.loseMoney(item2Price);
            getMoney();
        }
    }

    public void buySkin2() {
        if (MoneyController.money >= item3Price) {
            SledSkinController.Instance.boughtSkin3();
            item3Buy.gameObject.SetActive(false);
            item3Equip.gameObject.SetActive(true);
            MoneyController.Instance.loseMoney(item3Price);
            getMoney();
        }
    }

    public void equipSkin0() {
        SledSkinController.currentSkin = 0;
        //SledSkinController.Instance.changeSkin();
    }

    public void equipSkin1() {
        SledSkinController.currentSkin = 1;
        //SledSkinController.Instance.changeSkin();
    }

    public void equipSkin2() {
        SledSkinController.currentSkin = 2;
    }

    public void getMoney() {
        int tempMoney = MoneyController.money;
        moneyShopText.text = tempMoney.ToString();
    }

}
