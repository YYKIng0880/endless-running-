using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Aduiochange : MonoBehaviour
{
    public Slider Ad;
    public AudioSource BGM;
    public void LoadMuneScene()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
    private void Update()
    {
        AudioListener.volume = Ad.value;
    }
}
