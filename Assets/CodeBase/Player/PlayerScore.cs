using System;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerScore : MonoBehaviour
    {
        public event Action OnScoreChanged;
        [SerializeField] private int _scoreMultiplier;

        public int Score { get; private set; }

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
    }
}