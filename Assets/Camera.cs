using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
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
    private int changeOfPowerUpLeft;
    private int changeOfPowerUpRight;
    private GameObject[] powerUps;

    void Start()
    {
        cameraSpeed = cameraSpeed / 1000f;
        cameraSpeedGrowth = cameraSpeedGrowth / 1000f;
        changeOfPowerUpLeft = -5;
        changeOfPowerUpRight = -5;
        powerUps = Resources.LoadAll<GameObject>("PowerUps");
        Debug.Log(powerUps.Length);
    }


    private void FixedUpdate()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
        if(transform.position.y + 3.5f >= lastHeigthSpawned)
        {
            if(seriesSpawnedSinceLastSpeedGrowth == growthThreshold) {
                cameraSpeed += cameraSpeedGrowth;
                growthThreshold = (int)Mathf.Round(growthThreshold * 1.5f);
                seriesSpawnedSinceLastSpeedGrowth = 0;
            }
            if(seriesSpawnedSinceLastEvent == eventThreshold)
            {

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
                else
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
            else
            {
                changeOfPowerUpRight++;
            }
        }
        lastPlatformSidedRight--;
        lastHeigthSpawned += 3.0f;


    }


    public void StartGame()
    {

    }

    public void EndGame()
    {

    }

    public void ReverseCamera()
    {
        transform.rotation = new Quaternion(0, 0, -180,Quaternion.identity.w);
        
    }
}
