using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {

//	private Button button = null;
	private Manager manager;

	// 初期化
	void Start () {
//		button = GetComponent<Button>();
		manager = FindObjectOfType<Manager>();
	}

	// トグル変更
	public void  OnClick()	{
		// 全クリア
				manager.ClearAll();
	}
}
