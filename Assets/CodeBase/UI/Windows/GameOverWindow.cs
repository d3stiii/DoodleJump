using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public class GameOverWindow : Window
    {
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private TMP_Text _lastScoreText;
        [SerializeField] private Button _restartButton;

        protected override void Initialize()
        {
            _lastScoreText.text = $"your score: {DataService.Data.LastScore.ToString()}";
            _highScoreText.text = $"high score: {DataService.Data.HighScore.ToString()}";
            _restartButton.onClick.AddListener(RestartGame);
        }

        private static void RestartGame() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}