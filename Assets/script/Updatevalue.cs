using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Updatevalue : MonoBehaviour {
    public Dropdown cycletimedd;
    public Dropdown cyclecountdd;

    string cycletimetext;
    string cyclecounttext;

    float speed;
    int cyclespan;

    string menuscene = "mainscene";

    private void Start()
    {
        this.speed = Maindirector.getSpan();
        this.cyclespan = Maindirector.getCyclespan();
        int value = 0;
        if(this.speed == 2.0)
        {
            value = 0;
        }
        else if(this.speed == 1.5)
        {
            value = 1;
        }
        else if (this.speed == 1.0)
        {
            value = 2;
        }
        else if (this.speed == 0.5)
        {
            value = 3;
        }
        else
        {
            value = 2;
        }

        int value2 = 0;
        if(this.cyclespan == 5)
        {
            value2 = 0;
        }
        else if(this.cyclespan == 10)
        {
            value2 = 1;
        }
        else if (this.cyclespan == 20)
        {
            value2 = 2;
        }
        else if (this.cyclespan == 30)
        {
            value2 = 3;
        }
        else
        {
            value2 = 0;
        }

        cycletimedd.GetComponentInChildren<Dropdown>().value = value;
        cyclecountdd.GetComponentInChildren<Dropdown>().value = value2;


    }

    public void updatedate()
    {
        //選択した値の読込
        cycletimetext = cycletimedd.GetComponentInChildren<Text>().text;
        cyclecounttext = cyclecountdd.GetComponentInChildren<Text>().text;

        if(cycletimetext == "EASY(1.5)")
        {
            Maindirector.setSpan(1.5f);

        }else if(cycletimetext == "NORMAL(1.0)")
        {
            Maindirector.setSpan(1.0f);
        }else if(cycletimetext == "HARD(0.5)")
        {
            Maindirector.setSpan(0.5f);
        }else if(cycletimetext == "HARD(0.5)")
        {
            Maindirector.setSpan(0.5f);
        }
        else if (cycletimetext == "VERYEASY(2.0)")
        {
            Maindirector.setSpan(2.0f);
        }

        if (cyclecounttext == "5 Count")
        {
            Maindirector.setCyclespan(5);
        }
        else if (cyclecounttext == "10 Count")
        {
            Maindirector.setCyclespan(10);
        }
        else if (cyclecounttext == "20 Count")
        {
            Maindirector.setCyclespan(20);
        }
        else if (cyclecounttext == "30 Count")
        {
            Maindirector.setCyclespan(30);
        }

        Debug.Log(cycletimetext);
        Debug.Log(cyclecounttext);
        AdMob.bannerView.Hide();
        SceneManager.LoadScene(menuscene);





    }
	
	
}
