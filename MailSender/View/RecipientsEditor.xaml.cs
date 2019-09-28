using System.Windows.Controls;

namespace MailSender.View
{
    public partial class RecipientsEditor
    {
        public RecipientsEditor() { InitializeComponent(); }

        //private void OnDataValidationError(object Sender, ValidationErrorEventArgs E)
        //{
        //    if(!(E.Source is Control control)) return;

        //    if (E.Action == ValidationErrorEventAction.Added)
        //        control.ToolTip = E.Error.ErrorContent.ToString();
        //    else
        //        //control.ToolTip = null; // Это ошибка!
        //        //control.ToolTip = "";
        //        control.ClearValue(ToolTipProperty);
        //}
    }
}