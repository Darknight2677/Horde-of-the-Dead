using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle }

public class Gamecontroller : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldcamera;
    GameState state;

    private void Update()
    {
        if(state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
            worldcamera.gameObject.SetActive(false);
        }
    }
}
