using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCounter : MonoBehaviour
{
    private Slider slider = null;
    private Player player = null;

    private float maxScore = 0f;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.gameObject.SetActive(false);

        player = FindObjectOfType<Player>();
    }

    public void CountMaxScore()
    {
        Flower[] flowers = FindObjectsOfType<Flower>();

        foreach (var f in flowers)
        {
            maxScore += f.Score;
        }
        slider.maxValue = maxScore;
    }
    
    void Update()
    {
        if (slider.gameObject.activeSelf)
            slider.value = player.TotalScore;
    }
}
