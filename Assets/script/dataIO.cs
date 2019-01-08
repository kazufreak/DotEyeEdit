using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class dataIO : MonoBehaviour
{

    float per;//xcount / Ansl.Count 正解率
    float timeadv;//回答スピード平均（対象は正解問）
    int score;//評価ポイント

    DateTime day;
    Dictionary<string, float> result = new Dictionary<string, float>();

    GameObject director;
    redirector rd;
    string writeText;

    

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("Director");
        this.rd = director.GetComponent<redirector>();

        this.day = rd.getDay();
        this.result = rd.getResult();//per,timeadv,score
        Debug.Log(this.result.Count);
        foreach (KeyValuePair<string, float> item in this.result)
        {
            Debug.Log(item.Key + ":"+ item.Value);
        }

        this.per = this.result["per"];
        this.timeadv = this.result["timeadv"];
        this.score = (int)this.result["score"];

        writeText = this.day.ToString()+","+ this.per.ToString()+","
            +this.timeadv.ToString()+","+ this.score.ToString()+ "\n";
        //書込みテスト
        string path = "/export.txt";
        saveText(path, writeText);
    }

    public bool saveText(string path, string text)
    {
        //ストリームライターwriterに書き込む
        try
        {
            using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + path, true))
            {
                Debug.Log(Application.persistentDataPath + path);
                writer.Write(text);
                writer.Flush();
                writer.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return false;
        }
        return true;
    }

}
