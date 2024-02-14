using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreResult : MonoBehaviour
{
    public TextMeshProUGUI scoreCountText;
    // Start is called before the first frame update
    void Start()
    {
        scoreCountText.text = PlayerMovement.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
