using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLabel : MonoBehaviour
{
    [SerializeField] string text = "Label";
    [SerializeField] int textSize = 25;
    [SerializeField] Color color = Color.black;
    [SerializeField] Vector3 worldOffset;

    private void OnGUI()
    {
        var pos = Camera.main.WorldToScreenPoint(this.transform.position+worldOffset);
        var rect = new Rect(pos.x, Screen.height - pos.y, 0, 0);
        var style = new GUIStyle();
        style.fontSize = textSize;
        style.fontStyle = FontStyle.Bold;
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = color;
        GUI.Label(rect, text, style);
    }
}
