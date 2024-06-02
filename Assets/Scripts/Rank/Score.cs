namespace rank
{
    public class Score
    {
        public int rankIndex;
        public string name;
        public string score;

        public Score(int index, string username, string newscore)
        {
            rankIndex = index;
            score = newscore;
            name = username;
        }
    }
}