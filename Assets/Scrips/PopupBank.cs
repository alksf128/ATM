using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupBankUI : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject popupError;

    public Button depositButton;
    public Button withdrawButton;

    public TMPro.TextMeshProUGUI moneyText;
    public TMPro.TextMeshProUGUI banlanceText;
    public TMPro.TextMeshProUGUI popupErrorText;
    public TMPro.TMP_InputField depositInputField;
    public TMPro.TMP_InputField withdrawInputField;

    private UserData userData;

    void Start()
    {
        depositButton.onClick.AddListener(ShowDepositPanel);
        withdrawButton.onClick.AddListener(ShowWithdrawPanel);
        HideAllPanels();

        userData = ATManager.instance.userData;
        RefreshUI();
    }

    public void Deposit(int amount)
    {
        if (userData.Deposit(amount))
        {
            RefreshUI();
            ATManager.instance.SaveUserData();
        }
        else
        {
            popupErrorText.text = "잔액이 부족합니다";
            popupError.SetActive(true);
        }
    }

    public void DepositCustom()
    {
        if (int.TryParse(depositInputField.text, out int amount))
        {
            if (amount <= 0)
            {
                popupErrorText.text = "0 이하의 금액은 입금할 수 없습니다.";
                popupError.SetActive(true);
                return;
            }

            if (userData.Deposit(amount))
            {
                RefreshUI();
                depositInputField.text = "";
            }
            else
            {
                popupErrorText.text = "현금이 부족합니다.";
                popupError.SetActive(true);
            }
        }
        else
        {
            popupErrorText.text = "숫자를 올바르게 입력해주세요.";
            popupError.SetActive(true);
        }
    }

    public void Withdraw(int amount)
    {
        if (userData.Withdraw(amount))
        {
            RefreshUI();
            ATManager.instance.SaveUserData();
        }
        else
        {
            popupErrorText.text = "잔액이 부족합니다";
            popupError.SetActive(true);
        }
    }

    public void WithdrawCustom()
    {
        if (int.TryParse(withdrawInputField.text, out int amount))
        {
            if (amount <= 0)
            {
                popupErrorText.text = "0 이하의 금액은 출금할 수 없습니다.";
                popupError.SetActive(true);
                return;
            }

            if (userData.Withdraw(amount))
            {
                RefreshUI();
                withdrawInputField.text = "";
            }
            else
            {
                popupErrorText.text = "잔액이 부족합니다.";
                popupError.SetActive(true);
            }
        }
        else
        {
            popupErrorText.text = "숫자를 올바르게 입력해주세요.";
            popupError.SetActive(true);
        }
    }

    public void RefreshUI()
    {
        moneyText.text = $"{userData.money:N0}";
        banlanceText.text = $"{userData.banlance:N0}";
    }

    public void ShowDepositPanel()
    {
        depositPanel.SetActive(true);
        withdrawPanel.SetActive(false);
    }

    public void ShowWithdrawPanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(true);
    }

    public void HideAllPanels()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
    }

    public void HideErrorPopup()
    {
        popupError.SetActive(false);
    }
}
