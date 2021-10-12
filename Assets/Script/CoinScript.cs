using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class CoinScript : MonoBehaviour
{
    public int coinCounter = 0;
    public Text coinText;

    public float totalcoins;
    public float timeleft;
    public int timeRemaining;

    public Text TimerText;

    private float TimerValue;

    public ParticleSystem CoinPop;


    // Start is called before the first frame update
    void Start()
    {
        CoinPop.Stop();

        coinCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timeleft -= Time.deltaTime;

        timeRemaining = Mathf.FloorToInt(timeleft % 60);

        TimerText.text = "Timer: " + timeRemaining.ToString();

        if(coinCounter == totalcoins)
        {
            if(timeleft <= TimerValue)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        else if(timeleft <= 0)
        {
            SceneManager.LoadScene("GameLose");

        }

        GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;


        coinText.text = "Coin: " + coinCounter; 
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Coin"))
        {
            coinCounter += 10;

            CoinPop.Play();

            Destroy(other.gameObject);
        }

        if(other.gameObject.tag.Equals("water"))
        {
            SceneManager.LoadScene("GameLose");

            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;

        }
    }


}
