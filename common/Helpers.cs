using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace tvlauncher.common
{
    public static class StringBytesConverter
    {
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars).TrimEnd(new char[] { '\0' });
        }
    }

    public class RichTextBoxStreamWriter : TextWriter
    {
        RichTextBox _output = null;

        public RichTextBoxStreamWriter(RichTextBox output)
        {
            _output = output;
        }

        public override void Write(string value)
        {
            base.Write(value);
            _output.InvokeIfNeeded(() => _output.AppendText(value));
        }

        public override void WriteLine(string value)
        {
            base.WriteLine(value);
            _output.InvokeIfNeeded(() => _output.AppendText(value + Environment.NewLine));
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }

    /// <summary>
    /// Расширения облегчающие работу с элементами управления в многопоточной среде.
    /// </summary>
    public static class ControlExtentions
    {
        /// <summary>
        /// Вызов делегата через control.Invoke, если это необходимо.
        /// </summary>
        /// <param name="control">Элемент управления</param>
        /// <param name="doit">Делегат с некоторым действием</param>
        public static void InvokeIfNeeded(this Control control, Action doit)
        {
            try
            {
                if (control.InvokeRequired)
                    control.Invoke(doit);
                else
                    doit();
            }
            catch
            {
            }
        }
        /// <summary>
        /// Вызов делегата через control.Invoke, если это необходимо.
        /// </summary>
        /// <typeparam name="T">Тип параметра делегата</typeparam>
        /// <param name="control">Элемент управления</param>
        /// <param name="doit">Делегат с некоторым действием</param>
        /// <param name="arg">Аргумент делагата с действием</param>
        public static void InvokeIfNeeded<T>(this Control control, Action<T> doit, T arg)
        {
            try
            {
                if (control.InvokeRequired)
                    control.Invoke(doit, arg);
                else
                    doit(arg);
            }
            catch
            {
            }
        }
    }

    public static class ConsoleTimeLogger
    {
        public static void WriteLine<T>(T message, TextWriter tw)
        {
            tw.Write(DateTime.Now + " ");
            tw.WriteLine(message);
        }
    }
}