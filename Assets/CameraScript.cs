using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
   
    public float convertionPlatformToWorld;
    public float cameraSpeed;
    public float cameraSpeedGrowth;
    private float lastHeigthSpawned = 7.125f;
    public GameObject leftPlatforms;
    public GameObject rightPlatforms;
    private int lastPlatformSidedLeft = 0;
    private int lastPlatformSidedRight = 0;
    public int growthThreshold;
    public int eventThreshold;
    private int seriesSpawnedSinceLastSpeedGrowth;
    private int seriesSpawnedSinceLastEvent;
    public float minimumDistance;
    private int changeOfPowerUpLeft = -5;
    private int changeOfPowerUpRight = -5;
    private GameObject[] powerUps;
    private bool gameStarted = false;
    private bool gameReallyStarted = false;
    private float startX;
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    public AudioClip menuTheme;
    public AudioClip gameTheme;

    void Start()
    {
        powerUps = Resources.LoadAll<GameObject>("PowerUps");
        cameraSpeed = cameraSpeed / 1000f;
      
    }


    private void FixedUpdate()
    {
        //start of game
        if (gameStarted)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), Time.fixedDeltaTime*5);

        }
        if (startX - transform.position.x != startX && gameReallyStarted == false && gameStarted == true)
        {
            gameObject.GetComponent<Camera>().orthographicSize = (5 + (4 * (transform.position.x / startX)));
        }
        else if(gameStarted == true)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 5;
            GameStarted();
        }


        transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
        if(transform.position.y + 7f >= lastHeigthSpawned)
        {
            if(seriesSpawnedSinceLastSpeedGrowth == growthThreshold && gameReallyStarted == true) {
                cameraSpeed += cameraSpeedGrowth;
                growthThreshold = (int)Mathf.Round(growthThreshold * 1.5f);
                seriesSpawnedSinceLastSpeedGrowth = 0;
            }
            if(seriesSpawnedSinceLastEvent == eventThreshold && gameReallyStarted == true)
            {
                GameObject.Find("Event").GetComponent<EventSystem>().StartEventTimer();
                seriesSpawnedSinceLastEvent = 0;
            }
            SpawnPlatforms();
            seriesSpawnedSinceLastEvent++;
            seriesSpawnedSinceLastSpeedGrowth++;
        }

    }
    void Update()
    {
        
    }

    void SpawnPlatforms()
    {

        //left
      

        int numberOfPlatforms = Random.Range(1, 4);
        if(numberOfPlatforms == 3)
        {
            numberOfPlatforms = Random.Range(1, 4);
        }
        float positionLastPLatformSpawned = 0;
            ;
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            
            float width = Random.Range(0.9f / convertionPlatformToWorld, ((6.68888f/numberOfPlatforms) - (2*minimumDistance))/convertionPlatformToWorld); 
            float distanceSpawns = (-6.6888f / (numberOfPlatforms)) * (numberOfPlatforms - i) - 1.1f;
           

            float xPos = Random.Range(distanceSpawns,(distanceSpawns + (width*convertionPlatformToWorld + minimumDistance)));
            if (xPos < -(7.78888f- minimumDistance) ) {
                xPos = -7.78888f;

                if (lastPlatformSidedLeft > 0)
                {
                    xPos = -7.7f + minimumDistance;
                }
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedLeft = 2;
                }
              
            }

            if (xPos + width * convertionPlatformToWorld > -(1.1f + minimumDistance))
            {
                xPos = -1.1f - width * convertionPlatformToWorld;
                if (lastPlatformSidedLeft > 0)
                {
                    xPos = (-(1.1f + minimumDistance)) - width * convertionPlatformToWorld;
                }
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedLeft = 2;
                }
                
            }

            if (i > 0 && xPos - positionLastPLatformSpawned < minimumDistance)
            {
                xPos = positionLastPLatformSpawned + minimumDistance;
               
            }

           
            
         
                GameObject platformLeft = Instantiate(leftPlatforms, transform.position, Quaternion.identity);
                platformLeft.transform.position = new Vector3(xPos, lastHeigthSpawned + 4.25f, transform.position.z);
                platformLeft.GetComponent<SpriteRenderer>().size = new Vector2(width, 0.49322f);
                positionLastPLatformSpawned = xPos + width * convertionPlatformToWorld;
                BoxCollider2D bC = platformLeft.GetComponent<BoxCollider2D>();
                bC.size = platformLeft.GetComponent<SpriteRenderer>().size;
                bC.offset = new Vector2(bC.size.x / 2f, bC.size.y / 2f);
                if(Random.Range(0,100) < changeOfPowerUpLeft)
                {

                GameObject powerToSpawn = powerUps[Random.Range(0, powerUps.Length)];
                GameObject powerUp = Instantiate(powerToSpawn, transform.position, Quaternion.identity);
                powerUp.transform.position = new Vector3(platformLeft.transform.position.x + (bC.size.x / 2f), platformLeft.transform.position.y + 1.9593f, transform.position.z);
                changeOfPowerUpLeft = -5;
                }
                else if(gameReallyStarted == true)
                {
                changeOfPowerUpLeft++;
                }


        }
        lastPlatformSidedLeft--;



        //right
         numberOfPlatforms = Random.Range(1, 4);
        if (numberOfPlatforms == 3)
        {
            numberOfPlatforms = Random.Range(1, 4);
        }
        positionLastPLatformSpawned = 0;
        for (int i = 0; i < numberOfPlatforms; i++)
        {

            float width = Random.Range(0.9f / convertionPlatformToWorld, ((6.68888f / numberOfPlatforms) - (2*minimumDistance)) / convertionPlatformToWorld);
            float distanceSpawns = (6.6888f / (numberOfPlatforms)) * (numberOfPlatforms - i) + 1.1f;
           

            
            float xPos = Random.Range(distanceSpawns, (distanceSpawns - (width * convertionPlatformToWorld - minimumDistance)));
            if (xPos > 7.78888f - minimumDistance)
            {
                xPos = 7.78888f;
                if (lastPlatformSidedRight > 0)
                {
                    xPos = 7.7f - minimumDistance;
                }
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedRight = 2;
                }
             
            }

            if (xPos - width * convertionPlatformToWorld < 1.1f + minimumDistance)
            {
                xPos = 1.1f + width * convertionPlatformToWorld;
                if (lastPlatformSidedRight > 0)
                {
                    xPos = 1.1f + width * convertionPlatformToWorld;
                }
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedRight = 2;
                }
               
            }

            if (i > 0 &&  positionLastPLatformSpawned - xPos < minimumDistance)
            {
               
                xPos = positionLastPLatformSpawned - minimumDistance;
            }




            GameObject platform = Instantiate(rightPlatforms, transform.position, Quaternion.identity);
            platform.transform.position = new Vector3(xPos, lastHeigthSpawned + 4.25f, transform.position.z);
            platform.GetComponent<SpriteRenderer>().size = new Vector2(width, 0.49322f);
            positionLastPLatformSpawned = xPos - width * convertionPlatformToWorld;
            BoxCollider2D bC = platform.GetComponent<BoxCollider2D>();
            bC.size = platform.GetComponent<SpriteRenderer>().size;
            bC.offset = new Vector2(-bC.size.x / 2f, bC.size.y / 2f);

            if (Random.Range(0, 100) < changeOfPowerUpLeft)
            {
                GameObject powerToSpawn = powerUps[Random.Range(0, powerUps.Length)];
                GameObject powerUp = Instantiate(powerToSpawn, transform.position, Quaternion.identity);
                powerUp.transform.position = new Vector3(platform.transform.position.x - (bC.size.x / 2f), platform.transform.position.y + 1.9593f, transform.position.z);
                changeOfPowerUpRight = -5;
            }
            else if(gameReallyStarted == true)
            {
                changeOfPowerUpRight++;
            }
        }
        lastPlatformSidedRight--;
        lastHeigthSpawned += 3f;


    }


    public void StartGame()
    {
        startX = transform.position.x;
        cameraSpeed = 0;
        changeOfPowerUpLeft = -5;
        changeOfPowerUpRight = -5;
        seriesSpawnedSinceLastSpeedGrowth = 0;
        seriesSpawnedSinceLastEvent = 0;
        gameStarted = true;

        GetComponent<AudioSource>().clip = gameTheme;
        GetComponent<AudioSource>().Play();
    }

    void GameStarted()
    {
        cameraSpeed = 15 / 1000f;
        cameraSpeedGrowth = 5 / 1000f;
        GameObject leftPlatform = null;
        GameObject rightPlatform = null;
        foreach(GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
        {
            if(platform.transform.position.y < gameObject.transform.position.y + 4 && platform.transform.position.y > gameObject.transform.position.y - 4)
            {
                if(platform.transform.position.x < 0)
                {
                    leftPlatform = platform;
                }
                else
                {
                    rightPlatform = platform;
                }
            }
        }
       
        
        GameObject player1 = Instantiate(playerOnePrefab, new Vector3(leftPlatform.transform.position.x + leftPlatform.GetComponent<BoxCollider2D>().size.x / 2f, leftPlatform.transform.position.y + leftPlatform.GetComponent<BoxCollider2D>().size.y / 2f, transform.position.z), Quaternion.identity);
        player1.name = ("Player1");          
        GameObject player2 = Instantiate(playerTwoPrefab, new Vector3(rightPlatform.transform.position.x - rightPlatform.GetComponent<BoxCollider2D>().size.x / 2f, rightPlatform.transform.position.y + rightPlatform.GetComponent<BoxCollider2D>().size.y / 2f, transform.position.z), Quaternion.identity);
        player2.name = ("Player2");
        player2.GetComponent<DefaultMovement>().player = 2;
        gameStarted = false;
        gameReallyStarted = true;
    }

    public void EndGame()
    {

    }

    public void ReverseCamera()
    {
        transform.rotation = new Quaternion(0, 0, -180,Quaternion.identity.w);
        
    }
}
