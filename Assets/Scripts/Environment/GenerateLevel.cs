using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{//Éú³ÉµØÍ¼£»
    public GameObject[] section;
    private  int zPos = 50;
    private bool creatingSection = false;
    private int secNum;
    public float creatmaptime = 3f;
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;

            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 8);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(creatmaptime);
        creatingSection = false;
    }
}
