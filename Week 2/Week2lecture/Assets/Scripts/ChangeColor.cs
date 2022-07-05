using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
	public float fadeSpeed = 1;

	Material skin;
	Color newColor;
	bool change;

    void Start()
    {
		skin=GetComponent<Renderer>().material;
    }

	public void SetColor(Color nextColor) {
		newColor = new Color(
			Mathf.Max(newColor.r, nextColor.r),
			Mathf.Max(newColor.g, nextColor.g),
			Mathf.Max(newColor.b, nextColor.b)
		);
		change=true;
	}

    void Update()
    {
		if (change) {
			skin.color=newColor;
		} else {
			float t = Time.deltaTime * fadeSpeed;
			// slowly fade back to white:
			skin.color = skin.color * (1-t) + Color.white * t;
		}

		change=false;
		newColor=new Color(0, 0, 0);
    }
}
