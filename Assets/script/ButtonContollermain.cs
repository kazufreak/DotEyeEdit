using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContollermain : MonoBehaviour {

    public void buttonscene()
    {
        switch (transform.name)
        {
            case "TryBt":
                if(Maindirector.getSpan() <= 0f ||Maindirector.getCyclespan() <= 0)
                {
                    //defolt設定
                    Maindirector.setSpan(1.5f);
                    Maindirector.setCyclespan(5);
                    AdMob.bannerView.Hide();
                }
                SceneManager.LoadScene("countdwon");
                break;
            case "DataBt":
                SceneManager.LoadScene("histry");
                AdMob.bannerView.Show();
                break;
            case "OptionBt":
                SceneManager.LoadScene("optionscene");
                AdMob.bannerView.Show();
                break;
            case "exitBt":
                Application.Quit();
                AdMob.bannerView.Destroy();
                break;
        }
    }
}
