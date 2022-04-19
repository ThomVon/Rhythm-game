using System.IO;
using UnityEngine;

namespace Highscores {
    public class LeaderBoard : MonoBehaviour {
        // Maximum amount of entries
        [SerializeField] private int maxEntries = 8;
        [SerializeField] private Transform ElementsTransform = null;
        [SerializeField] private GameObject highscoreelementObject = null;

        // place where the data is saved
        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        // At the start we want everthing to be up the date
        private void Start() {
            ScoreBoardSaveData savedScores = GetSavedScores();

            Savescores(savedScores);
            UpdateUI(savedScores);
        }

        // Adding an entry
        public void AddEntry(ScoreBoardEntryData scoreboardEntryData) {
            ScoreBoardSaveData savedScores = GetSavedScores();
            
            bool scoreAdded = false;

            for(int i = 0; i < savedScores.highscores.Count; i++) {
                if(scoreboardEntryData.entryScore > savedScores.highscores[i].entryScore) {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if(!scoreAdded && savedScores.highscores.Count < maxEntries) {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            // if there is to many entries
            if(savedScores.highscores.Count > maxEntries) {
                savedScores.highscores.RemoveRange(maxEntries, savedScores.highscores.Count - maxEntries);
            }

            UpdateUI(savedScores);
            Savescores(savedScores);
        }

        // Updates the leaderboard
        private void UpdateUI(ScoreBoardSaveData savedScores) {
            foreach(Transform child in ElementsTransform) {
                Destroy(child.gameObject);
            }

            foreach(ScoreBoardEntryData highscore in savedScores.highscores) {
                Instantiate(highscoreelementObject, ElementsTransform).GetComponent<ScoreBoardEntryUI>().Initialize(highscore);
            }
        }

        // Loads the scores
        private ScoreBoardSaveData GetSavedScores(){
            // if there isn't a file yet, it makes it and also dispose it
            if(!File.Exists(SavePath)) {
                File.Create(SavePath).Dispose();
                return new ScoreBoardSaveData();
            }

            // if the file exists
            using(StreamReader stream = new StreamReader(SavePath)) {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreBoardSaveData>(json);
            }
        }

        // Saves the scores
        private void Savescores(ScoreBoardSaveData scoreboardSaveData) {
            using(StreamWriter stream = new StreamWriter(SavePath)) {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }
    }
}