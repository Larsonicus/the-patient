using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    private bool isDead = false;
    public GameController gameController;
    public SFPSC_PlayerMovement playerMovement;

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;

        playerMovement.DisableMovement();
        gameController.GameOver();

        Debug.Log("Player died");
    }
}
