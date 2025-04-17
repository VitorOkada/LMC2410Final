using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyGameController : MonoBehaviour
{
    public static MoneyGameController Instance;
    [SerializeField] TMPro.TextMeshProUGUI moneyGameText;

    void Awake()
    {
        Instance = this;
        Instance.moneyGameText.text = MoneyController.money.ToString();
    }

    
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "GameDemo") {
            Destroy(gameObject);
        }
    }
    

    public void updateMoneyGame() {
        MoneyController.Instance.addMoney();
        getMoney();
    }

    public void getMoney() {
        int tempMoney = MoneyController.money;
        moneyGameText.text = tempMoney.ToString();
    }
}
