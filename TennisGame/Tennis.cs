namespace TennisGame;

public class Tennis
{
    private int _secondPlayerScoreTimes;
    private int _firstPlayerScoreTimes;

    public string Score()
    {
        if (_firstPlayerScoreTimes == 0 || _secondPlayerScoreTimes == 0)
        {
            
            switch (_firstPlayerScoreTimes)
            {
                case 1:
                    return "fifteen love";
                case 2:
                    return "thirty love";
                case 3:
                    return "forty love";
            }

            switch (_secondPlayerScoreTimes)
            {
                case 1:
                    return "love fifteen";
                case 2:
                    return "love thirty";
                case 3:
                    return "love forty";
            }

            return "love all";
        }

        return IsDeuce(_firstPlayerScoreTimes,_secondPlayerScoreTimes) ? CheckDeuce() : CheckLeading();
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