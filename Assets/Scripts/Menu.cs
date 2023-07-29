using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        //Inicia jogo ao apertar espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
