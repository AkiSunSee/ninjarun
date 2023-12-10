
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NinjaWall : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;
    private Vector3 startingPosition;
    public int countdowntime = 3;
    public bool countdownDone = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition= transform.position;
        StartCoroutine(CountdownToStart());
        Debug.Log(startingPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(countdownDone){
        Vector3 v = startingPosition;

        v.y += distanceToCover * Mathf.Sin(Time.time*speed);
        transform.position= v;
        }
    }

    IEnumerator CountdownToStart()
    {
        while (countdowntime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdowntime--;
        }
        countdownDone = true;
        yield return new WaitForSeconds(1f);
    }
}
