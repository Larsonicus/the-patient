using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public SFPSC_FPSCamera camera;

    public void GameOver() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        camera.LockCamera();

        gameOverScreen.Setup();
    }
}
