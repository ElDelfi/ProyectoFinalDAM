using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    public GameObject prefab500;
    public GameObject prefab1000;
    public int score = 0;
    public int multiplier = 1;
    public float comboTimer = 0.0f;
    int scoreHold = 0; //son los puntos obtenidos antes de que se acabe el combo, luego se suman al acabar el timer
    public TextMeshProUGUI scoreTextGUI;
    public TextMeshProUGUI recordTextGUI;
    public int record;
    void Start()
    {
        record = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "score", 0);
        Debug.Log("RECORD:"+record);
        refreshScoreGUI();

        if (record>=0)
        {
            recordTextGUI.gameObject.SetActive(true);
            recordTextGUI.text=$"Record: {record}";
        }
    }

    void Update()
    {
        comboCountdown();
    }

    public void AddScore(int val, Vector3 position)
    {
        scoreHold += val;
        Vector3 spawnPos = position;
        spawnPos.y += 2;

        if (val == 500)
        {
            Instantiate(prefab500, spawnPos, prefab500.transform.rotation);
        }
        else
        {
            Instantiate(prefab1000, spawnPos, prefab1000.transform.rotation);
        }
        refreshScoreGUI();

    }

    public void increaseMultiplier()
    {
        Debug.Log("multiplier:" + multiplier);
        multiplier++;
        comboTimer = 3.5f; //resetea el tiempo del combo
        refreshScoreGUI();

    }

    private void comboCountdown()
    {

        if (scoreHold > 0)
        {
            comboTimer -= Time.deltaTime;

            if (comboTimer <= 0)
            {
                score += (scoreHold * multiplier);
                scoreHold = 0;
                multiplier = 1;
                refreshScoreGUI();
            }
        }
    }

    private void refreshScoreGUI() {
        scoreTextGUI.SetText($"Points: {score}\nCombo: {multiplier}");
    }

}
