using System.Drawing;
using System.Windows.Forms;

namespace WebBalloon
{
    public interface IUserNotifier
    {
        void Notify(Notification notification);
    }

    public class BalloonNotifier : IUserNotifier
    {
        public void Notify(Notification notification)
        {
            var notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipTitle = notification.Title,
                BalloonTipText = notification.Text,
                Visible = true
            };
            notifyIcon.ShowBalloonTip(30000);
        }
    }
}