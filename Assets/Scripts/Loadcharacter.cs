using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Loadcharacter : MonoBehaviour
{
    public GameObject[] characterprefabs;
    public Transform spawPoint_0;
    public Transform spawPoint_1;  
    public Transform spawPoint_2;
   // public TMP_Text label;

    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        //Debug.Log(selectedCharacter);
        GameObject prefab = characterprefabs[selectedCharacter];
        if(selectedCharacter==0)
        {
            GameObject clone = Instantiate(prefab, spawPoint_0.position, Quaternion.identity);
        }

        if (selectedCharacter == 1)
        {
            GameObject clone = Instantiate(prefab, spawPoint_1.position, Quaternion.identity);
        }
        if(selectedCharacter == 2)
        {
            GameObject clone = Instantiate(prefab, spawPoint_2.position, Quaternion.identity);
        }
        // label.text=prefab.name;
    }
}
