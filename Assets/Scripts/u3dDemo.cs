using UnityEngine;
using System.Collections;

public class u3dDemo : MonoBehaviour {
    public UIInput input;
    public UIButton btnAdd;
    public GameObject label;
    private UIButton btnClear;
    public UIWidget containter;
	// Use this for initialization
	void Start () {
        btnClear = GameObject.Find("BtnClear").GetComponent<UIButton>();
        EventDelegate.Add(btnAdd.onClick,OnBtnAddClick);
        EventDelegate.Add(btnClear.onClick, OnBtnClearClick);
	}
	
    void OnBtnAddClick() {

        var templbl = Instantiate(label).GetComponent<UILabel>();
         int result;
        if (int.TryParse(input.label.text,out result)) {
            templbl.text = "Num:" + input.label.text + ";" + ((int)Time.time).ToString() + ";Sqrt:" + Mathf.Sqrt(result);
        } else {
            templbl.text = "You did it wrong ,dude";
        }

        templbl.transform.SetParent(containter.transform);
        var randomPostion = new Vector3(Random.Range(0, containter.width), Random.Range(-containter.height, 0), 0);
        templbl.transform.localPosition =  new Vector3(-1000,-1000,0);
        TweenPosition.Begin(templbl.gameObject, 0.3f, randomPostion);
        templbl.transform.localScale = Vector3.one;
    }
    void OnBtnClearClick() {
        input.label.text = "";
    }
}
