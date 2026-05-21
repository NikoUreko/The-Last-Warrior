using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
    public AudioSource footstepSource, jumpSource;


    void Update()
    {
        // Saat bergerak
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepSource.enabled = true;
        }
        else
        {
            footstepSource.enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSource.Play();
            footstepSource.enabled = false;
        } 

        if (PlayerHealth.Instance.isDead)
        {
            jumpSource.enabled = false;
            footstepSource.enabled = false;
            return;
        }
        
        if (WinManager.Instance != null && WinManager.Instance.gameWon)
        {
            jumpSource.enabled = false;
            footstepSource.enabled = false;
            return;
        }
    }
}