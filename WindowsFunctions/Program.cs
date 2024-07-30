

using System.Runtime.InteropServices;
Windows.MessageBox(IntPtr.Zero, "Hello World!", "Hello Dialog", 0);
public class Windows
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
}