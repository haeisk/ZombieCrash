using UnityEngine;



public class SmoothFollow : MonoBehaviour

{

    // Start is called once before the first execution of Update after the MonoBehaviour is created



 public Transform target;
 public float smoothSpeed = 0.3f;

public float distance = 6.4f;

 public float height = 3.5f;

 public float height_Damping = 3.25f;

public float rotation_Damping = 0.27f;



 void Start()

{

target = GameObject.FindGameObjectWithTag("Player").transform;

 }

 private void LateUpdate() {
    // Smoothly move the player towards the target position
    FollowPlayer();
 }



    // Update is called once per frame

 void FollowPlayer()

 {

 float wanted_Rotation_Angle = target.eulerAngles.y;

 float wanted_Height = target.position.y + height;



 float current_Rotation_Angle = transform.position.y;

 float current_Height = transform.position.y;



 current_Rotation_Angle = Mathf.LerpAngle(
 current_Rotation_Angle, wanted_Rotation_Angle, rotation_Damping * Time.deltaTime) ;

 current_Height = Mathf.Lerp (

 current_Height, wanted_Height, height_Damping * Time.deltaTime);





 Quaternion currrent_Rotation = Quaternion.Euler (0f, current_Rotation_Angle,0f); 



transform.position = target.position;

 transform.position -= currrent_Rotation * Vector3.forward * distance;



 transform.position = new Vector3 (transform.position.x,current_Height,transform.position.z );
}

}