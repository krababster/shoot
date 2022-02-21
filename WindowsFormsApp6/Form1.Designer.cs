using System;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";

            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.MouseClick += Form1_MouseClick;
            this.Cursor.Dispose();
            this.DoubleBuffered = true;

            duck_rect.X = 350;
            duck_rect.Y = 350;
            duck_rect.Height = 150;
            duck_rect.Width = 150;

        }



        Point mouse_location = new Point();
        Rectangle duck_rect = new Rectangle();
        bool isalive = true;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_location.X = e.Location.X;
            mouse_location.Y = e.Location.Y;

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GC.Collect();
            e.Graphics.Flush();


            if (isalive)
            {
                if (duck_rect.IntersectsWith(
                   new Rectangle(
                       mouse_location,
                       new Size(35, 35)
                       )
               ))
                {

                    isalive = false;
                }
                e.Graphics.DrawImage(Image.FromFile("duck_alive.png"), duck_rect);
            }
            else
            {
                e.Graphics.DrawImage(Image.FromFile("duck_killed.png"), duck_rect);
            }

            foreach (var item in points)
            {
                e.Graphics.FillEllipse(Brushes.Red, item.X + 50, item.Y + 50, 5, 5);
            }

            Thread.Sleep(20);
            e.Graphics.DrawEllipse(Pens.Red, mouse_location.X, mouse_location.Y, 100, 100);
            e.Graphics.DrawLine(Pens.Red, mouse_location.X - 25, mouse_location.Y + 50, mouse_location.X + 25, mouse_location.Y + 50);
            e.Graphics.DrawLine(Pens.Red, mouse_location.X + 75, mouse_location.Y + 50, mouse_location.X + 125, mouse_location.Y + 50);
            e.Graphics.DrawLine(Pens.Red, mouse_location.X + 50, mouse_location.Y + 25, mouse_location.X + 50, mouse_location.Y + -25);
            e.Graphics.DrawLine(Pens.Red, mouse_location.X + 50, mouse_location.Y + 75, mouse_location.X + 50, mouse_location.Y + 125);
            e.Graphics.FillEllipse(Brushes.Red, mouse_location.X + 50, mouse_location.Y + 50, 5, 5);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(new Point(mouse_location.X, mouse_location.Y));
        }



        List<Point> points = new List<Point>();
        #endregion
    }
}

