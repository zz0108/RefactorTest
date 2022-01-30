using System.Collections;
using NUnit.Framework;
using TennisGame;

namespace TennisGameTest;

public class TennisTests
{
    private Tennis _tennis = new Tennis();

    private static IEnumerable TestData()
    {
        yield return new TestCaseData(0, 0, "love all");
        yield return new TestCaseData(1, 0, "fifteen love");
        yield return new TestCaseData(2, 0, "thirty love");
        yield return new TestCaseData(3, 0, "forty love");
        yield return new TestCaseData(0, 1, "love fifteen");
        yield return new TestCaseData(0, 2, "love thirty");
        yield return new TestCaseData(0, 3, "love forty");
        yield return new TestCaseData(1, 1, "fifteen all");
        yield return new TestCaseData(2, 2, "thirty all");
        yield return new TestCaseData(3, 3, "deuce");
        yield return new TestCaseData(4, 3, "Joey adv");
        yield return new TestCaseData(3, 4, "Tom adv");
        yield return new TestCaseData(5, 3, "Joey win");
        yield return new TestCaseData(3, 5, "Tom win");
    }
    
    [Test]
    [TestCaseSource(nameof(TestData))]
    public void AllTest(int firstPlayerScore,int secondPlayerScore,string expected)
    {
        GivenFirstPlayerScore(firstPlayerScore);
        GivenSecondPlayerScore(secondPlayerScore);
        ScoreShouldBe(expected);
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
    }

    [TearDown]
    public void Refresh()
    {
        _tennis.Refresh();
    }
}