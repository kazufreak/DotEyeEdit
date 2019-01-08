using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class axischarts : MonoBehaviour
{
    public GameObject emptyGraphPrefab;

    WMG_Axis_Graph graph;

    WMG_Series series1;
    WMG_Series series2;

    public Text counttex;
    public Text advscore;
    public Text maxscore;
    public Text advspeed;


    int listcount;//play回数
    string path = "/export.txt";
    string[] readtext;
    //グラフ用データ
    List<Vector2> scores = new List<Vector2>();
    List<string> xcount = new List<string>();
    List<Vector2> advsc = new List<Vector2>();

    private void Start()
    {
        GameObject graphGO = GameObject.Instantiate(emptyGraphPrefab);
        graphGO.transform.SetParent(this.transform, false);
        graph = graphGO.GetComponent<WMG_Axis_Graph>();
        
        series1 = graph.addSeries();
        series2 = graph.addSeries();
        

        //データ読込
        //readtext = readlineText(path);
        readtext = readline(path);
        //playcount書込み
        this.listcount = readtext.Length;
        this.counttex.GetComponent<Text>().text = this.listcount.ToString();
        //debug用
        float sumpoint = 0;//平均スコア合計
        float sumspeed = 0;//平均スピード合計
        string[] str;
        List<float> scoaremax = new List<float>();
        for (int i = 0; i < readtext.Length; i++)
        {

            str = readtext[i].Split(',');//
            scores.Add(new Vector2(i+1,float.Parse(str[3])));//score取り出しパース
            sumpoint += float.Parse(str[3]);
            scoaremax.Add(float.Parse(str[3]));
            sumspeed += float.Parse(str[2]);
            xcount.Add((i + 1).ToString());//プレイ回数格納
            //Debug.Log(readtext[i]);
            Debug.Log(xcount[i] + ":" + scores[i]);
            
        }
       

        //平均スコア書込み
        float adsore = sumpoint / this.listcount;
        this.advscore.GetComponent<Text>().text = adsore.ToString();
        //maxscore write
        this.maxscore.GetComponent<Text>().text = scoaremax.Max().ToString();
        for(int i = 0; i < readtext.Length; i++)
        {
            advsc.Add(new Vector2(i+1, adsore));
        }
       
        //平均speed書込み
        float adspeed = sumspeed / this.listcount;
        this.advspeed.GetComponent<Text>().text = adspeed.ToString();
        //graph limit
        double ylimit= Math.Ceiling(scoaremax.Max() / 1000) * 1000;
        graph.xAxis.AxisMaxValue = this.listcount + 1;
        graph.yAxis.AxisMaxValue = (float)ylimit;
        //grph
        graph.groups.SetList(xcount);
        graph.useGroups = true;

        graph.xAxis.LabelType = WMG_Axis.labelTypes.groups;
        graph.xAxis.AxisNumTicks = xcount.Count;

        series1.seriesName = "PlayHistry";
        series2.seriesName = "ScoreAdv";
        //series2.pointPrefab = graphGO.GetComponentsInChildren<WMG_Series>().;
        series1.pointWidthHeight = 50;
        series2.pointWidthHeight = 30;
        series1.pointColor = new Color(0, 1, 0, 1);
        series2.pointColor = new Color(1, 1, 1, 1);
        series1.lineScale = 5;
        series2.lineScale = 3;
        series1.lineColor = new Color(1,1,1,1);
        series2.lineColor = new Color(0.2f, 1, 1, 1);
        
        //series1.yAxis.AxisTitleString = "SCORE";


        series1.UseXDistBetweenToSpace = true;
        series2.UseXDistBetweenToSpace = true;

        series1.pointValues.SetList(scores);
        series2.pointValues.SetList(advsc);

    }

    public string[] readline(string path)
    {
        string str = "";
        string[] strdata = null;
        List<string> stlist = new List<string>();
        string[] strstream = null;

        try
        {
            using (StreamReader sr = new StreamReader(Application.persistentDataPath + path))
            {
                str = sr.ReadToEnd();
                sr.Close();
                strdata = str.Split(new string[] { "\n" }, StringSplitOptions.None);

                for (int i=0; i<strdata.Length;i++)
                {
                    stlist.Add(strdata[i]);
                }
                stlist.Remove("");//空削除
                strstream = stlist.ToArray();//listを配列
 
            }
        }catch(Exception e)
        {
            Debug.Log(e.Message);
        }
        return strstream;
    }
}
