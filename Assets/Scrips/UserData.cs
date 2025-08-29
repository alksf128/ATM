using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName;
    public int money;
    public int banlance;

    public UserData(string name, int initialmoney, int initialbanlance)
    {
        userName = name;
        money = initialmoney;
        banlance = initialbanlance;
    }

    public bool Deposit(int amount)
    {
        if (money <= 0)
        {
            Debug.Log("0 이하의 금액은 입급할 수 없습니다");
            return false;
        }

        if (money >= amount)
        {
            money -= amount;
            banlance += amount;
            return true;
        }
        else
        {
            Debug.Log("잔액이 부족합니다");
            return false;
        }
    }

    public bool Withdraw(int amount)
    {
        if (amount <= 0)
        {
            Debug.Log("0 이하 금액은 출금할 수 없습니다.");
            return false;
        }

        if (banlance >= amount)
        {
            banlance -= amount;
            money += amount;
            return true;
        }
        else
        {
            Debug.Log("잔액이 부족합니다");
            return false;
        }
    }
}
