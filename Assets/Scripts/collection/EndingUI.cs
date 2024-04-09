using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDis;
    public GameObject endScreen;
    public GameObject fadeOut;
    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(EndGame());
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        liveCoins.SetActive(false);
        liveDis.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        fadeOut.SetActive(true);
        /*endScreen.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);*/
    }
}
