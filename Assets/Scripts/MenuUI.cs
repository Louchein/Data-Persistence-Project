using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour {

    // necesito declara la variable referencia del input
    //[SerializeField] private InputField inputField;
    [SerializeField] private TMP_InputField inputField;

    // necesito agarrar la referencia al input en awake o start
    private void Awake() {
        //inputField = GetComponent<InputField>();
        //inputField = GetComponent<TMP_InputField>();
    }

    public void PlayGame() {
        GameManager.Instance.LoadData();
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveName() {
        if (inputField != null && GameManager.Instance != null) {
            GameManager.Instance.currentPlayerName = inputField.text;
        } else {
            Debug.LogWarning("GameManager not initialized or input field is null");
        }
    }

    public void ShowNameInConsole() {
        Debug.Log("inputField.text: " + inputField.text);
    }

}
