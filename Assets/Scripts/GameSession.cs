using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    // config params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 5;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;


    // state variables
    [SerializeField] int gameScore = 0;


    // cached references
    //Block block;



    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);  // bcos singleton can cause bag when in 1 cicle there will be 2 of them
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //block = FindObjectOfType<Block>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }


    public void AddToScore()
    {
        gameScore += pointsPerBlockDestroyed;
        scoreText.text = gameScore.ToString();
    }


    public void DestroyItSelf()
    {
        Destroy(gameObject);
    }


    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
