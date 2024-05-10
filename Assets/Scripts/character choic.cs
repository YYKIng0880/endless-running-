using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterchoic : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter = 0;

    public void Nextcharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter+1)%characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void Previouscharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter<0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
