using Game.GameTimer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject timerObject;
    private TextMeshProUGUI text;

    public GameTimer gameTimer;
    // Start is called before the first frame update
    void Awake()
    {
        text = timerObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()   
    {
        text.text = gameTimer.TimeToRise.ToString();
    }
}
