namespace TennisGame;

public class Tennis
{
    private int _secondPlayerScoreTimes;
    private int _firstPlayerScoreTimes;
    private string _player1Name = "Joey";
    private string _player2Name = "Tom";

    private static Dictionary<int, string> scoreTable = new Dictionary<int, string>()
    {
        { 0, "love" },
        { 1, "fifteen" },
        { 2, "thirty" },
        { 3, "forty" }
    };

    private static Dictionary<Status, string> statusTable = new Dictionary<Status, string>()
    {
        { Status.Adv, "adv" },
        { Status.Win, "win" },
        { Status.All, "all" },
        { Status.Deuce, "deuce" },
        { Status.Blank, " " }
    };
    private enum Status
    {
        Adv,
        Win,
        All,
        Deuce,
        Blank
    }

    public string Score()
    {
        return CheckPointIsNotLoveAll()
            ? IsDeuce() 
                ? CheckDeuce() 
                : CheckLeading()
            : CheckPoint();
    }

    private string CheckPoint()
    {
        return CheckPointIsLoveAll() ? IsAll() : CombinePostbackText();
    }

    private bool CheckPointIsLoveAll()
    {
        return _firstPlayerScoreTimes == 0 && _secondPlayerScoreTimes == 0;
    }
    
    private bool CheckPointIsNotLoveAll()
    {
        return _firstPlayerScoreTimes != 0 && _secondPlayerScoreTimes != 0;
    }

    private string CombinePostbackText()
    {
        return scoreTable[_firstPlayerScoreTimes] + statusTable[Status.Blank] + scoreTable[_secondPlayerScoreTimes];
    }

    private string CheckLeading()
    {
        return PlayerLeading() + statusTable[Status.Blank] + IsAdvOrWin();
    }

    private string IsAdvOrWin()
    {
        return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1 ? statusTable[Status.Adv] : statusTable[Status.Win];
    }

    private string PlayerLeading()
    {
        return _firstPlayerScoreTimes > _secondPlayerScoreTimes ? _player1Name : _player2Name;
    }
    
    private string CheckDeuce()
    {
        return _firstPlayerScoreTimes < 3 ? IsAll() : statusTable[Status.Deuce];
    }

    private string IsAll()
    {
        return scoreTable[_firstPlayerScoreTimes] + statusTable[Status.Blank] + statusTable[Status.All];
    }

    private bool IsDeuce()
    {
        return _firstPlayerScoreTimes == _secondPlayerScoreTimes;
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