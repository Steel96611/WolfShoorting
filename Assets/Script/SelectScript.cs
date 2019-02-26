using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScript : MonoBehaviour {

    public static int target = 10; //狼を生成する上限値
	
	// Update is called once per frame
	void Update () {

        GameObject tr = GameObject.Find("Target");

        UnityEngine.UI.Text textComponent = tr.GetComponent<UnityEngine.UI.Text>();

        textComponent.text = (int)target + "体";

    }

    public void up()
    {
        if (target < 100) target++;
    }

    public void down()
    {
        if (target > 5) target--;
    }

    public void go()
    {
        GameManegerScript.end_cnt = target; //設定した上限値を代入

        SceneManager.LoadScene("GameScene");
    }

}
