using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Cubic_Bezier_Splines
{
    public partial class Form1 : Form
    {
        Bitmap map;
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3);
        Pen penPoints = new Pen(Color.Red, 3);
        Pen penSelect = new Pen(Color.Blue, 3);
        List<PointF> points = new List<PointF>();
        PointF selectedPoint;

        enum Mod { Draw, Select };
        Mod mod = Mod.Draw;

        public Form1()
        {
            InitializeComponent();
            map = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(map);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Remove(selectedPoint);
            ShowBezierSplinesAndPoints();
            panel.Enabled = false;
        }

        private PointF FindPointBetween(PointF p1, PointF p2, float i)
        {
            return new PointF(p1.X - (p1.X - p2.X) * i,
                p1.Y - (p1.Y - p2.Y) * i);
        }

        private void ShowBezierSplinesAndPoints()
        {
            CreateBezierSplines();
            foreach (var p in points)
                graphics.DrawLine(penPoints, new PointF(p.X - 1, p.Y - 1),
                    new PointF(p.X + 1, p.Y + 1));
        }

        private void CreateBezierSplines()
        {
            graphics.Clear(pictureBox.BackColor);
            if (points.Count < 2)
            {
                pictureBox.Image = map;
                return;
            }

            PointF[] goodPoints = points.ToArray();

            PointF lastPoint = goodPoints[0];
            for (float i = 0; i <= 1; i += 0.01f)
            {
                while (goodPoints.Length > 1)
                {
                    PointF[] tempPoints = new PointF[goodPoints.Length - 1];
                    for (int j = 0; j < goodPoints.Length - 1; j++)
                        tempPoints[j] = FindPointBetween(
                            goodPoints[j], goodPoints[j + 1], i);
                    goodPoints = tempPoints;
                }
                graphics.DrawLine(pen, lastPoint, goodPoints[0]);
                lastPoint = goodPoints[0];
                goodPoints = points.ToArray();
            }
            pictureBox.Image = map;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (mod == Mod.Select)
            {
                if (points.Count == 0)
                    return;
                double minLength = map.Width + map.Height;
                PointF minPoint = points[0];
                foreach (var p in points)
                {
                    double length = Distance(e.Location, p);
                    if (length < minLength)
                    {
                        minPoint = p;
                        minLength = length;
                    }
                }
                ShowBezierSplinesAndPoints();
                graphics.DrawLine(penSelect,
                    new PointF(minPoint.X - 1, minPoint.Y - 1),
                    new PointF(minPoint.X + 1, minPoint.Y + 1));
                selectedPoint = minPoint;
                panel.Enabled = true;
                textBox1.Text = selectedPoint.X.ToString();
                textBox2.Text = selectedPoint.Y.ToString();
                pictureBox.Image = map;
            }
            else if (mod == Mod.Draw)
            {
                points.Add(new PointF(e.X, e.Y));
                if (points.Count <= 1)
                {
                    graphics.DrawLine(pen, new PointF(e.X - 1, e.Y - 1),
                        new PointF(e.X + 1, e.Y + 1));
                    pictureBox.Image = map;
                }
                else
                    CreateBezierSplines();
            }
        }

        private void DrawChanged(object sender, EventArgs e)
        {
            if (checkBoxDraw.Checked)
            {
                checkBoxDraw.Enabled = false;
                checkBoxSelect.Enabled = true;
                checkBoxSelect.Checked = false;

                mod = Mod.Draw;
                panel.Enabled = false;
            }
        }

        private void SelectChanged(object sender, EventArgs e)
        {
            if (checkBoxSelect.Checked)
            {
                checkBoxSelect.Enabled = false;
                checkBoxDraw.Enabled = true;
                checkBoxDraw.Checked = false;

                mod = Mod.Select;
                ShowBezierSplinesAndPoints();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int newX;
            if (Int32.TryParse(textBox1.Text, out newX)
                && newX >= 0 && newX < map.Width)
            {
                int index = points.IndexOf(selectedPoint);
                if (index >= 0)
                {
                    points[index] = new PointF((int)newX, points[index].Y);
                    selectedPoint = points[index];
                }
            }

            int newY;
            if (Int32.TryParse(textBox2.Text, out newY)
                && newY >= 0 && newY < map.Height)
            {
                int index = points.IndexOf(selectedPoint);
                if (index >= 0)
                {
                    points[index] = new PointF(points[index].X, (int)newY);
                    selectedPoint = points[index];
                }
            }
            ShowBezierSplinesAndPoints();
        }
    }
}