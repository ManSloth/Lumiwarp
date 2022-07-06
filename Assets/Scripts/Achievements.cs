using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class Achievements : MonoBehaviour {

    public static Achievements unlock;

    void Awake ()
    {
        if (unlock == null)
        {
            DontDestroyOnLoad(gameObject);
            unlock = this;
        }
        else if (unlock != this)
        {
            Destroy(gameObject);
        }
    }
	
    // 1
    public void ClassicEasy5Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQBQ", 100.0f, (bool success) =>
            {

            });
    }

    // 2
    public void ClassicEasy10Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQBg", 100.0f, (bool success) =>
            {

            });
    }

    // 3
    public void ClassicEasy25Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQBw", 100.0f, (bool success) =>
            {

            });
    }

    // 4
    public void ClassicEasy50Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQCA", 100.0f, (bool success) =>
            {

            });
    }

    // 5
    public void ClassicEasy100Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQCQ", 100.0f, (bool success) =>
            {

            });
    }

    // 6
    public void ClassicEasy150Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQCg", 100.0f, (bool success) =>
            {

            });
    }

    // 7
    public void ClassicEasy200Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQCw", 100.0f, (bool success) =>
            {

            });
    }

    // 8
    public void ClassicHard5Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQDA", 100.0f, (bool success) =>
            {

            });
    }

    // 9
    public void ClassicHard10Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQDQ", 100.0f, (bool success) =>
            {

            });
    }

    // 10
    public void ClassicHard25Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQDg", 100.0f, (bool success) =>
            {

            });
    }

    // 11
    public void ClassicHard50Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQDw", 100.0f, (bool success) =>
            {

            });
    }

    // 12
    public void ClassicHard100Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQEA", 100.0f, (bool success) =>
            {

            });
    }

    // 13
    public void ClassicHard150Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQEQ", 100.0f, (bool success) =>
            {

            });
    }

    // 14
    public void ClassicHard200Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQEg", 100.0f, (bool success) =>
            {

            });
    }

    // 15
    public void ShiftEasy5Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQEw", 100.0f, (bool success) =>
            {

            });
    }

    // 16
    public void ShiftEasy10Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQFA", 100.0f, (bool success) =>
            {

            });
    }

    // 17
    public void ShiftEasy25Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQFQ", 100.0f, (bool success) =>
            {

            });
    }

    // 18
    public void ShiftEasy50Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQFg", 100.0f, (bool success) =>
            {

            });
    }

    // 19
    public void ShiftEasy100Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQFw", 100.0f, (bool success) =>
            {

            });
    }

    // 20
    public void ShiftEasy150Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQGA", 100.0f, (bool success) =>
            {

            });
    }

    // 21
    public void ShiftEasy200Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQGQ", 100.0f, (bool success) =>
            {

            });
    }

    // 22
    public void ShiftHard5Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQGg", 100.0f, (bool success) =>
            {

            });
    }

    // 23
    public void ShiftHard10Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQGw", 100.0f, (bool success) =>
            {

            });
    }

    // 24
    public void ShiftHard25Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQHA", 100.0f, (bool success) =>
            {

            });
    }

    // 25
    public void ShiftHard50Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQHQ", 100.0f, (bool success) =>
            {

            });
    }

    // 26
    public void ShiftHard100Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQHg", 100.0f, (bool success) =>
            {

            });
    }

    // 27
    public void ShiftHard150Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQHw", 100.0f, (bool success) =>
            {

            });
    }

    // 28
    public void ShiftHard200Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQIA", 100.0f, (bool success) =>
            {

            });
    }

    // 29
    public void SequenceEasy5Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQIQ", 100.0f, (bool success) =>
            {

            });
    }

    // 30
    public void SequenceEasy10Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQIg", 100.0f, (bool success) =>
            {

            });
    }

    // 31
    public void SequenceEasy25Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQIw", 100.0f, (bool success) =>
            {

            });
    }

    // 32
    public void SequenceEasy50Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQJA", 100.0f, (bool success) =>
            {

            });
    }

    // 33
    public void SequenceEasy100Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQJQ", 100.0f, (bool success) =>
            {

            });
    }

    // 34
    public void SequenceEasy150Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQJg", 100.0f, (bool success) =>
            {

            });
    }

    // 35
    public void SequenceEasy200Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQJw", 100.0f, (bool success) =>
            {

            });
    }

    // 36
    public void SequenceHard5Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQKA", 100.0f, (bool success) =>
            {

            });
    }

    // 37
    public void SequenceHard10Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQKQ", 100.0f, (bool success) =>
            {

            });
    }

    // 38
    public void SequenceHard25Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQKg", 100.0f, (bool success) =>
            {

            });
    }

    // 39
    public void SequenceHard50Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQKw", 100.0f, (bool success) =>
            {

            });
    }

    // 40
    public void SequenceHard100Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQLA", 100.0f, (bool success) =>
            {

            });
    }

    // 41
    public void SequenceHard150Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQLQ", 100.0f, (bool success) =>
            {

            });
    }

    // 42
    public void SequenceHard200Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQLg", 100.0f, (bool success) =>
            {

            });
    }

    // 43
    public void Memory5Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQLw", 100.0f, (bool success) =>
            {

            });
    }

    // 44
    public void Memory10Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQMA", 100.0f, (bool success) =>
            {

            });
    }

    // 45
    public void Memory25Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQMQ", 100.0f, (bool success) =>
            {

            });
    }

    // 46
    public void Memory50Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQMg", 100.0f, (bool success) =>
            {

            });
    }

    // 47
    public void Memory75Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQMw", 100.0f, (bool success) =>
            {

            });
    }

    // 48
    public void Memory100Pts()
    {
        if (Social.localUser.authenticated)
            Social.ReportProgress("CgkI3fz1i50WEAIQNA", 100.0f, (bool success) =>
            {

            });
    }

    // 49
    public void Classic10X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQNQ", 1, (bool success) => {
               
            });
    }

    // 50
    public void Classic50X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQNg", 1, (bool success) => {
                
            });
    }

    // 51
    public void Classic100X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQNw", 1, (bool success) => {

            });
    }

    // 52
    public void Shift10X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQOA", 1, (bool success) => {

            });
    }

    // 53
    public void Shift50X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQOQ", 1, (bool success) => {

            });
    }

    // 54
    public void Shift100X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQOg", 1, (bool success) => {

            });
    }

    // 55
    public void Sequence10X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQOw", 1, (bool success) => {

            });
    }

    // 56
    public void Sequence50X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQPA", 1, (bool success) => {

            });
    }

    // 57
    public void Sequence100X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQPQ", 1, (bool success) => {

            });
    }

    // 58
    public void Memory10X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQPg", 1, (bool success) => {

            });
    }

    // 59
    public void Memory50X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQPw", 1, (bool success) => {

            });
    }

    // 60
    public void Memory100X()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQQA", 1, (bool success) => {

            });
    }

    // 61
    public void Minutes60()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQQQ", 1, (bool success) => {

            });
    }

    // 62
    public void Hours5()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQQg", 1, (bool success) => {

            });
    }

    // 63
    public void Hours10()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQQw", 1, (bool success) => {

            });
    }

    // 64
    public void Week()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQRA", 1, (bool success) => {

            });
    }

    // 65
    public void Month()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQRQ", 1, (bool success) => {

            });
    }

    // 66
    public void Multiplayer5Rounds()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQRg", 1, (bool success) => {

            });
    }

    // 67
    public void Multiplayer25Rounds()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(
            "CgkI3fz1i50WEAIQRw", 1, (bool success) => {

            });
    }
}
