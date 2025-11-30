using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavePassword : MonoBehaviour
{
    public string Password;
    TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }
    //Whatever is typed in the inputField set it as the Password
    public void PasswordSet()
    {
        Password = inputField.text;
    }
}
