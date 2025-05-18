using UnityEngine;

public class MenuController : MonoBehaviour
{
   
    public Animator cameraAnimator;
    

    public void PlayGame(){

        cameraAnimator.Play("Camera Anim");
    }



}
