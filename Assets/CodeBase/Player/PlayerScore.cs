using System;
using CodeBase.Data;
using CodeBase.Services.Data.SaveLoad;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerScore : MonoBehaviour, ISavedData
    {
        public event Action OnScoreChanged;
        [SerializeField] private int _scoreMultiplier;

        public int Score { get; private set; }

        private int _highScore;
        
        private void Update()
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            var currentScore = (int)(transform.position.y * _scoreMultiplier);
            if (currentScore <= Score) return;
            Score = currentScore;
            OnScoreChanged?.Invoke();
        }

        public void LoadData(PlayerData data)
        {
            _highScore = data.HighScore;
        }

        public void UpdateData(PlayerData data)
        {
            data.LastScore = Score;
            if (Score > _highScore)
            {
                data.HighScore = Score;
            }
        }
    }
}