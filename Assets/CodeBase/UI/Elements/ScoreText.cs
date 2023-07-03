using TMPro;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetValue(int score) => 
            _text.text = score.ToString();
    }
}