using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    private Slider health_Slider ;
    private GameObject UI_Holder;
            void Start()
    {
        health_Slider = GameObject.Find("Health Bar").GetComponent<Slider>();

        health_Slider.value =  health;

        UI_Holder = GameObject.Find("UI Holder");
    }

    public void ApplyDamage (int damageAmount) 
    {

        health -= damageAmount;
        
        if (health< 0 ){
            health = 0;
        }
        health_Slider.value = health;

        if (health== 0 ){
            UI_Holder.SetActive(false);

           GameplayController.instance.Gameover ();

        }

    }
}
