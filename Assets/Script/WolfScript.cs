using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour {

    public bool go = true; //この値がtrueである限り進み続ける

    public bool Dead; //この値がfalseになるとこのオブジェクトは削除される

    Vector3 pos; //このオブジェクトの座標を代入する変数

    void Start(){

        Look();

        Dead = false;

    }

    // Update is called once per frame
    void Update() {

        Vector3 my_position = this.transform.position; //このオブジェクトの現在の座標を代入する

        my_position.y = 4; //高さを固定

        this.transform.position = my_position; //処理の内容を反映させる

        Rigidbody rb = GetComponent<Rigidbody>();

        Look();

        if (go) rb.AddForce(transform.forward * 10, ForceMode.VelocityChange); //正面に向かって真っすぐに進む

        if (Dead) //アニメーションが終わるタイミングでこの中の処理が行われる
        {
            GameManegerScript.Spown++;

            Destroy(this.gameObject);
        }

	}

    public void Look() //Cameraの方向へまっすぐ向く関数
    {
        Vector3 Look_position = Camera.main.transform.position - this.transform.position;

        this.transform.rotation = Quaternion.LookRotation(Look_position);
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.name.Equals("bullet")) { //弾が衝突したら死亡処理を行う

            go = false;

            this.GetComponent<Animator>().SetTrigger("Dead");

        }
       
      if(other.gameObject.name.Equals("Main Camera")) //Cameraに衝突したらCameraに向かって噛みつきに行くようにする
        {
            this.GetComponent<Animator>().SetTrigger("Hant");

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 20, ForceMode.VelocityChange);
        }

    }

}
