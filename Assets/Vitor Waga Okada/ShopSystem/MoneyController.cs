using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public static int money;
    public static MoneyController Instance;
    [SerializeField] TMPro.TextMeshProUGUI moneyControllerText;
    void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
        }

        Instance = this;
        Instance.moneyControllerText.text = money.ToString();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame

    public void addMoney() {
        Debug.Log("Adding money!");
        money += 10;
        Instance.moneyControllerText.text = money.ToString();
    }

    public void loseMoney(int amount) {
        money -= amount;
        Instance.moneyControllerText.text = money.ToString();
    }
}
