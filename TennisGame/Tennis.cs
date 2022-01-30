namespace TennisGame;

public class Tennis
{
    private int _secondPlayerScoreTimes;
    private int _firstPlayerScoreTimes;

    public string Score()
    {
        return _firstPlayerScoreTimes != 0 && _secondPlayerScoreTimes != 0
            ? IsDeuce(_firstPlayerScoreTimes, _secondPlayerScoreTimes) 
                ? CheckDeuce() 
                : CheckLeading()
            : CheckPoint();
    }

    private string CheckPoint()
    {
        if (_firstPlayerScoreTimes == 1 || _secondPlayerScoreTimes == 1)
            return _firstPlayerScoreTimes == 1 ? "fifteen love" : "love fifteen";
        if (_firstPlayerScoreTimes == 2 || _secondPlayerScoreTimes == 2)
            return _firstPlayerScoreTimes == 2 ? "thirty love" : "love thirty";
        if (_firstPlayerScoreTimes == 3 || _secondPlayerScoreTimes == 3)
            return _firstPlayerScoreTimes == 3 ? "forty love" : "love forty";

        return "love all";

    }

    private string CheckLeading()
    {
        return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1 ?
            _firstPlayerScoreTimes > _secondPlayerScoreTimes ? "Joey adv" : "Tom adv" :
            _firstPlayerScoreTimes > _secondPlayerScoreTimes ? "Joey win" : "Tom win";
    }

    private string CheckDeuce()
    {
        return _firstPlayerScoreTimes < 3 ? _firstPlayerScoreTimes == 1 ? "fifteen all" : "thirty all" : "deuce";
    }

    private static bool IsDeuce(int firstPlayerScoreTimes, int secondPlayerScoreTimes)
    {
        return firstPlayerScoreTimes == secondPlayerScoreTimes;
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