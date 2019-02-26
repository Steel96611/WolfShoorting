using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.transform.rotation = CameraScript.my_rotation; //カメラと同じ方向を向かせる

        Rigidbody rb = GetComponent<Rigidbody>(); //このオブジェクトのRigidbodyを取得＆代入

        rb.AddForce(transform.forward * 300, ForceMode.VelocityChange); //正面に向かって飛ばす

        Destroy(this.gameObject, 3); //3秒後にこのオブジェクトを削除する

    }
	
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Equals("Main Camera")) Destroy(this.gameObject); //カメラ以外のオブジェクトにぶつかったら削除する
    }
}
