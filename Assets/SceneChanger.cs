using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneChanger : MonoBehaviour
{
    // Reference to the TMP Input Field for VR
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    
    // Correct username and password
    [SerializeField] private string correctUsername = "YourUsername";
    [SerializeField] private string correctPassword = "YourPassword123";
    
    // Error message TMP Text
    [SerializeField] private TMP_Text errorMessageText;

    [SerializeField] private GameObject Player;

    void Start()
    {
        // Hide error message initially
        if (errorMessageText != null)
        {
            errorMessageText.gameObject.SetActive(false);
        }
    }

    public void ChangeScene()
    {
        // Get username and password from TMP Input Field
        string enteredUsername = usernameInputField != null ? usernameInputField.text : "";
        string enteredPassword = passwordInputField != null ? passwordInputField.text : "";
        
        Debug.Log($"Password entered: {enteredPassword}");
        
        if (enteredUsername == correctUsername && enteredPassword == correctPassword)
        {
            // Password correct - load scene
            SceneManager.LoadScene(1);
            DontDestroyOnLoad(Player);
        }
        else
        {
            // Password incorrect - show error
            ShowErrorMessage("Incorrect!");
        }
    }
    private void ShowErrorMessage(string message)
    {
        if (errorMessageText != null)
        {
            errorMessageText.text = message;
            errorMessageText.gameObject.SetActive(true);
            // Cancel any previous invoke first
            CancelInvoke(nameof(HideErrorMessage));
            
            // Invoke with exact method name
            Invoke(nameof(HideErrorMessage), 2f);
        }
    }
        
    // Method name must match exactly what you invoke
    private void HideErrorMessage()
    {
        if (errorMessageText != null)
        {
            errorMessageText.gameObject.SetActive(false);
        }
    }
}