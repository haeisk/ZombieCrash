using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float timer = 3f;

    void Start ()
   {
    Invoke("DeactivateGameObject", timer);
   }


    void DeactivateGameObject () 
    {
       gameObject.SetActive(false); 
    }
}
