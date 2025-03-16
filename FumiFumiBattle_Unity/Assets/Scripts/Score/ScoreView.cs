using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        
        public void UpdateScore(int scoreValue)
        {
            scoreText.text = "現在のスコア: "+scoreValue;
        }
    }
}
