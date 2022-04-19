using System;
using System.Collections.Generic;

namespace Highscores {
    [Serializable]
    // Saves list of entries
    public class ScoreBoardSaveData {
        // List of entries
        public List<ScoreBoardEntryData> highscores = new List<ScoreBoardEntryData>();
    }
}
