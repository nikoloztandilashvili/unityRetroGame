using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();
    Camera cam;

    public void Start()
    {
       cam = FindObjectOfType<Camera>();
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(position.x + 1050, position.y+400, 0));
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
        
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.go.transform.localScale = new Vector3(1, 1, 1);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }
}
