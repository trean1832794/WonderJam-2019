using UnityEngine;
using UnityEngine.UI;

public class MenuValueHolder : MonoBehaviour {
    public bool isGhostPlatforms;
    public int difficulty;
    public Toggle togg,hidd;
    public Button easy, med, hard;
    public float startHeight;
    public bool isHiddenPlatforms;

    // Start is called before the first frame update
    void Start() {
        difficulty = 1;
        isGhostPlatforms = true;
        Color cyan = new Color32(24, 95, 100, 255);
        togg.onValueChanged.AddListener(delegate {
            isGhostPlatforms = togg.isOn;
        });
        hidd.onValueChanged.AddListener(delegate {
            isHiddenPlatforms = hidd.isOn;
        });
        easy.onClick.AddListener(delegate {
            difficulty = 1;
            easy.GetComponent<Text>().color= new Color32(0, 200, 0, 255);
            med.GetComponent<Text>().color = cyan;
            hard.GetComponent<Text>().color = cyan;

        });
        med.onClick.AddListener(delegate {
            difficulty = 2;
            easy.GetComponent<Text>().color = cyan;
            med.GetComponent<Text>().color = new Color32(225, 125, 0, 255);
            hard.GetComponent<Text>().color = cyan;
        });
        hard.onClick.AddListener(delegate {
            difficulty = 3;
            easy.GetComponent<Text>().color = cyan;
            med.GetComponent<Text>().color = cyan;
            hard.GetComponent<Text>().color = new Color32(200, 0, 0, 255);
        });
    }

    public void setDifficulty(int diff) {
        this.difficulty = diff;
    }
}