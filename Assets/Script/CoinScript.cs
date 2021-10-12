using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinScript : MonoBehaviour
{
    public int coinCounter = 0;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coin: " + coinCounter; 
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Coin"))
        {
            coinCounter += 10;

            Destroy(other.gameObject);
        }

        if(other.gameObject.tag.Equals("water"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }


}
