﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("BrendenTest");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credit Scene");
    }
}