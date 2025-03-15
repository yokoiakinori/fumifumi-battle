using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class ScoreService
    {
        private int _score;
        private Dictionary<int, ScoreTable> _scoreTable;
        
        public ScoreService()
        {
            _score = 0; 
            _scoreTable = new Dictionary<int, ScoreTable>
            {
                {1, new ScoreTable(200)},
                {2, new ScoreTable(100)},
                {3, new ScoreTable(0)},
            };
            
        }

        public void CalculateScore(int judgeKey)
        {
            int judgeScore = _scoreTable[judgeKey].Score;
            AddScore(judgeScore);
            Debug.Log("現在のスコア："+_score);
        }

        private void AddScore(int score)
        {
            _score += score;
        }

        public int GetScore()
        {
            return _score;
        }
    }
    
    public class ScoreTable
    {
        public readonly int Score;

        public ScoreTable(int score)
        {
            Score = score;
        }
    }
}