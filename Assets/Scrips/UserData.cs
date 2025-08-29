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
            Debug.Log("0 ������ �ݾ��� �Ա��� �� �����ϴ�");
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
            Debug.Log("�ܾ��� �����մϴ�");
            return false;
        }
    }

    public bool Withdraw(int amount)
    {
        if (amount <= 0)
        {
            Debug.Log("0 ���� �ݾ��� ����� �� �����ϴ�.");
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
            Debug.Log("�ܾ��� �����մϴ�");
            return false;
        }
    }
}
