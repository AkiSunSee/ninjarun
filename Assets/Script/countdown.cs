using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countdown : MonoBehaviour
{
    public int countdowntime = 3;
    public TextMeshProUGUI countdowndisplay;
    public bool countdownDone = false;
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart()
    {
        countdowndisplay = GetComponent<TextMeshProUGUI>();
        while (countdowntime > 0)
        {
            countdowndisplay.text = countdowntime.ToString();
            yield return new WaitForSeconds(1f);
            countdowntime--;
        }
        countdowndisplay.text = "GO!";
        countdownDone = true;
        yield return new WaitForSeconds(1f);
        countdowndisplay.gameObject.SetActive(false);
        
    }
}
