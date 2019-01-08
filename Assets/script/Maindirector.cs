using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Maindirector : MonoBehaviour {
    
    public static float span;
    public static int cyclespan;

    private void Start()
    {
        AdMob.bannerView.Hide();
    }

    public static float getSpan()
    {
        return span;
    }
    public static int getCyclespan()
    {
        return cyclespan;
    }
    public static void setSpan(float a)
    {
        span = a;
    }
    public static void setCyclespan(int a)
    {
        cyclespan = a;
    }


}
