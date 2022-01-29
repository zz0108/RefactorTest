using NUnit.Framework;
using TennisGame;

namespace TennisGameTest;

public class TennisTests
{
    private Tennis _tennis = new Tennis();

    [Test]
    public void LoveAll()
    {
        ScoreShouldBe("love all");
    }

    [TestCase(1)]
    public void FifteenLove(int firstPlayerScore)
    {
        GivenFirstPlayerScore(firstPlayerScore);
        ScoreShouldBe("fifteen love");
    }

    [Test]
    public void ThirtyLove()
    {
        GivenFirstPlayerScore(2);
        ScoreShouldBe("thirty love");
    }

    [Test]
    public void FortyLove()
    {
        GivenFirstPlayerScore(3);
        ScoreShouldBe("forty love");
    }

    [Test]
    public void LoveFifteen()
    {
        GivenSecondPlayerScore(1);
        ScoreShouldBe("love fifteen");
    }

    [Test]
    public void LoveThirty()
    {
        GivenSecondPlayerScore(2);
        ScoreShouldBe("love thirty");
    }

    [Test]
    public void LoveForty()
    {
        GivenSecondPlayerScore(3);
        ScoreShouldBe("love forty");
    }

    [Test]
    public void FifteenAll()
    {
        GivenFirstPlayerScore(1);
        GivenSecondPlayerScore(1);
        ScoreShouldBe("fifteen all");
    }

    [Test]
    public void ThirtyAll()
    {
        GivenFirstPlayerScore(2);
        GivenSecondPlayerScore(2);
        ScoreShouldBe("thirty all");
    }

    [Test]
    public void Deuce()
    {
        GivenDeuce();
        ScoreShouldBe("deuce");
    }

    [Test]
    public void FirstPlayerAdv()
    {
        GivenDeuce();
        GivenFirstPlayerScore(1);
        ScoreShouldBe("Joey adv");
    }

    [Test]
    public void SecondPlayerAdv()
    {
        GivenDeuce();
        GivenSecondPlayerScore(1);
        ScoreShouldBe("Tom adv");
    }

    [Test]
    public void SecondPlayerWin()
    {
        GivenDeuce();
        GivenSecondPlayerScore(2);
        ScoreShouldBe("Tom win");
    }

    [Test]
    public void FirstPlayerWin()
    {
        GivenDeuce();
        GivenFirstPlayerScore(2);
        ScoreShouldBe("Joey win");
    }

    private void GivenDeuce()
    {
        GivenFirstPlayerScore(3);
        GivenSecondPlayerScore(3);
    }

    private void GivenSecondPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennis.SecondPlayerScore();
        }
    }

    private void GivenFirstPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennis.FirstPlayerScore();
        }
    }

    private void ScoreShouldBe(string expected)
    {
        Assert.AreEqual(expected, _tennis.Score());
        _tennis.Refresh();
    }
}