using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FieldHandler : MonoBehaviour
{
    [SerializeField] private InputField nameField;

    public void UserInput()
    {
        PlayerPrefs.SetString("PlayerName", nameField.text);
        SceneManager.LoadScene("HighScores");
    }
}
