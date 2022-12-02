namespace DevToolsNet.WinFormsControlLibrary.Style
{
    public interface IStyleManager
    {
        string Active { get; set; }

        void AplyStyleControl(Control c, Style? style = null);
        void AplyStyleForm(Form frm, Style? style = null);
    }
}