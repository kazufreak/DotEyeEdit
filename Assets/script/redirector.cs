using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class redirector : MonoBehaviour {
    string menuscene = "mainscene";
    string playscene = "countdwon";


    public Text percent;//正解率
    public Text Speed;//回答スピード
    public Text assess;//評価
    

    List<int> keyl = new List<int>();//回答サイクル番号
    Dictionary<int, int> Anserl = new Dictionary<int, int>();//回答
    Dictionary<int, float> Anstimel = new Dictionary<int, float>();//回答タイム
    Dictionary<int, int> Ansl = new Dictionary<int, int>();//答え

    //結果
    int xcount;//正解数
    float y;//正解回答スピードの和
    float per;//xcount / Ansl.Count 正解率
    float timeadv;//回答スピード平均（対象は正解問）
    float ases;//point前処理
    int asespoint;//評価ポイント
    //書出し用
    DateTime day;
    Dictionary<string, float> result = new Dictionary<string, float>();

    IEnumerable<int> afterkey;

    void Start()
    {
        this.Anserl = Director.Anser;
        this.Anstimel = Director.Anstime;
        this.Ansl = Director.point;
        this.keyl = Director.key;
        this.result.Clear();
        //広告表示
        AdMob.bannerView.Show();

        //重複削除
        this.afterkey = this.keyl.Distinct();
        //設定時間外を削除


        Debug.Log("回答数:" + this.Anserl.Count);
        Debug.Log("タイム:" + this.Anstimel.Count);
        Debug.Log("問題数" + this.Ansl.Count);

        xcount = 0;
        y = 0f;

        float sp = Maindirector.getSpan();
        foreach (int i in this.afterkey){
            if (this.Anserl[i] == this.Ansl[i])
            {
                if(sp >= this.Anstimel[i])
                {
                    xcount += 1;
                    y += this.Anstimel[i];
                }
            }
        }
        try
        {
            if(xcount == 0 || y == 0)
            {
                percent.GetComponent<Text>().text = xcount + " / " + this.Ansl.Count;
                Speed.GetComponent<Text>().text = "False";
                assess.GetComponent<Text>().text = "False";
                //書出し用へ格納
                this.day = DateTime.Now;
                this.result["per"] = 0;
                this.result["timeadv"] = 0;
                this.result["score"] = 0;
                
            }
            else
            {
                per = ((float)xcount / this.Ansl.Count);
                Debug.Log("%:"+per+" xcount:" + xcount + " 回答数:" + this.Ansl.Count);
                timeadv = y / xcount;
                ases = 0;
                asespoint = 0;
                //y0.2以下なら100　y0.7以下50 y1.0以上10
                //× per
                if (timeadv <= 0.2)
                {
                    ases = (100 * per) / timeadv;   
                }
                else if (timeadv > 0.2 && timeadv <= 1.0)
                {
                    ases = (50 * per) / timeadv;          
                }
                else if (timeadv > 1.0 && timeadv <= 1.5)
                {
                    ases = (30 * per) / timeadv;
                }else if(timeadv > 1.5)
                {
                    ases = (10 * per) / timeadv;
                }
                asespoint = (int)(ases * 100);

                percent.GetComponent<Text>().text = xcount + " / " + this.Ansl.Count;
                Speed.GetComponent<Text>().text = timeadv.ToString("F3");
                assess.GetComponent<Text>().text = asespoint.ToString("F0");
                //書出し用へ格納
                this.day = DateTime.Now;
                this.result["per"] = this.per;
                this.result["timeadv"] = this.timeadv;
                this.result["score"] = (float)this.asespoint;
                
            }
            

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }


        for(int i = 1; i < this.Ansl.Count+1; i++)
        {
            
            Debug.Log("Anser_cycle:" + i +"/" +this.Ansl.Count+ " 答え:"+this.Ansl[i]);
        }

    }
 
      
    
    // Update is called once per frame
    public void sceneload() {
        switch (transform.name)
        {
            case "menuButton":
                AdMob.bannerView.Hide();
                SceneManager.LoadScene(menuscene);
                break;
            case "retryButton":
                AdMob.bannerView.Hide();
                SceneManager.LoadScene(playscene);
                break;
        }		
	}
    public Dictionary<string, float> getResult()
    {
        return this.result;
    }
    public DateTime getDay()
    {
        return this.day;
    }
}
