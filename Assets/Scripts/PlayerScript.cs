using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private bool isGameStarted;
    private float increaseSize;
    [SerializeField]
    private int minutes;
    float currentTime;
    public Text currentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        increaseSize = 0.01f;
        currentTime = minutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            currentTime = currentTime - Time.deltaTime;
            Debug.Log(currentTime);
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
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
                transform.Rotate(Vector3.right);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(-Vector3.right);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-Vector3.up);
            }
        }
    }
}
