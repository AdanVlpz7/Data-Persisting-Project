using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuHandler : MonoBehaviour
{
    public InputField nameField;
    public void StartNew()
    {
        SceneManager.LoadScene(1);
        Manager.Instance.temporaryName = nameField.text;
    }
    public void Exit()
    {
        Manager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
    public void SaveName()
    {
        if(nameField.text == Manager.Instance.userName)
            Manager.Instance.Load();
    }
}
