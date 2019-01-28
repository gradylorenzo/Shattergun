using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitmarker : MonoBehaviour {

    public float persistence = 0.01f;
    public Color markerColor;
    public Image marker;
    private float wantedOpacity;
    private float currentOpacity;

    private void Awake()
    {
        EventManager.EnemyHit += EnemyHit;
        marker = GetComponent<Image>();
        markerColor = marker.color;
    }

    private void EnemyHit()
    {
        currentOpacity = 1;
    }

    public void FixedUpdate()
    {
        currentOpacity = Mathf.MoveTowards(currentOpacity, 0, persistence);

        markerColor = new Color(marker.color.r, marker.color.g, marker.color.b, currentOpacity);
        marker.color = markerColor;
    }
}
