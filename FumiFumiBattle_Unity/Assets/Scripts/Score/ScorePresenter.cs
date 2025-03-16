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
            int score = _scoreService.GetScore();
            _scoreView.UpdateScore(score);
        }
    }
}