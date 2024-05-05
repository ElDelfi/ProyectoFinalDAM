using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRecordText : MonoBehaviour
{
    public int level;
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text ="Record: "+ PlayerPrefs.GetInt("Level"+level+"score", 0);

    }
}
