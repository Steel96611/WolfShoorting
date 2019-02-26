using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManegerScript : MonoBehaviour {

    public GameObject wolf; //狼のPrehabを入れる変数

    public GameObject[] Clear; //ゲームをクリアした際に表示するオブジェクトを入れる変数

    public static int Spown; //狼のPrehabを生成する回数

    public static int end_cnt = SelectScript.target; //生成する上限値

    Vector3 Spown_Point; //生成する座標

    int cnt; //生成した回数

    int rx;  //生成する座標のx座標

    int rz;  //生成する座標のz座標

    // Use this for initialization
    void Start () {

        //ここで狼を生成する関数を5回呼び出す
        for(cnt = 0; cnt != 5; cnt++) Wolf_Spown();

        cnt = 0;

        Spown = 0;

    }
	
	// Update is called once per frame
	void Update () {

        if (Spown != 0) //Spownの値分狼を生成する関数を呼び出す
        {
            cnt++;

            if (cnt <= end_cnt - 5) Wolf_Spown(); //cntの値が生成の上限値-5以下なら関数を呼び出す

            Spown--;
            
        }

        if (cnt == end_cnt)
        {
            Clear[0].transform.position = new Vector2(Camera.main.transform.position.x + 980, 600);

            Clear[1].transform.position = new Vector2(Camera.main.transform.position.x + 1500, 50);

            Debug.Log("Clear");

            end_cnt = 0;

        }

        GameObject Score = GameObject.Find("Score");

        UnityEngine.UI.Text textComponent = Score.GetComponent<UnityEngine.UI.Text>();

        textComponent.text = "Score : " + (int)cnt + "体";

    }

    public void Wolf_Spown() //狼を生成する関数
    {
        rx = Random.Range(-100, 100);

        rz = Random.Range(80, 200);

        Spown_Point = new Vector3(rx, 4, rz);

        GameObject Wolf = Instantiate(wolf, Spown_Point, Quaternion.identity);

        Wolf.name = "wolf";

    }

    public void End() //タイトルシーンに戻る関数
    {
        Clear[0].transform.position = new Vector2(Camera.main.transform.position.x, 1500);

        Clear[1].transform.position = new Vector2(Camera.main.transform.position.x + 500, 1500);

        SelectScript.target = 10;

        SceneManager.LoadScene("TitleScene");
    }

}
