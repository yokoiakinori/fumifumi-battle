using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class ScoreService
    {
        private float _score;
        private int _comboCount;
        private Dictionary<int, ScoreTable> _scoreTable;
        private Dictionary<int, AdjustmentTable> _adjustmentTable;
        
        public ScoreService()
        {
            _score = 0;
            _comboCount = 0;
            _scoreTable = new Dictionary<int, ScoreTable>
            {
                {1, new ScoreTable(200)},
                {2, new ScoreTable(100)},
                {3, new ScoreTable(0)},
            };
            _adjustmentTable = new Dictionary<int, AdjustmentTable>
            {
                { 1, new AdjustmentTable(10, 1.0f) },
                { 2, new AdjustmentTable(20, 1.3f) },
                { 3, new AdjustmentTable(50, 1.5f) },
            };
        }

        public void CalculateScore(int judgeKey)
        {
            int judgeScore = _scoreTable[judgeKey].Score;
            UpdateComboCount(judgeKey);

            float adjustmentScore = ReviseScore(judgeScore);
            
            AddScore(adjustmentScore);
            Debug.Log("現在のスコア："+_score);
        }

        private void UpdateComboCount(int judgeKey)
        {
            if (judgeKey is 1 or 2)
            {
                _comboCount++;
            }
        }

        private float ReviseScore(int score)
        {
            int adjustmentTableIndex = 1;

            while (_comboCount > _adjustmentTable[adjustmentTableIndex].MaxCombo && adjustmentTableIndex < _adjustmentTable.Count)
            {
                adjustmentTableIndex++;
            }
            
            float adjustmentValue = _adjustmentTable[adjustmentTableIndex].AdjustmentValue;
            return score * adjustmentValue;
        }

        private void AddScore(float score)
        {
            _score += score;
        }

        public float GetScore()
        {
            return _score;
        }
        
        public int GetComboCount()
        {
            return _comboCount;
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
    
    public class AdjustmentTable
    {
        public readonly int MaxCombo;
        public readonly float AdjustmentValue;

        public AdjustmentTable(int maxCombo, float adjustmentValue)
        {
            MaxCombo = maxCombo;
            AdjustmentValue = adjustmentValue;
        }
    }
}