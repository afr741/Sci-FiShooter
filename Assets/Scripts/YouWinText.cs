using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class YouWinText : MonoBehaviour
{

    Text winText;

    void Start()
    {
        //get the Text component
        winText = GetComponent<Text>();
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());
    }

    //function to blink the text
    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            //set the Text's text to blank
            winText.text = "";
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            //display “I AM FLASHING TEXT” for the next 0.5 seconds
            winText.text = "YOU WIN!";
            yield return new WaitForSeconds(.5f);
        }

    }

}
