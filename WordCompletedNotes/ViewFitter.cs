﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordCompletedNotes
{
    public class ViewFitter
    {
        private AutocompletionForm autoForm;
        private ListBox listBox;

        private TextBox textBox;
        private Point textBoxCorner;

        private float lineHeight;
        private float fontWidth;
        private float spaceWidth;

        public ViewFitter(AutocompletionForm af, ListBox lb, TextBox tb)
        {
            Console.OutputEncoding = Encoding.UTF8;

            autoForm = af;
            listBox = lb;

            textBox = tb;

            textBoxCorner = textBox.Parent.PointToScreen(textBox.Location);

            using (Graphics g = textBox.CreateGraphics())
            {
                lineHeight = Convert.ToInt32(g.MeasureString("A", textBox.Font).Height);
                fontWidth = Convert.ToInt32(g.MeasureString("A", textBox.Font).Width);
                spaceWidth = Convert.ToInt32(g.MeasureString(" ", textBox.Font).Width);
            }
        }

        public void AdjustAndShowPrompts(List<string> list)
        {
            if (list.Any())
            {
                int height = (list.Count + 1) * listBox.ItemHeight;
                autoForm.Height = listBox.Height = height;
                listBox.Items.AddRange(list.ToArray());
                autoForm.Show();
            }
        }

        public void UpdateListBoxPosition()
        {
            textBoxCorner = textBox.Parent.PointToScreen(textBox.Location);

            Point cursorPosition = textBox.GetPositionFromCharIndex(textBox.SelectionStart - 1);
            Point relativeCursorPosition = new Point(cursorPosition.X + textBoxCorner.X + (int)(fontWidth + 1), cursorPosition.Y + textBoxCorner.Y + (int)(lineHeight + 1));

            if (textBox.Text.Length > 0 && (textBox.Text[textBox.Text.Length - 1]) == 10 // ASCII 10 - Line Feed
                || relativeCursorPosition.X > (textBoxCorner.X + textBox.Width - 28)) // approx. font width + scroll bar width
            {
                relativeCursorPosition = new Point(textBoxCorner.X + (int)(fontWidth + 1), relativeCursorPosition.Y + (int)(lineHeight + 1));
            }

            autoForm.Location = relativeCursorPosition;
        }

        private float MeasureStringWidth(string text)
        {
            using (Graphics g = textBox.CreateGraphics())
            {
                return g.MeasureString(text, textBox.Font).Width;
            }
        }
    }
}
