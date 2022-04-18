using System;

// basic c# script, player's entry data
namespace Highscores {
    [Serializable]
    public struct ScoreBoardEntryData {
        public string entryName;
        public int entryScore;
    }
}