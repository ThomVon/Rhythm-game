using UnityEngine;
using UnityEngine.UI;

namespace Highscores {
    public class ScoreBoardEntryUI : MonoBehaviour {
        [SerializeField] private Text entryNameText;
        [SerializeField] private Text entryScoreText;

        // Displays the entries
        public void Initialize(ScoreBoardEntryData scoreboardEntryData) {
            entryNameText.text = scoreboardEntryData.entryName;
            entryScoreText.text = scoreboardEntryData.entryScore.ToString();
        }
    }
}