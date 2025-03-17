using TMPro;
using UnityEngine;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI comboText;
        
        public void UpdateScore(float scoreValue)
        {
            scoreText.text = "現在のスコア : "+scoreValue;
        }
        
        public void UpdateCombo(int comboValue)
        {
            comboText.text = "現在のコンボ : "+comboValue;
        }
    }
}
