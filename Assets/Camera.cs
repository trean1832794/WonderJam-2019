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
    public float minDistancePlatforms;
    public int numberOfSeriesSpawned;
    public int growthThreshold;
    public int eventThreshold;



    void Start()
    {
        cameraSpeed = cameraSpeed / 1000f;
        cameraSpeedGrowth = cameraSpeedGrowth / 1000f;
       
    }


    private void FixedUpdate()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
        if(transform.position.y + 3.5f >= lastHeigthSpawned)
        {
           
            if (numberOfSeriesSpawned % growthThreshold == 0)
            {
                cameraSpeed += cameraSpeedGrowth;
                growthThreshold = growthThreshold*2;
            }

            if (numberOfSeriesSpawned % eventThreshold == 0 && numberOfSeriesSpawned > 0)
            {

            }
            SpawnPlatforms();
            numberOfSeriesSpawned++;
        }

      

    }
    void Update()
    {
        
    }

    void SpawnPlatforms()
    {






        //left
      

        int numberOfPlatforms = Random.Range(1, 4);
        if (numberOfPlatforms == 3) {
          numberOfPlatforms = Random.Range(1, 4);
        }
        float positionLastPLatformSpawned = 0;
            ;
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            
            float width = Random.Range(0.9f / convertionPlatformToWorld, ((6.68888f/numberOfPlatforms) - (2*minDistancePlatforms))/convertionPlatformToWorld); 
            float distanceSpawns = (-6.6888f / (numberOfPlatforms)) * (numberOfPlatforms - i) - 1.1f;
           

            float xPos = Random.Range(distanceSpawns,(distanceSpawns + (width*convertionPlatformToWorld +minDistancePlatforms)));
            if (xPos < -(7.78888f-minDistancePlatforms)) {
                xPos = -7.78888f;

             
                if(lastPlatformSidedLeft > 0)
                {
                    xPos = -(7.7f - minDistancePlatforms);
                }
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedLeft = 2;
                }
            }

            if (xPos + width * convertionPlatformToWorld > -(1.1f+minDistancePlatforms))
            {
            
                xPos = -1.1f - (width * convertionPlatformToWorld);
               
                if (lastPlatformSidedLeft > 0)
                {
                    
                    xPos = -(1.1f + minDistancePlatforms) - width * convertionPlatformToWorld;
                }
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedLeft = 2;
                }
            }

            if (i > 0 && xPos - positionLastPLatformSpawned < minDistancePlatforms)
            {
                xPos = positionLastPLatformSpawned + minDistancePlatforms;
               
            }

           
            
         
                GameObject platformLeft = Instantiate(leftPlatforms, transform.position, Quaternion.identity);
                platformLeft.transform.position = new Vector3(xPos, lastHeigthSpawned + 4.25f, transform.position.z);
                platformLeft.transform.localScale = new Vector3(width, 0.1725f, transform.localScale.z);
                positionLastPLatformSpawned = xPos + width * convertionPlatformToWorld;
       
            
        }
        lastPlatformSidedLeft--;



        //right
         numberOfPlatforms = Random.Range(1, 4);
        if(numberOfPlatforms == 3)
        {
            numberOfPlatforms = Random.Range(1, 4);
        }
         positionLastPLatformSpawned = 0;
        for (int i = 0; i < numberOfPlatforms; i++)
        {

            float width = Random.Range(0.9f / convertionPlatformToWorld, ((6.68888f / numberOfPlatforms) - (2*minDistancePlatforms)) / convertionPlatformToWorld);
            float distanceSpawns = (6.6888f / (numberOfPlatforms)) * (numberOfPlatforms - i) + 1.1f;
           

            
            float xPos = Random.Range(distanceSpawns, (distanceSpawns - (width * convertionPlatformToWorld - minDistancePlatforms)));
            if (xPos > 7.78888-minDistancePlatforms)
            {
                xPos = 7.78888f;
              
                if (lastPlatformSidedRight > 0)
                {
                    xPos = 7.7f - minDistancePlatforms;
                }
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedRight = 2;
                }
            }

            if (xPos - width * convertionPlatformToWorld < 1.1f+minDistancePlatforms)
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

            if (i > 0 &&  positionLastPLatformSpawned - xPos < minDistancePlatforms)
            {
               
                xPos = positionLastPLatformSpawned - minDistancePlatforms;
            }




            GameObject platform = Instantiate(rightPlatforms, transform.position, Quaternion.identity);
            platform.transform.position = new Vector3(xPos, lastHeigthSpawned + 4.25f, transform.position.z);
            platform.transform.localScale = new Vector3(width, 0.1725f, transform.localScale.z);
            positionLastPLatformSpawned = xPos - width * convertionPlatformToWorld;


        }
        lastPlatformSidedRight--;


        lastHeigthSpawned += 3.0f;


    }
}
