using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectcontrol : MonoBehaviour
{//UIӲ�Ҽ�����
      public static int  coinCount;
      public GameObject coinCountDisplay;
    private void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
