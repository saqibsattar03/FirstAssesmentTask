using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private bool isGameStarted;
    private float increaseSize;
    public GameObject startButton;
    public GameObject restartButton;
    [SerializeField]
    private int minutes;
    float currentTime;
    public Text currentTimeText;
    [SerializeField]
    private Text gameOverMessage;
    private TimeSpan time;
    public List<Color> TintColors;
    // Start is called before the first frame update
    void Start()
    {

        increaseSize = 0.01f;
        currentTime = minutes * 60;
        Debug.Log(currentTime);
        Color color = TintColors[UnityEngine.Random.Range(0, TintColors.Count)];
        GetComponent<Renderer>().material.color = color;
        restartButton.SetActive(false);

    }

	// Update is called once per frame
	void Update()
    {
       

        if (isGameStarted)
        {
            timer();

            // scalling is hapenning here //

            if (Input.GetKey(KeyCode.Space))
            {
                transform.localScale += new Vector3(1f, 1f, 1f) * increaseSize;
            }
            else
            if (transform.localScale.x > 1 && transform.localScale.y > 1 && transform.localScale.z > 1)
            {
                transform.localScale -= new Vector3(1f, 1f, 1f) * increaseSize;
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            
            // end of scaling code //

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rotateUpward();   
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rotateDownward();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rotateRightward();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotateLeftward();
            }
        }
    }
	void timer()
    {
        if (currentTime == 0 || currentTime < 0)
        {
            Debug.Log("here");
            isGameStarted = false;
            currentTimeText.text = 00.ToString() + ":" + 00.ToString();
            gameOver();
        }
        else
        {
            isGameStarted = true;
            currentTime = currentTime - Time.deltaTime;
            time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }

    }

    public void playButton() 
    {
        isGameStarted = true;
        if (isGameStarted == true) 
        {
            startButton.SetActive(false);
        }
    }


    void rotateUpward() 
    {
        transform.Rotate(Vector3.right);
    }
    void rotateDownward()
    {
        transform.Rotate(-Vector3.right);
    }
    void rotateRightward()
    {
        transform.Rotate(Vector3.up);
    }

    void rotateLeftward() 
    {
        transform.Rotate(-Vector3.up);
    }

    void gameOver()
    {
        gameOverMessage.text = "Game Over";
        //startButton.GetComponentInChildren<Text>().text = "Restart";
        restartButton.SetActive(true);
    }

    public void restartGame() 
    {
        Debug.Log("here in restart gaeme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // playButton();
    }
}
