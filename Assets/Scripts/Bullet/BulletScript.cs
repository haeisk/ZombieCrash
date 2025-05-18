using UnityEngine;

public class BulletScript : MonoBehaviour
{


    [SerializeField] private Rigidbody mybody ;
    
    public void Move (float speed ) {
        mybody.AddForce (transform.forward.normalized * speed)  ;
       Invoke ("DeactivateGameObject", 5f);
    }
    void Start()
    {
        
    }

     void OnCollisionEnter(Collision target) {
        if (target.gameObject.tag == "Obstacle") {
            gameObject.SetActive (false);
        }
        
    }
    // Update is called once per frame
    void DeactivateGameObject()
    {
        gameObject.SetActive (false);   
    }
}
