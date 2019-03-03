using UnityEngine;

public class CameraScript : MonoBehaviour {

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
    public int mininumPowerUpChance;
    public float minimumDistance;
    private int chanceOfPowerUpLeft = -5;
    private int chanceOfPowerUpRight = -5;
    private GameObject[] powerUps;
    private bool gameStarted = false;
    private bool gameReallyStarted = false;
    private float startX;
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    public GameObject victorySprite;
    public GameObject torch;
    private GameObject victoryPose;
    

    public AudioClip menuTheme;
    public AudioClip gameTheme;
    public AudioClip victorySound;

    private GameObject scoreCanvas;

    void Start() {
        powerUps = Resources.LoadAll<GameObject>("PowerUps");
        cameraSpeed = cameraSpeed / 1000f;

        scoreCanvas = GameObject.Find("Scores");
        scoreCanvas.SetActive(false);

    }


    private void FixedUpdate() {
        //start of game
        if (gameStarted) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), Time.fixedDeltaTime * 5);

        }
        if (startX - transform.position.x != startX && gameReallyStarted == false && gameStarted == true) {
            gameObject.GetComponent<Camera>().orthographicSize = (5 + (4 * (transform.position.x / startX)));
        } else if (gameStarted == true) {
            gameObject.GetComponent<Camera>().orthographicSize = 5;
            GameStarted();
        }


        transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
        if (transform.position.y + 7f >= lastHeigthSpawned) {
            if (seriesSpawnedSinceLastSpeedGrowth == growthThreshold && gameReallyStarted == true) {
                cameraSpeed += cameraSpeedGrowth;
                growthThreshold = (int)Mathf.Round(growthThreshold * 1.5f);
                seriesSpawnedSinceLastSpeedGrowth = 0;
            }
            if (seriesSpawnedSinceLastEvent == eventThreshold && gameReallyStarted == true) {
                GameObject.Find("Event").GetComponent<EventSystem>().StartEventTimer();
                seriesSpawnedSinceLastEvent = 0;
            }
            SpawnPlatforms();
            seriesSpawnedSinceLastEvent++;
            seriesSpawnedSinceLastSpeedGrowth++;
        }

    }
    void Update() {

    }

    void SpawnPlatforms() {

        //left


        int numberOfPlatforms = Random.Range(1, 4);
        if (numberOfPlatforms == 3) {
            numberOfPlatforms = Random.Range(1, 4);
        }
        float positionLastPLatformSpawned = 0;
        ;
        for (int i = 0; i < numberOfPlatforms; i++) {

            float width = Random.Range(0.9f / convertionPlatformToWorld, ((6.68888f / numberOfPlatforms) - (2 * minimumDistance)) / convertionPlatformToWorld);
            float distanceSpawns = (-6.6888f / (numberOfPlatforms)) * (numberOfPlatforms - i) - 1.1f;


            float xPos = Random.Range(distanceSpawns, (distanceSpawns + (width * convertionPlatformToWorld + minimumDistance)));
            if (xPos < -(7.78888f - minimumDistance)) {
                xPos = -7.78888f;

                if (lastPlatformSidedLeft > 0) {
                    xPos = -7.7f + minimumDistance;
                }
                if (i + 1 == numberOfPlatforms) {
                    lastPlatformSidedLeft = 2;
                }

            }

            if (xPos + width * convertionPlatformToWorld > -(1.1f + minimumDistance)) {
                xPos = -1.1f - width * convertionPlatformToWorld;
                if (lastPlatformSidedLeft > 0) {
                    xPos = (-(1.1f + minimumDistance)) - width * convertionPlatformToWorld;
                }
                if (i + 1 == numberOfPlatforms) {
                    lastPlatformSidedLeft = 2;
                }

            }

            if (i > 0 && xPos - positionLastPLatformSpawned < minimumDistance) {
                xPos = positionLastPLatformSpawned + minimumDistance;

            }




            GameObject platformLeft = Instantiate(leftPlatforms, transform.position, Quaternion.identity);
            platformLeft.transform.position = new Vector3(xPos, lastHeigthSpawned + 4.25f, transform.position.z);
            platformLeft.GetComponent<SpriteRenderer>().size = new Vector2(width, 0.49322f);
            positionLastPLatformSpawned = xPos + width * convertionPlatformToWorld;
            BoxCollider2D bC = platformLeft.GetComponent<BoxCollider2D>();
            bC.size = platformLeft.GetComponent<SpriteRenderer>().size;
            bC.offset = new Vector2(bC.size.x / 2f, bC.size.y / 2f);
            if (Random.Range(0, 100) < chanceOfPowerUpLeft) {
                int powerNbr = Random.Range(0, powerUps.Length);
                // SI (Les deux joueurs sont en vie OU le power up est un power up qui marche en solo)
                if ((GameObject.Find("Player1") != null && GameObject.Find("Player2") != null) || (powerNbr == 0 || powerNbr == 2 || powerNbr == 4)) {
                    GameObject powerToSpawn = powerUps[powerNbr];
                    GameObject powerUp = Instantiate(powerToSpawn, transform.position, Quaternion.identity);
                    powerUp.transform.position = new Vector3(platformLeft.transform.position.x + (bC.size.x / 2f), platformLeft.transform.position.y + 1.9593f, transform.position.z);
                }
                chanceOfPowerUpLeft = mininumPowerUpChance;
            } else if (gameReallyStarted == true) {
                chanceOfPowerUpLeft++;
            }


        }
        lastPlatformSidedLeft--;



        //right
        numberOfPlatforms = Random.Range(1, 4);
        if (numberOfPlatforms == 3) {
            numberOfPlatforms = Random.Range(1, 4);
        }
        positionLastPLatformSpawned = 0;
        for (int i = 0; i < numberOfPlatforms; i++) {

            float width = Random.Range(0.9f / convertionPlatformToWorld, ((6.68888f / numberOfPlatforms) - (2 * minimumDistance)) / convertionPlatformToWorld);
            float distanceSpawns = (6.6888f / (numberOfPlatforms)) * (numberOfPlatforms - i) + 1.1f;



            float xPos = Random.Range(distanceSpawns, (distanceSpawns - (width * convertionPlatformToWorld - minimumDistance)));
            if (xPos > 7.78888f - minimumDistance) {
                xPos = 7.78888f;
                if (lastPlatformSidedRight > 0) {
                    xPos = 7.7f - minimumDistance;
                }
                if (i + 1 == numberOfPlatforms) {
                    lastPlatformSidedRight = 2;
                }

            }

            if (xPos - width * convertionPlatformToWorld < 1.1f + minimumDistance) {
                xPos = 1.1f + width * convertionPlatformToWorld;
                if (lastPlatformSidedRight > 0) {
                    xPos = 1.1f + width * convertionPlatformToWorld;
                }
                if (i + 1 == numberOfPlatforms) {
                    lastPlatformSidedRight = 2;
                }

            }

            if (i > 0 && positionLastPLatformSpawned - xPos < minimumDistance) {

                xPos = positionLastPLatformSpawned - minimumDistance;
            }




            GameObject platform = Instantiate(rightPlatforms, transform.position, Quaternion.identity);
            platform.transform.position = new Vector3(xPos, lastHeigthSpawned + 4.25f, transform.position.z);
            platform.GetComponent<SpriteRenderer>().size = new Vector2(width, 0.49322f);
            positionLastPLatformSpawned = xPos - width * convertionPlatformToWorld;
            BoxCollider2D bC = platform.GetComponent<BoxCollider2D>();
            bC.size = platform.GetComponent<SpriteRenderer>().size;
            bC.offset = new Vector2(-bC.size.x / 2f, bC.size.y / 2f);

            if (Random.Range(0, 100) < chanceOfPowerUpRight) {
                int powerNbr = Random.Range(0, powerUps.Length);
                if ((GameObject.Find("Player1") != null && GameObject.Find("Player2") != null) || (powerNbr == 0 || powerNbr == 2 || powerNbr == 4)) {
                    GameObject powerToSpawn = powerUps[Random.Range(0, powerUps.Length)];
                    GameObject powerUp = Instantiate(powerToSpawn, transform.position, Quaternion.identity);
                    powerUp.transform.position = new Vector3(platform.transform.position.x - (bC.size.x / 2f), platform.transform.position.y + 1.9593f, transform.position.z);
                }
                chanceOfPowerUpRight = mininumPowerUpChance;
            } else if (gameReallyStarted == true) {
                chanceOfPowerUpRight++;
            }
        }
        lastPlatformSidedRight--;
        lastHeigthSpawned += 3f;

        //spawn torches with a 35% chance

        if (Random.Range(0.0f, 1.01f) <= 0.20f) {

            Instantiate(torch, new Vector3(Random.Range(-7.7f, -1.2f), lastHeigthSpawned + 3), Quaternion.identity);

        }

        if (Random.Range(0.0f, 1.01f) <= 0.20f) {

            Instantiate(torch, new Vector3(Random.Range(7.7f, 1.2f), lastHeigthSpawned + 3), Quaternion.identity);

        }

    }


    public void StartGame() {


        startX = transform.position.x;
        cameraSpeed = 0;
        chanceOfPowerUpLeft = mininumPowerUpChance;
        chanceOfPowerUpRight = mininumPowerUpChance;
        seriesSpawnedSinceLastSpeedGrowth = 0;
        seriesSpawnedSinceLastEvent = 0;
        Score.startHeight = GameObject.Find("Main Camera").transform.position.y;
        Score.ResetScore();
        gameStarted = true;

    }

    void GameStarted() {

        switch (GameObject.Find("GameSettings").GetComponent<MenuValueHolder>().difficulty) {
            case (1):
                cameraSpeed = 15 / 1000f;
                cameraSpeedGrowth = 5 / 1000f;
                break;

            case (2):
                cameraSpeed = 30 / 1000f;
                cameraSpeedGrowth = 5 / 1000f;
                break;

            case (3):
                cameraSpeed = 40 / 1000f;
                cameraSpeedGrowth = 10 / 1000f;
                break;
        }

        GameObject leftPlatform = null;
        GameObject rightPlatform = null;
        foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform")) {
            if (platform.transform.position.y < gameObject.transform.position.y + 4 && platform.transform.position.y > gameObject.transform.position.y - 4) {
                if (platform.transform.position.x < 0) {
                    leftPlatform = platform;
                } else {
                    rightPlatform = platform;
                }
            }
        }

        GetComponent<AudioSource>().clip = gameTheme;
        GetComponent<AudioSource>().Play();

        scoreCanvas.SetActive(true);

        GameObject player1 = Instantiate(playerOnePrefab, new Vector3(leftPlatform.transform.position.x + leftPlatform.GetComponent<BoxCollider2D>().size.x / 2f, leftPlatform.transform.position.y + leftPlatform.GetComponent<BoxCollider2D>().size.y / 2f, transform.position.z), Quaternion.identity);
        player1.name = ("Player1");
        GameObject player2 = Instantiate(playerTwoPrefab, new Vector3(rightPlatform.transform.position.x - rightPlatform.GetComponent<BoxCollider2D>().size.x / 2f, rightPlatform.transform.position.y + rightPlatform.GetComponent<BoxCollider2D>().size.y / 2f, transform.position.z), Quaternion.identity);
        player2.name = ("Player2");
        player2.GetComponent<DefaultMovement>().player = 2;
        gameStarted = false;
        gameReallyStarted = true;

        if (!GameObject.Find("GameSettings").GetComponent<MenuValueHolder>().isGhostPlatforms) {
            foreach (GameObject headCollision in GameObject.FindGameObjectsWithTag("HeadCollision")) {
                headCollision.SetActive(false);
            }
        }
    }

    public void EndGame(int winner) {

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(victorySound);
        cameraSpeed = 0;
        GameObject leftPlatform = GameObject.Find("LeftPlatform(Clone)");
        victoryPose = Instantiate(victorySprite,new Vector3(leftPlatform.transform.position.x + leftPlatform.GetComponent<BoxCollider2D>().size.x / 2f, leftPlatform.transform.position.y + leftPlatform.GetComponent<BoxCollider2D>().size.y / 2f, transform.position.z), Quaternion.identity);
        transform.position = victoryPose.transform.position;
        GetComponent<Camera>().orthographicSize = 1;

        if (winner != 1)
        {

            victoryPose.GetComponent<SpriteRenderer>().sprite = playerOnePrefab.GetComponent<SpriteRenderer>().sprite;

        } else
        {

            victoryPose.GetComponent<SpriteRenderer>().sprite = playerTwoPrefab.GetComponent<SpriteRenderer>().sprite;

        }


    }

    public void ReverseCamera() {
        GameObject text = Instantiate((GameObject)Resources.Load("UpsideDown"), transform.position, new Quaternion(0, 0, 3600, 0));
        text.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    }

    public void ResetGame()
    {
        if(victoryPose != null)
        {
            Destroy(victoryPose);
        }
        transform.position = new Vector3(0, transform.position.y);
        GetComponent<Camera>().orthographicSize = 5;
        cameraSpeed = 30f / 1000;
        chanceOfPowerUpLeft = -5;
        chanceOfPowerUpRight = -5;
        gameStarted = false;
        gameReallyStarted = false;
        GameObject.Find("Boundaries").GetComponent<checkDeath>().won = false;
        GameObject.Find("Boundaries").GetComponent<checkDeath>().activateTimer = false;
        GameObject.Find("WinnerLabel").GetComponent<UnityEngine.UI.Text>().enabled = false;

    }
   
}
