using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonConntroller : MonoBehaviour {

    public Director dr;
    //サイクル関係関数
    int cycle;
    float span;
    int cycleapsn;
    float delta;

    public void buttonstatus()
    {
        this.cycleapsn = dr.getcyclespan();
        this.span = dr.gettimespan();
        this.delta = dr.getCycleTime();
        this.cycle = dr.getcycle();
        //directorクラスからボタンが押された時点のデルタタイム、サイクル、サイクルスパン、タイムスパン
        //this.delta = dr.getCycleTime();
        //this.cicle = dr.getcycle();
        switch (transform.name)
        {
            case "bt5":
                dr.setAnstable(5);
                Debug.Log("cycle:" + this.cycle + "  select:" + 5 + "  time:" + this.delta.ToString("F3"));
                break;
            case "bt6":
                dr.setAnstable(6);
                Debug.Log("cycle:" + this.cycle + "  select:" + 6 + "  time:" + this.delta.ToString("F3"));
                break;
            case "bt7":
                dr.setAnstable(7);
                Debug.Log("cycle:" + this.cycle + "  select:" + 7 + "  time:" + this.delta.ToString("F3"));
                break;
            case "bt8":
                dr.setAnstable(8);
                Debug.Log("cycle:" + this.cycle + "  select:" + 8 + "  time:" + this.delta.ToString("F3"));
                break;
        }     
    }
}
