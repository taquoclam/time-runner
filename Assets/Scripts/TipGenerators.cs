using UnityEngine;
using UnityEngine.UI;

public class TipGenerators : MonoBehaviour {
    public string[] tips;
    private int numTips;
    private float elapsed;
	// Use this for initialization
	void Start () {
        numTips = tips.Length;
        changeTips();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            changeTips();
        }
    }
    public void changeTips()
    {
        int tipNum = Random.Range(1, numTips+1);
        gameObject.GetComponent<Text>().text = "Tip #" + tipNum + ": " + tips[tipNum-1];
    }
}
