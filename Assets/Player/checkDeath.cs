using UnityEngine;

public class checkDeath : MonoBehaviour {
    float endScreenTimer = 0;
    public bool activateTimer = false;
    public bool won = false;
    public GameObject winnerText;

    public AudioClip deathSound;

    private void Update() {
        if (activateTimer) {
            endScreenTimer += Time.deltaTime;
            if (endScreenTimer >= 2) {
                GetComponent<SceneChange>().gotoDeathScreen();
                activateTimer = false;
            }
        }
    }

    private void Awake() {
        winnerText = GameObject.Find("WinnerLabel");
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            int winnerNbr = ((collision.GetComponent<DefaultMovement>().player % 2) + 1);



            if (GameObject.Find("Player" + winnerNbr) != null) {
                Debug.Log(GameObject.Find("Player" + winnerNbr).name + " as gagne!");
                winnerText.GetComponent<UnityEngine.UI.Text>().text = ("PLAYER " + winnerNbr + " WON!");
            } else {

                //victory
                if (!won) {
                    GameObject.Find("Main Camera").GetComponent<CameraScript>().EndGame(winnerNbr);
                    won = true;

                }

            }
            if (winnerNbr == 1) {
                Debug.Log("Le joueur (2) a été éliminé avec " + Score.player2Score + " de score.");
            } else {
                Debug.Log("Le joueur (1) a été éliminé avec " + Score.player1Score + " de score.");
            }
            Destroy(collision.gameObject);
            activateTimer = true;

            GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(deathSound);

        }
    }
}
