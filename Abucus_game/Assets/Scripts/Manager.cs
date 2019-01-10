using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Manager : MonoBehaviour {
	public string Status = "";
	public string OnOff = "Off";
	public string ClickAbacus = "";
	public bool clear = true;
	public Text GUIText;
    public Text textA;
    public Text textB;
	public AudioClip sound01;
    public AudioClip sound02;
    AudioSource audioSource;

    // 数式を格納する
    float value1;
    float value2;
    float add_count;
    public static int Question_sum = 0;
	public static int result = 0;

	// 全クリア
	public void ClearAll() {
		GameObject[] abacus = GameObject.FindGameObjectsWithTag("Abacus");
		foreach(GameObject child in abacus) { 
			FindObjectOfType<AbacusBeads>().Clear(child);
		} 
	}

	// 計算処理
	public void Calc() {
		result = 0;
		int count = 0;
		int carry = 10;

		GameObject[] abacus = GameObject.FindGameObjectsWithTag("Abacus");
		foreach(GameObject child in abacus) {

			if (child.name == "AbacusBeads") count = 0;
			if (child.name == "AbacusBeads2") count = 1;
			if (child.name == "AbacusBeads3") count = 2;
			if (child.name == "AbacusBeads4") count = 3;
			if (child.name == "AbacusBeads5") count = 4;
			if (child.name == "AbacusBeads6") count = 5;
			if (child.name == "AbacusBeads7") count = 6;
			if (child.name == "AbacusBeads8") count = 7;
			if (child.name == "AbacusBeads9") count = 8;

			int sum = 0;
			int add = 1;
			Console.WriteLine(child.transform.childCount);
			for (int i=0; i<child.transform.childCount; i++) {
				if (!child.name.Contains("Bead")) continue;
				if(i>=4) add = 5;
				if (child.transform.GetChild(i).gameObject.tag == "On") {
					sum += add;
				}
			}

			result += sum * (int)System.Math.Pow((double)carry, (double)count);
			count++;
		}
			GUIText.text = result.ToString();
	}

    public void Question(){
        value1 = UnityEngine.Random.Range(1, 1000);
        value2 = UnityEngine.Random.Range(1, 1000);
        add_count = UnityEngine.Random.Range(0, 2);
        //Debug.Log(add_count);
        int ivalue1 = (int)value1;
        int ivalue2 = (int)value2;
        Debug.Log(ivalue1);
        Debug.Log(ivalue2);

        int tmp;
        if(add_count == 1){
            Question_sum = ivalue1 + ivalue2;
            textA.text = "問題" + ivalue1.ToString() + "+" + ivalue2.ToString();
        }else{
            if (ivalue1 < ivalue2)
            {
                tmp = ivalue1;
                ivalue1 = ivalue2;
                ivalue2 = tmp;

            }
            Question_sum = ivalue1 - ivalue2;
            textA.text = "問題" + ivalue1.ToString() + "-" + ivalue2.ToString();
        }	
        Debug.Log(Question_sum);

    }

    public void Answer(){
		audioSource = GetComponent<AudioSource>();
		if(Question_sum == result){
	        textB.text = "正解";
			audioSource.PlayOneShot(sound01,0.7F);
		} else {
	        textB.text = "正解は"+ Question_sum.ToString();
			audioSource.PlayOneShot(sound02,0.7F);
		}
    }

}
