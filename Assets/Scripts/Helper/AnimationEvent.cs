using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
  
   private PlayerController playerController;
    private Animator animator;

    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("Player bulunamadı! Etiketi kontrol et.");
        }

        animator = GetComponent<Animator>();
    }

    public void ResetShooting()
    {
        if (playerController != null)
        {
            playerController.canShoot = true; 
            animator.Play("idle");
            Debug.Log("canShoot true yapıldı.");
        }
        else
        {
            Debug.LogError("playerController bulunamadı.");
        }
    }


    void CameraStartGame () {
        SceneManager.LoadScene("Play Scene");
    }
}
