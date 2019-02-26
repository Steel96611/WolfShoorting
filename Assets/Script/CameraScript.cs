using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Bullet; //発射する弾を代入する変数

    public GameObject[] End; //ゲーム終了時に表示するUI

    public static Quaternion my_rotation; //このオブジェクトの向いている方向

    public Vector3 Look_position; //ゲームオーバー時にこのオブジェクトに触れたエネミーのいる方向

    public static bool dead; //ゲームオーバーしたかどうかの判定を行う為の値

    bool Left; //左に向こうとしているか
    bool Right;//右に向こうとしているか

    float speed; //操作で別の方向を向こうとする時の値

    void Start()
    {
        //ここで各値を初期化する

        speed = 0.01f;

        Left = true;
        Right = true;

        dead = false;
    }

    void Update()
    {
        my_rotation = this.transform.rotation; //自分の向いている方向を代入

        if (this.transform.rotation.y > -60 && Input.GetKey(KeyCode.LeftArrow)) //左を向く処理
        {
            this.transform.Rotate(new Vector3(0, 1, 0), speed * (-1));
            speed += 0.005f;

            Left = false;
        }
        else
        {
            Left = true;
        }

        if (this.transform.rotation.y < 60 && Input.GetKey(KeyCode.RightArrow)) //右を向く処理
        {
            this.transform.Rotate(new Vector3(0, 1, 0), speed);
            speed += 0.005f;

            Right = false;
        }
        else
        {
            Right = true;
        }

        if (speed == 0.8f) //振り向く速度を一定の値で止める
        {
            speed = 0.795f;
        }

        if (Left && Right) //どちらも向こうとしていない時、振り向く速度を初速に戻す
        {
            speed = 0.01f;
        }

    }

    public void Fire() //弾を生成する処理を行う関数
    {
        if (!dead)
        {

            GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);

            bullet.name = "bullet";

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "wolf") //狼と衝突判定があったらゲームオーバーなので、その処理を行う
        {
            Look_position = other.transform.position - this.transform.position;

            Look_position.y = 0;

            this.transform.rotation = Quaternion.LookRotation(Look_position);

            End[0].transform.position = new Vector2(this.transform.position.x + 980, 600);

            End[1].transform.position = new Vector2(this.transform.position.x + 1500, 50);

            dead = true;

            Destroy(other.gameObject, 3);
        }

    }

}
