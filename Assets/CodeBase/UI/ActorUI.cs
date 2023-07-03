using CodeBase.Player;
using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private ScoreText _scoreText;
        private PlayerScore _score;

        public void Construct(PlayerScore score)
        {
            _score = score;
            _score.OnScoreChanged += UpdateScoreText;
        }

        private void UpdateScoreText() => 
            _scoreText.SetValue(_score.Score);
    }
}