namespace TennisGame;

public class Tennis
{
    private int _secondPlayerScoreTimes;
    private int _firstPlayerScoreTimes;

    public string Score()
    {
        if (_firstPlayerScoreTimes <= 3 && _secondPlayerScoreTimes == 0)
        {
            if(_firstPlayerScoreTimes == 0)
                return "love all";
            if(_firstPlayerScoreTimes == 1)
                return "fifteen love";
            if(_firstPlayerScoreTimes == 2)
                return "thirty love";
            if(_firstPlayerScoreTimes == 3)
                return "forty love";
        }

        if (_firstPlayerScoreTimes == 0 && _secondPlayerScoreTimes <= 3)
        {
            if(_secondPlayerScoreTimes == 1)
                return "love fifteen";
            if(_secondPlayerScoreTimes == 2)
                return "love thirty";
            if(_secondPlayerScoreTimes == 3)
                return "love forty";
        }

        if (_firstPlayerScoreTimes == _secondPlayerScoreTimes)
        {
            if(_firstPlayerScoreTimes == 1)
                return "fifteen all";
            if(_firstPlayerScoreTimes == 2)
                return "thirty all";
            if(_firstPlayerScoreTimes == 3)
                return "deuce";
            if(_firstPlayerScoreTimes == 4)
                return "deuce";
        }

        if (Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1)
        {
            return _firstPlayerScoreTimes > _secondPlayerScoreTimes ? "Joey adv" : "Tom adv";
        }
        
        if (Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 2)
        {
            return _firstPlayerScoreTimes > _secondPlayerScoreTimes ? "Joey win" : "Tom win";
        }

        return null;
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