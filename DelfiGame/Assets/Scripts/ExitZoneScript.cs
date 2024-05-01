using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZoneScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //no la conocia bastante limpio comparado con el ==
        {
            SceneManager.LoadScene(0); //para volver al menu
        }
    }
}
