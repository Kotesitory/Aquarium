using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        SetScore(0);
    }

    public void SetScore(int score) {
        scoreText.text = score.ToString("D4");
    }
}
