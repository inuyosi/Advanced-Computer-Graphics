using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushikiText : MonoBehaviour {
    public Text textA;
    public Text textB;
    public Text textC;
    // 数式を格納する
    float value1;
    float value2;
    float add_count;
    public static int sum = 0;

	// Use this for initialization
	public void Start () {

    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Question(){
        value1 = Random.Range(1, 1000);
        value2 = Random.Range(1, 1000);
        add_count = Random.Range(0, 2);
        //Debug.Log(add_count);
        int ivalue1 = (int)value1;
        int ivalue2 = (int)value2;
        Debug.Log(ivalue1);
        Debug.Log(ivalue2);

        int tmp;
        if(add_count == 1){
            sum = ivalue1 + ivalue2;
            textA.text = "問題" + ivalue1.ToString() + "+" + ivalue2.ToString();
        }else{
            if (ivalue1 < ivalue2)
            {
                tmp = ivalue1;
                ivalue1 = ivalue2;
                ivalue2 = tmp;

            }
            sum = ivalue1 - ivalue2;
            textA.text = "問題" + ivalue1.ToString() + "-" + ivalue2.ToString();
        }	
        Debug.Log(sum);

    }

    public void Answer(){

        textB.text = "答え" + sum.ToString() ;

    }
}