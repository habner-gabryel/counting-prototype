using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    private GameManager gameManager;
    private int Count = 0;

    private void Start()
    {
        Count = 0;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal")){
            Count += 1;
            CounterText.text = "Count : " + Count;

            if(Count % 10 == 0){
                foreach(GameObject target in gameManager.targets){
                    target.GetComponent<Target>().IncreaseSpeed(4F);
                }
            }
            Destroy(other);
        } else {
            Destroy(other);
            gameManager.GameOver();
        }
    }
}
