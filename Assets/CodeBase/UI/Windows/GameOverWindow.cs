using TMPro;
using UnityEngine;

namespace CodeBase.UI.Windows
{
    public class GameOverWindow : Window
    {
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private TMP_Text _lastScoreText;

        protected override void Initialize()
        {
            _lastScoreText.text = $"your score: {DataService.Data.LastScore.ToString()}";
            _highScoreText.text = $"high score: {DataService.Data.HighScore.ToString()}";
        }
    }
}