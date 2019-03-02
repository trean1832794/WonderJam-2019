using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public int wichOne;
    public float convertionPlatformToWorld;
    public float cameraSpeed;
    public float cameraSpeedGrowth;
    private float lastHeigthSpawned = 7.125f;
    public GameObject leftPlatforms;
    public GameObject rightPlatforms;
    private int lastPlatformSidedLeft = 0;
    private int lastPlatformSidedRight = 0;
    
    
    void Start()
    {
        cameraSpeed = cameraSpeed / 1000f;
    }


    private void FixedUpdate()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
        if(transform.position.y + 5f >= lastHeigthSpawned)
        {
            SpawnPlatforms();
        }

    }
    void Update()
    {
        
    }

    void SpawnPlatforms()
    {

        //left
      

        int numberOfPlatforms = Random.Range(1, 4);
        float positionLastPLatformSpawned = 0;
            ;
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            
            float width = Random.Range(0.9f / convertionPlatformToWorld, ((6.68888f/numberOfPlatforms) - 1.2f)/convertionPlatformToWorld); 
            float distanceSpawns = (-6.6888f / (numberOfPlatforms)) * (numberOfPlatforms - i) - 1.1f;
           

            float xPos = Random.Range(distanceSpawns,(distanceSpawns + (width*convertionPlatformToWorld + 0.6f)));
            if (xPos < -7.18888f) {
                xPos = -7.78888f;

                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedLeft = 2;
                }
                if(lastPlatformSidedLeft > 0)
                {
                    xPos = -7.1f;
                }
            }

            if (xPos + width * convertionPlatformToWorld > -1.7f)
            {
                xPos = -1.1f - width * convertionPlatformToWorld;
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedLeft = 2;
                }
                if (lastPlatformSidedLeft > 0)
                {
                    xPos = -1.7f - width * convertionPlatformToWorld;
                }
            }

            if (i > 0 && xPos - positionLastPLatformSpawned < 0.6f)
            {
                xPos = positionLastPLatformSpawned + 0.6f;
               
            }

           
            
         
                GameObject platformLeft = Instantiate(leftPlatforms, transform.position, Quaternion.identity);
                platformLeft.transform.position = new Vector3(xPos, lastHeigthSpawned + 4.25f, transform.position.z);
                platformLeft.transform.localScale = new Vector3(width, 0.1725f, transform.localScale.z);
                positionLastPLatformSpawned = xPos + width * convertionPlatformToWorld;
       
            
        }
        lastPlatformSidedLeft--;



        //right
         numberOfPlatforms = Random.Range(1, 4);
         positionLastPLatformSpawned = 0;
        for (int i = 0; i < numberOfPlatforms; i++)
        {

            float width = Random.Range(0.9f / convertionPlatformToWorld, ((6.68888f / numberOfPlatforms) - 1.2f) / convertionPlatformToWorld);
            float distanceSpawns = (6.6888f / (numberOfPlatforms)) * (numberOfPlatforms - i) + 1.1f;
           

            
            float xPos = Random.Range(distanceSpawns, (distanceSpawns - (width * convertionPlatformToWorld - 0.6f)));
            if (xPos > 7.18888f)
            {
                xPos = 7.78888f;
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedLeft = 2;
                }
                if (lastPlatformSidedLeft > 0)
                {
                    xPos = 7.1f;
                }
            }

            if (xPos - width * convertionPlatformToWorld < 1.7f)
            {
                xPos = 1.1f + width * convertionPlatformToWorld;
                if (i + 1 == numberOfPlatforms)
                {
                    lastPlatformSidedLeft = 2;
                }
                if (lastPlatformSidedLeft > 0)
                {
                    xPos = 1.1f + width * convertionPlatformToWorld;
                }
            }

            if (i > 0 &&  positionLastPLatformSpawned - xPos < 0.6f)
            {
               
                xPos = positionLastPLatformSpawned - 0.6f;
            }




            GameObject platform = Instantiate(rightPlatforms, transform.position, Quaternion.identity);
            platform.transform.position = new Vector3(xPos, lastHeigthSpawned + 4.25f, transform.position.z);
            platform.transform.localScale = new Vector3(width, 0.1725f, transform.localScale.z);
            positionLastPLatformSpawned = xPos - width * convertionPlatformToWorld;


        }
       


        lastHeigthSpawned += 4.25f;


    }
}
