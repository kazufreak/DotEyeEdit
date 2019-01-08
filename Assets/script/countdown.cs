using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
    
{

    public Text text;
    [SerializeField]
    int span = 4;
    float countspeed = 0.7f;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    AudioSource ausouce;

    float delta;
    int cycle;
    string[] tex = {"3","2","1", "START"}; 

    private void Start()
    {
        this.delta = 0;
        this.cycle = 0;
        ausouce = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.cycle < this.span && this.span - this.cycle > 0)
        {
            if (this.delta > this.countspeed )
            {
                this.cycle += 1;
                this.delta = 0;
                //textchenge(span - this.cycle);
                textchenge(tex[this.cycle - 1]);
                ausouce.clip = audioClip1;
                ausouce.Play();
            }

        }
        else
        {
            readyview();
            Invoke("chengescene", 0.5f);

        }
    }
    void readyview()
    {
        
        this.text.GetComponent<Text>().fontSize = 170;
        this.text.GetComponent<Text>().color = new Color(0.2f,0.38f,0.99f,1);
        

    }

    void chengescene() { SceneManager.LoadScene("playscene"); }
    void textchenge(int a) { this.text.GetComponent<Text>().text = a.ToString(); }
    void textchenge(string a) { this.text.GetComponent<Text>().text = a; }

}
