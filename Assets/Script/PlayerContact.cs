using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerContact : MonoBehaviour
{
	public GameObject player;
	private int count;
	public TextMeshProUGUI countText;
    public GameObject winTextObject;
	public GameObject PointTextObject;
    public GameObject loseTextObject;
	public TextMeshProUGUI PointText;
	public GameObject[] hearts;
	public float delayDamage = 5f;
	private int life;
	private bool dead;
	public string PickUpTag ;
	private bool CanTakeDamage = true;
	private float countdown;
	private int lastpoint = 0;

	public GameObject ButtonRestart;
	public GameObject ButtonQuit;
	void Start()
    {
        count = 0;
        SetCountText();
		PointTextObject.SetActive(false);
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
		ButtonRestart.SetActive(false);
		ButtonQuit.SetActive(false);
		life = hearts.Length;
		Debug.Log(life);
	}
    private void Update()
    {
       //cheack dead
	   if(dead == true)
        {
			PointTextObject.SetActive(true);
			setLastPoint();
			loseTextObject.SetActive(true);
			ButtonRestart.SetActive(true);
			ButtonQuit.SetActive(true);
		}
    }

	//OnTriggerEnter
    void OnTriggerEnter(Collider other)
	{
		//PickUp
		if (other.gameObject.CompareTag(PickUpTag))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}

	}
    
    //OnCollisionEnter
    private void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.CompareTag("Trap"))
		{
			if(CanTakeDamage){
			Debug.Log("Traped");
			CanTakeDamage = false;
			SetHeart(1);
			}
		}
		if (other.gameObject.CompareTag("Finish"))
		{
			winTextObject.SetActive(true);
			PointTextObject.SetActive(true);
			setLastPoint();
			ButtonRestart.SetActive(true);
			ButtonQuit.SetActive(true);
		}
	}

	public void SetHeart(int d)
    {
		
        life -= d;
		Debug.Log(life);
		Destroy(hearts[life].gameObject);
		StartCoroutine(CountdownTakeDamage());
		if(life < 1)
        {
			Debug.Log("EnterDead");
			dead = true;
        }
    }
    void SetCountText()
	{
		countText.text = "Point: " + count.ToString();

	}
	void setLastPoint()
	{
		lastpoint = count + life*5;
		PointText.text = "Point: " + lastpoint.ToString();
	}
	 
	IEnumerator CountdownTakeDamage()
    {
		countdown = delayDamage;
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1f);
            countdown--;
			Debug.Log(countdown);
        } 
        CanTakeDamage = true;
        yield return new WaitForSeconds(1f);
    }	
	
}
