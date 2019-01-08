
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class dotgenarator : MonoBehaviour {

    public GameObject dot;
    List<float> xlist = new List<float>{ 3, 3, 3, 0, 0, 0, -3, -3, -3 };
    List<float> ylist = new List<float> { 3, 0, -3, 3, 0, -3, 3, 0, -3 };
    List<int> index = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

    List<GameObject> prefab = new List<GameObject>();

    List<float> x = new List<float>();
    List<float> y = new List<float>();

    List<int> resultsindex = new List<int>();
  

    int maxvalue = 0;//ドット生成数

    int cycle = 0;

    float span = Maindirector.getSpan();
    int cycleapsn = Maindirector.getCyclespan();
    float delta = 0;

    

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if(this.cycle < this.cycleapsn)
        {
            if (this.delta > span)
            {
                //1後オブジェクト削除
                for (int i = 0; i < prefab.Count; i++)
                {
                    Destroy(prefab[i]);
                }

                this.prefab.Clear();
                
                this.cycle += 1;
                this.delta = 0;
                this.maxvalue = 0;

                this.resultsindex.Clear();
                this.x.Clear();
                this.y.Clear();

                genarator();//ドットを生成
                Director.point.Add(this.cycle, this.maxvalue);//正解数を格納
                Debug.Log("no."+this.cycle+ ":"+ this.maxvalue);
            }

        }else if(this.delta > span)
        {
            //1後オブジェクト削除
            for (int i = 0; i < prefab.Count; i++)
            {
                Destroy(prefab[i]);
            }
        }
        


    }
    void genarator()
    {
        //ドットオブジェクト生成
        dotposition();
        //生成時に効果音
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < x.Count; i++)
        {
            //GameObject item = Instantiate(dot) as GameObject;
            prefab.Add(Instantiate(dot) as GameObject);
            prefab[i].transform.position = new Vector3(x[i], y[i], 0);
        }

    }

    void dotposition()
        //ドット座標をランダム作成する。
        {
        maxvalue = Random.Range(5, 9);//dot作成数5～8のランダム値
        resultsindex = selectRandomValue(index, maxvalue);
        

        //Debug.Log(resultsindex);
        foreach (int i in resultsindex)
        {
            //Debug.Log(i);
            x.Add(xlist[i]);
            y.Add(ylist[i]);
        }

    }

    // 引数pCountの数だけ、リストからランダムに取得する
    public static List<T> selectRandomValue<T>(List<T> pList, int pCount = 0)
    {
        // 処理用のリストを作成
        List<T> tmpList = new List<T>();
        for (int i = 0; i < pList.Count; i++)
        {
            tmpList.Add(pList[i]);
        }

        // リストの数以上の回数ランダムに取得しないようにする
        if (pCount > pList.Count)
        {
            pCount = pList.Count;
        }

        // 結果を入れるリストを作成
        List<T> results = new List<T>();

        int count = pCount;

        // pCountの回数分ループ
        for (int j = 0; j < count; j++)
        {
            // 0〜pListリストの要素数の間でランダムに取得
            T result = tmpList[Random.Range(0, tmpList.Count)];

            // 取得した値をpListリストから削除
            tmpList.Remove(result);

            // 取得した値をresultsリストに追加
            results.Add(result);

        }
        return results;
    }
}
