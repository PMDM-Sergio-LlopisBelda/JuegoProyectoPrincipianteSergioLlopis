using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorArrow;

    //Cuenta de Islas
    public static float Ilands = -1;

    //Transforms
    public GameObject GameOverScreen;
    public GameObject MainMenuScreen;
    public GameObject Player;
    public GameObject Gun;
    bool GameHasEnded = false;
    int GameHasAlreadyStarted;
    public Transform Platform;
    public Transform PlatformDetectorRight;
    public Transform PlatformDetectorLeft;
    public Transform PlayerDetectorRight;
    public Transform PlayerDetectorLeft;
    public Transform LevelGenerator;
    public Transform EnemyGenerator;
    public Transform Lava;
    public Transform PlayerForFollowing;
    public static bool AllEnemiesDead = false;
    public GameObject[] enemies;

    //Distancias y Demás
    private float LeftPlatformPlacement = 13f;
    private float RightPlatformPlacement = 13f;
    private float DetectorPlatformPlacementLeft = 50f;
    private float DetectorPlatformPlacementRight = 50f;
    private bool PlatformHaveAlreadyMoved = false;


    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
 
    /*public void MainMenu()
    {
       if (InMainMenuStage == false)
        {
            MainMenuScreen.gameObject.SetActive(false);
            StartGame();
        }
    }
    */
    void Update()
    {
        /*if (Input.GetButtonDown("Cancel"))
        {
            Camera.Size + 1;
        }

        if (Input.GetButtonDown("Submit"))
        {
            //jump = true;
        }*/


        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        Platform = GameObject.FindGameObjectWithTag("Platform").transform;
        PlatformDetectorRight = GameObject.FindGameObjectWithTag("PlatformDetectorRight").transform;
        PlatformDetectorLeft = GameObject.FindGameObjectWithTag("PlatformDetectorLeft").transform;
        PlayerDetectorLeft = GameObject.FindGameObjectWithTag("PlayerDetectorLeft").transform;
        PlayerDetectorRight = GameObject.FindGameObjectWithTag("PlayerDetectorRight").transform;
        LevelGenerator = GameObject.FindGameObjectWithTag("LevelGenerator").transform;
        EnemyGenerator = GameObject.FindGameObjectWithTag("EnemyGenerator").transform;
        Lava = GameObject.FindGameObjectWithTag("Lava").transform;
        PlayerForFollowing = GameObject.FindGameObjectWithTag("Player").transform;


        float distanceRight = Vector3.Distance(PlatformDetectorRight.transform.position, Platform.transform.position);
        float distanceLeft = Vector3.Distance(PlatformDetectorLeft.transform.position, Platform.transform.position);
        float distancePlayer = Vector3.Distance(Player.transform.position, transform.position);
        //float distanceEnemyGenerator = Vector3.Distance(Player.transform.position, EnemyGenerator.transform.position);

        Lava.transform.position = new Vector3(PlayerForFollowing.position.x, -8, transform.localPosition.z);

        

        if (enemies.Length >= 1)
        {
            AllEnemiesDead = false;
        }

        if (enemies.Length <= 0 && AllEnemiesDead == false)
        {
            Ilands++;
            AllEnemiesDead = true;
            Debug.Log("All enemies are Dead");

            /*if (distanceEnemyGenerator >= 30 && GameObject.FindGameObjectWithTag("EnemyGenerator"))
            {
                //Debug.Log(this.gameObject);
                Destroy(this.gameObject);
            }*/
            if (Ilands >= 1)
            {


                if (distanceLeft >= 30 && PlatformHaveAlreadyMoved == true && Player.transform.position.x < 0)
                {
                    PlatformDetectorLeft.transform.position = new Vector3(DetectorPlatformPlacementLeft - 16, transform.position.y - 1, transform.localPosition.z);
                    Instantiate(Platform, new Vector3(transform.position.x - LeftPlatformPlacement, transform.position.y - 2, transform.localPosition.z), Quaternion.identity);
                    Instantiate(LevelGenerator, new Vector3(transform.position.x - DetectorPlatformPlacementLeft, transform.position.y, transform.localPosition.z), Quaternion.identity);
                    Instantiate(EnemyGenerator, new Vector3(transform.position.x - DetectorPlatformPlacementLeft, transform.position.y, transform.localPosition.z), Quaternion.identity);
                    DetectorPlatformPlacementLeft += 50;
                    LeftPlatformPlacement += 50;
                }
                else if (distanceLeft >= 30 && PlatformHaveAlreadyMoved == false)
                {
                    if (PlatformHaveAlreadyMoved == false)
                    {
                        PlatformDetectorLeft.transform.position = new Vector3(-66, transform.position.y - 1, transform.localPosition.z);
                    }
                    else
                    {
                        PlatformDetectorLeft.transform.position = new Vector3(-DetectorPlatformPlacementLeft - 16, transform.position.y - 1, transform.localPosition.z);
                    }
                    Instantiate(Platform, new Vector3(transform.position.x - LeftPlatformPlacement, transform.position.y - 2, transform.localPosition.z), Quaternion.identity);
                    Instantiate(LevelGenerator, new Vector3(transform.position.x - DetectorPlatformPlacementLeft, transform.position.y, transform.localPosition.z), Quaternion.identity);
                    Instantiate(EnemyGenerator, new Vector3(transform.position.x - DetectorPlatformPlacementLeft, transform.position.y, transform.localPosition.z), Quaternion.identity);
                    DetectorPlatformPlacementLeft += 50;
                    LeftPlatformPlacement += 50;
                }
                if (distanceRight >= 30 && PlatformHaveAlreadyMoved == true && Player.transform.position.x >= 0)
                {
                    PlatformDetectorRight.transform.position = new Vector3(DetectorPlatformPlacementRight + 16, transform.position.y - 1, transform.localPosition.z);
                    Instantiate(Platform, new Vector3(transform.position.x + RightPlatformPlacement, transform.position.y - 2, transform.localPosition.z), Quaternion.identity);
                    Instantiate(LevelGenerator, new Vector3(transform.position.x + DetectorPlatformPlacementRight, transform.position.y, transform.localPosition.z), Quaternion.identity);
                    Instantiate(EnemyGenerator, new Vector3(transform.position.x + DetectorPlatformPlacementRight, transform.position.y, transform.localPosition.z), Quaternion.identity);
                    DetectorPlatformPlacementRight += 50;
                    RightPlatformPlacement += 50;
                }
                else if (distanceRight >= 30 && PlatformHaveAlreadyMoved == false)
                {
                    if (PlatformHaveAlreadyMoved == false)
                    {
                        PlatformDetectorRight.transform.position = new Vector3(66, transform.position.y - 1, transform.localPosition.z);
                    }
                    else
                    {
                        PlatformDetectorRight.transform.position = new Vector3(DetectorPlatformPlacementRight + 16, transform.position.y - 1, transform.localPosition.z);
                    }
                    Instantiate(Platform, new Vector3(transform.position.x + RightPlatformPlacement, transform.position.y - 2, transform.localPosition.z), Quaternion.identity);
                    Instantiate(LevelGenerator, new Vector3(transform.position.x + DetectorPlatformPlacementRight, transform.position.y, transform.localPosition.z), Quaternion.identity);
                    Instantiate(EnemyGenerator, new Vector3(transform.position.x + DetectorPlatformPlacementRight, transform.position.y, transform.localPosition.z), Quaternion.identity);
                    DetectorPlatformPlacementRight += 50;
                    RightPlatformPlacement += 50;
                }
                PlatformHaveAlreadyMoved = true;


            }
        }

    }


    public void GameOver()
    {
       if (GameHasEnded == false)
       {
            GameHasEnded = true;
            GameOverScreen.gameObject.SetActive(true); 
            Player.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            //Restart();
       }
        
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        MainMenuScreen.gameObject.SetActive(false);
        GameHasAlreadyStarted += 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    } 

}
