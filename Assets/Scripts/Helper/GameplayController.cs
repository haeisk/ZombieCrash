using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    public GameObject[] obstaclePrefabs;
    public GameObject[] zombiePrefab;

    public Transform[]  lanes;
    public float min_ObstacleDelay = 10f, max_ObstacleDelay = 40f;
    private float halfGroundSize;
    private BaseController playerController;

    private TextMeshProUGUI score_Text;
    private int zombie_Kill_Count;
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField] 
    private GameObject gameover_Panel;

    [SerializeField] 
    private TextMeshProUGUI final_score;




   private void Awake() {
        MakeInstance ();

    }
    void Start()

    {


      
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseController>();
        StartCoroutine("GenerateObstacles");
        halfGroundSize = GameObject.Find ("GroundBlock Main").GetComponent<GroundBlock>().halfLenght;

        score_Text = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
       
    }


   
    void  MakeInstance() {
        if (instance == null) {
            instance = this;
        }else if (instance != null) {
            Destroy(gameObject); 
        }
    }

    IEnumerator GenerateObstacles() {
        float timer = Random.Range(min_ObstacleDelay, max_ObstacleDelay) / playerController.speed.z;
        yield return new WaitForSeconds(timer);

        CreateObstacles (playerController.gameObject.transform.position.z+halfGroundSize);
        StartCoroutine ("GenerateObstacles");
    }
    void CreateObstacles (float zPos) 
    {
        int r = Random.Range(0,10);

        if(0 <= r && r <7 ){
            int obstacleLane = Random.Range(0,lanes.Length);
            
            AddObstacle (new Vector3(lanes[obstacleLane].transform.position.x,0f,zPos ), Random.Range(0,obstaclePrefabs.Length));
            int zombieLane= 0;
            if (obstacleLane ==0 )
            {
                zombieLane = Random.Range(0,2) == 1 ? 1 : 2 ;
            } else if (obstacleLane == 1) {
                zombieLane = Random.Range(0,2) == 1 ? 1 : 2;
            } else if (obstacleLane == 2){
                zombieLane = Random.Range(0,2) == 1 ? 1 : 0;
            }
            AddZombies (new Vector3(lanes[zombieLane].transform.position.x,0.15f, zPos));
        }
    }

    void AddObstacle(Vector3 position, int type) {
        GameObject obstacle = Instantiate (obstaclePrefabs[type],position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;

        switch (type) {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f,mirror ? -20 : 20,0f) ;
                break;
            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f,mirror ? -20 : 20,0f) ;
                break;
            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0f,mirror ? -1 : 1,0f) ;
                break;
            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0f,mirror ? -170 : 170,0f);      
                break;
        }

        obstacle.transform.position = position;

    }

    void AddZombies (Vector3 pos) {
        int count = Random.Range(0,3)+1;

        for (int i = 0;i < count; i++) {
            Vector3 shift = new Vector3(Random.Range(-0.5f, 0.5f),0f, Random.Range(1f, -10f)*i);
            Instantiate (zombiePrefab[Random.Range(0, zombiePrefab.Length)] ,pos + shift * i, Quaternion.identity );
        }

    }

    public void IncreaseScore () {

          if (score_Text == null)
        {
            Debug.LogError("scoreText is null!");
            return;
        }

        zombie_Kill_Count ++ ;
        score_Text.text = zombie_Kill_Count.ToString() ;
    }

    public void PauseGame() {
        pausePanel.SetActive (true);
        Time.timeScale = 0f ;
    }

    public void ResumeGame () {
        pausePanel.SetActive (false);
        Time.timeScale = 1f ;
    }

    public void ExitGame() {
     //  Time.timeScale = 1f ;
     //  SceneManager.LoadScene ("MainMenu");
    }

    public void Gameover () {
        Time.timeScale = 0f ;
        gameover_Panel.SetActive (true);
        final_score.text = "Killed : "+ zombie_Kill_Count.ToString(); 



    }

    public void Restart () {
        Time.timeScale = 1f ;
        // SceneManager.LoadScene ("Gameplay");
    }

}
