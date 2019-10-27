using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public int timeLeft = 60;
    public Text countdown;
    public Text OutOfTimeText;
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
        OutOfTimeText.text = "" ;
    }


    void Update()
    {
        countdown.text = (" Time Left:    " + timeLeft);

        if (timeLeft == 0)
        {
            OutOfTimeText.text = "Oh no! You ran out of time!!";
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

    }
    void SetOutOfTime()
    {

        OutOfTimeText.text = "Oh no! You ran out of time!!";

    }

}
