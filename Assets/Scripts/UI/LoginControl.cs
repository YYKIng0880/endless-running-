using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginControl : MonoBehaviour
{
    public InputField IDInput;
    public InputField passwardInput;
    public Text WarningMessage;
    public void OnLoginButtonClick()
    {
        string ID=IDInput.text;
        string passward=passwardInput.text;
        if(ID=="Byy"&&passward=="123456")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            WarningMessage.enabled=true;
            StartCoroutine(HideMessage());
        }
        
    }
   IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(1f);
        WarningMessage.enabled = false;
    }
}
