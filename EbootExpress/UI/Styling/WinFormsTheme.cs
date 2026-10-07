using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EbootExpress
{
    internal static class WinFormsTheme
    {
        private const int DwmwaUseImmersiveDarkMode = 20;
        private const int DwmwaUseImmersiveDarkModeLegacy = 19;

        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(
            IntPtr windowHandle, int attribute, ref int attributeValue, int attributeSize);

        internal static void EnableDarkTitleBar(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException("form");
            }

            form.HandleCreated += Form_HandleCreated;
            if (form.IsHandleCreated)
            {
                SetDarkTitleBar(form);
            }
        }

        internal static void SetStatus(Label label, string text, Color stateColor)
        {
            if (label == null)
            {
                throw new ArgumentNullException("label");
            }

            label.Text = text;
            if (stateColor == Color.SeaGreen)
            {
                label.ForeColor = Color.FromArgb(121, 235, 199);
                label.BackColor = Color.FromArgb(18, 54, 48);
            }
            else if (stateColor == Color.Firebrick)
            {
                label.ForeColor = Color.FromArgb(255, 150, 157);
                label.BackColor = Color.FromArgb(67, 34, 43);
            }
            else
            {
                label.ForeColor = Color.FromArgb(255, 193, 112);
                label.BackColor = Color.FromArgb(65, 49, 27);
            }
        }

        private static void Form_HandleCreated(object sender, EventArgs e)
        {
            Form form = sender as Form;
            if (form != null)
            {
                SetDarkTitleBar(form);
            }
        }

        private static void SetDarkTitleBar(Form form)
        {
            int darkModeEnabled = 1;
            try
            {
                int result = DwmSetWindowAttribute(
                    form.Handle, DwmwaUseImmersiveDarkMode, ref darkModeEnabled, sizeof(int));
                if (result != 0)
                {
                    DwmSetWindowAttribute(
                        form.Handle, DwmwaUseImmersiveDarkModeLegacy, ref darkModeEnabled, sizeof(int));
                }
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }
    }
}
