using System.ComponentModel;
using DotNetMigrationTooll.Workflows;

namespace DotNetMigrationTooll.Win.Feedbacks;

public static class FeedbackExtensions
{
    public static void SendFeedback(this BackgroundWorker backgroundWorker, FeedbackKind kind, string message)
    {
        backgroundWorker.ReportProgress(0, new FeedBack(kind, message));
    }

    private static Color GetTextColor(this FeedbackKind kind)
    {
        return kind switch
        {
            FeedbackKind.Error => Color.Red,
            FeedbackKind.Success => Color.Green,
            _ => Color.Black
        };
    }

    public static void AppendFeedback(this RichTextBox richTextBox, FeedBack feedBack)
    {
        richTextBox.SelectionColor = feedBack.Kind.GetTextColor();
        richTextBox.AppendText(feedBack.Message);
        richTextBox.AppendText(Environment.NewLine);
        richTextBox.ScrollToCaret();
    }

    public static FeedbackKind ToFeedbackKind(this ActivityStatus status)
    {
        return status switch
        {
            ActivityStatus.Success => FeedbackKind.Success,
            ActivityStatus.Fail => FeedbackKind.Error,
            _ => FeedbackKind.None
        };
    }

    public static FeedbackKind GetFeedbackKind(this Activity execution)
    {
        return execution.Status.ToFeedbackKind();
    }
}
