using VContainer.Unity;

namespace Score
{
    public class ScorePresenter
    {
        readonly ScoreService _scoreService;
        readonly ScoreView _scoreView;
        
        public ScorePresenter(ScoreService scoreService, ScoreView scoreView)
        {
            _scoreService = scoreService;
            _scoreView = scoreView;
        }

        public void OnUpdateScore(int judgementKey)
        {
            _scoreService.CalculateScore(judgementKey);
            float score = _scoreService.GetScore();
            int comboCount = _scoreService.GetComboCount();
            _scoreView.UpdateScore(score);
            _scoreView.UpdateCombo(comboCount);
        }
    }
}