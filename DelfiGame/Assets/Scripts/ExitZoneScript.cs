using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZoneScript : MonoBehaviour
{
    public Score scoreController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //no la conocia bastante limpio comparado con el ==
        {
            scoreController.comboTimer = 0; //para terminar el combo si existiera

            if (scoreController.score > scoreController.record)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "score", scoreController.score);

            }

            SceneManager.LoadScene(0); //para volver al menu
        }
    }
}
