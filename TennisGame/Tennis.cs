using System.Runtime.InteropServices.ComTypes;

namespace TennisGame;

public class Tennis
{
    private int _secondPlayerScoreTimes;
    private int _firstPlayerScoreTimes;

    private static readonly Dictionary<int, string> scoreCompare = new Dictionary<int, string>()
    {
        { 0, "love" },
        { 1, "fifteen" },
        { 2, "thirty" },
        { 3, "forty" },
        { 4, "adv" },
        { 5, "win" }
    };

    public string Score()
    {

        if (IsDeuce()) return DeuceOrEqual();
        
        if (IsLove()) return CountScore();
        
        return IsLeading() ? LeadingScore() : string.Empty;
    }

    private string LeadingScore()
    {
        return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1 ? CheckAdvName() : CheckWinnerName();
    }

    private bool IsLeading()
    {
        return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) > 0;
    }

    private string CountScore()
    {
        return $"{scoreCompare[_firstPlayerScoreTimes]} {scoreCompare[_secondPlayerScoreTimes]}";
    }

    private bool IsLove()
    {
        return _firstPlayerScoreTimes == 0 || _secondPlayerScoreTimes == 0;
    }

    private string DeuceOrEqual()
    {
        return _firstPlayerScoreTimes > 2 ? "deuce" : $"{scoreCompare[_firstPlayerScoreTimes]} all";
    }

    private bool IsDeuce()
    {
        return _firstPlayerScoreTimes == _secondPlayerScoreTimes;
    }
        

    private string CheckAdvName()
    {
        return _firstPlayerScoreTimes > _secondPlayerScoreTimes ? "Joey adv" : "Tom adv";
    }

    private string CheckWinnerName()
    {
        return _firstPlayerScoreTimes > _secondPlayerScoreTimes ? "Joey win" : "Tom win";
    }

    public void FirstPlayerScore()
    {
        this._firstPlayerScoreTimes++;
    }

    public void SecondPlayerScore()
    {
        this._secondPlayerScoreTimes++;
    }

    public void Refresh()
    {
        this._firstPlayerScoreTimes = 0;
        this._secondPlayerScoreTimes = 0;
    }
}