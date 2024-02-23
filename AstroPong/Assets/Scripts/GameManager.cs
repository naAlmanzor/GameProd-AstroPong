using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    public TMP_Text scoreText;
    public static int score = 0;
    
    [SerializeField]
    public static int playerHealth = 3;
    public Image[] playerLives;
    public Sprite fullLives;
    public Sprite emptyLives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(score.ToString());
        PlayerHealth();
    }

    private void PlayerHealth()
    {
        foreach (Image img in playerLives)
        {
            img.sprite = emptyLives;
        }

        for(int i=0; i < playerHealth; i++)
        {
            playerLives[i].sprite = fullLives;
        }
    }
}
