using UnityEngine;

public class GroundBlock : MonoBehaviour
{

    public Transform otherBlock; 
    public float halfLenght = 100f;
    private Transform player ;
    private float endOffSet = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();   
    }

    void MoveGround( ) {
        if ( transform.position.z + halfLenght < player.transform.position.z - endOffSet){
            transform.position = new Vector3( otherBlock.position.x,otherBlock.position.y, otherBlock.position.z + halfLenght*2 );
        }
    } 


}
