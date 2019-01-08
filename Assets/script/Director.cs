using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour {

    //GameObject dltime = GameObject.Find("deltatime");

    //public Maindirector mdr;
    public dotgenarator dotgenarator;

    public Text cyclet;
    public Text dltime;
    public Text endText;
    public GameObject gage;
    public GameObject audio;


    int cycle;
    float span;
    int cyclespsn;
    float delta;
    float gagetimer;


    //回答変数結果の格納
    //key1:サイクル番号
    //key2:回答番号
    //value:回答時のdeltatime
    //Dictionary<int, Dictionary<int, float>> AnsTable = new Dictionary<int, Dictionary<int, float>>();
    public static List<int> key = new List<int>();
    public static Dictionary<int, int> Anser = new Dictionary<int, int>();//回答
    public static Dictionary<int, float> Anstime = new Dictionary<int, float>();//回答タイム

    //答え
    public static Dictionary<int, int> point = new Dictionary<int, int>();

    void Start()
    {
        this.cycle = 0;
        this.span = Maindirector.getSpan();
        this.cyclespsn = Maindirector.getCyclespan();
        this.delta = 0;

       


        Anser.Clear();
        Anstime.Clear();
        point.Clear();
        key.Clear();
    }
    



    // Update is called once per frame
    void Update()
    {    
        this.delta += Time.deltaTime;
        

        if (this.cycle < this.cyclespsn)
        {
            //time更新
            this.dltime.GetComponent<Text>().text = "Time:" + this.delta.ToString("F3");
            //timeゲージ
            this.gagetimer = ((float)this.delta / this.span);
            this.gage.GetComponent<Image>().fillAmount = this.gagetimer;

            if (this.delta > this.span)
            {
                this.cycle += 1;
                this.delta = 0;
                this.gagetimer = 0;
                //サイクル更新
                if (this.cycle > 0)
                {
                    
                    this.cyclet.GetComponent<Text>().text = "cycle:" + this.cycle.ToString() + "/" + this.cyclespsn.ToString();
                    
                }
                
               
            }
        }
        else
        {
            //サイクル後にリセッ
            this.dltime.GetComponent<Text>().text = "Time:" + "0.000";        
            Invoke("endview", 1f);//チカチカする         
            Invoke("chengescene", 2f);   

        }
        
    }
    void endview() { this.endText.GetComponent<Text>().text = "END"; }
    void chengescene(){ SceneManager.LoadScene("resultscene");}

    public float getCycleTime()
    {
        return this.delta;
    }
    public float gettimespan()
    {
        return this.span;
    }
    public int getcycle()
    {
        return this.cycle;
    }
    public int getcyclespan()
    {
        return this.cyclespsn;
    }

    public void setAnstable(int ans)
    {   //回答リスト
        Anser[this.cycle] = ans;
        Anstime[this.cycle] = this.delta;
        key.Add(this.cycle);
               
    }

}
