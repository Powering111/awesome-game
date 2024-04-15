using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChanger : MonoBehaviour
{
    public GameObject winTextObject, loseTextObject;
    public void setLose()
    {
        loseTextObject.SetActive(true);
    }
    public void setWin()
    {
        winTextObject.SetActive(true);
    }
}
