using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ATManager : MonoBehaviour
{
    public static ATManager instance;

    [Header("UI Element")]
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI banlanceText;

    [Header("Data")]
    public UserData userData;

    private string savePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            savePath = Application.dataPath + "/Resources/userData.json";

            LoadUserData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (userData == null) return;

        userNameText.text = userData.userName;
        banlanceText.text = string.Format("{0:N0}", userData.banlance);
        moneyText.text = string.Format("{0:N0}", userData.money);
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
        }
        else
        {
            userData = new UserData("Joo Sae Woong", 50000, 100000);
            SaveUserData();
        }

        Refresh();
    }
}