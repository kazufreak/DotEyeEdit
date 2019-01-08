using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class graphscenechange : MonoBehaviour
{
    // Start is called before the first frame update
    public void scenecange()
    {
        AdMob.bannerView.Hide();
        SceneManager.LoadScene("mainscene");
    }
}
