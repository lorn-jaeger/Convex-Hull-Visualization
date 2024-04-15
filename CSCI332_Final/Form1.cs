using System.ComponentModel;
using System.Drawing;

namespace CSCI332_Final
{
    public partial class Form1 : Form
    {
        int tickSpeed = 100;
        int numPoints = 20;

        bool JarvisMarch = true;
        bool GrahamScan = false;
        bool QuickHull = false;

        bool clicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void JarvisMarch_Button_Click(object sender, EventArgs e)
        {
            JarvisMarch = true;
            GrahamScan = false;
            QuickHull = false;
        }

        private void GrahamScan_Button_Click(object sender, EventArgs e)
        {
            JarvisMarch = false;
            GrahamScan = true;
            QuickHull = false;

        }

        private void QuickHull_Click(object sender, EventArgs e)
        {
            JarvisMarch = false;
            GrahamScan = false;
            QuickHull = true;
        }

        private void TickSpeed_TextChanged(object sender, EventArgs e)
        {
            try { tickSpeed = Int32.Parse(TickSpeed.Text); } catch { }
        }

        private void NumPoints_TextChanged(object sender, EventArgs e)
        {
            try { numPoints = Int32.Parse(NumPoints.Text); } catch { }
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            if (clicked == false)
            {
                DrawHull(numPoints, tickSpeed);
            }
        }

        private void DrawHull(int n, int tick)
        {
            clicked = true;

            Graphics form = CreateGraphics();

            List<Point> points = GeneratePoints(n, 125, 750, 100, 400);  // magic numbers based on screen size
            DrawPoints(points, form);

            if (JarvisMarch)
                DrawJarvisMarch(points, tick, form);
            if (GrahamScan)
                DrawGrahamScan(points, tick, form);
            if (QuickHull)
                DrawQuickHull(points, tick, form);

            clicked = false;
        }

        private List<Point> GeneratePoints(int n, int x_min, int x_max, int y_min, int y_max)
        {
            var points = new List<Point>();
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                points.Add(new Point(rand.Next(x_min, x_max), rand.Next(y_min, y_max)));
            }

            return points;
        }

        private void DrawPoints(List<Point> points, Graphics form)
        {
            SolidBrush myBrush = new SolidBrush(Color.Black);

            foreach (Point point in points)
            {
                form.FillEllipse(myBrush, point.X - 4, point.Y - 4, 10, 10);
            }
        }
        private double Distance(Point p1, Point p2)
        {
            double dy = Math.Pow((p2.Y - p1.Y), 2);
            double dx = Math.Pow((p2.X - p1.X), 2);

            return Math.Sqrt(dy + dx);
        }

        private int Orientation(Point p1, Point p2, Point p3)
        {
            int orientation = (p3.Y - p2.Y) * (p2.X - p1.X) - (p2.Y - p1.Y) * (p3.X - p2.X);

            int counterClockwise = 1;
            int clockwise = -1;
            int coLinear = 0;

            if (orientation > 0)    
                return counterClockwise;
            if (orientation < 0)    
                return clockwise;
            else
                return coLinear;
        }

        private void DrawJarvisMarchFrame(List<Point> points, List<Point> hull, Point next, Graphics form, int n)
        {
            form.Clear(Color.White);

            DrawPoints(points, form);

            Pen black = new Pen(Color.Black, 2);
            Pen blue = new Pen(Color.Blue, 2);

            for (int i = 1; i < hull.Count; i++)
            {
                form.DrawLine(black, hull[i - 1], hull[i]);
            }

            if (n == hull.Count-1) 
            {
                form.DrawLine(black, hull.Last(), hull.First());
            } 
            else
            {
                form.DrawLine(black, hull.Last(), next);
            }

        }

        private async void DrawJarvisMarch(List<Point> points, int speed, Graphics form)
        {
            List<Point> hull = new List<Point>();

            Point onhull = points.MinBy(arr => arr.X);

            while (true)
            {
                hull.Add(onhull);
                Point next = points.First();

                foreach (Point point in points)
                {
                    DrawJarvisMarchFrame(points, hull, point, form, points.Count);
                    await Task.Delay(speed);
                    int orientation = Orientation(onhull, next, point);
                    if (next == onhull || orientation == 1 || (orientation == 0 && Distance(onhull, point) > Distance(onhull, next)))
                        next = point;
                }
                onhull = next;
                if (onhull == hull.First())
                {
                    hull.Add(hull.First());
                    DrawJarvisMarchFrame(points, hull, hull.First(), form, points.Count);
                    break;
                }

            }
        }

        private static List<Point> PolarAngleSort(Point origin, List<Point> points)
        {
            return points.OrderBy(p => Math.Atan2(p.Y - origin.Y, p.X - origin.X)).ToList();
        }

        public void DrawGrahamScanFrame(List<Point> points, Stack<Point> hull, int tick, Graphics form) 
        {
            form.Clear(Color.BlanchedAlmond);
            Pen black = new Pen(Color.Black, 2);

            DrawPoints(points, form);

            List<Point> result = hull.ToList();

            for (int i = 1; i < result.Count; i++)
            {
                form.DrawLine(black, result[i], result[i - 1]);
            }
        }

        public async void DrawGrahamScan(List<Point> points, int tick, Graphics form)
        {
            Point onhull = points.OrderBy(p => p.Y).ThenBy(p => p.X).First();
            points = PolarAngleSort(onhull, points);
            Stack<Point> hull = new Stack<Point>();

            foreach (Point p in points)
            {
                while (hull.Count > 1 && Orientation(hull.ElementAt(1), hull.Peek(), p) <= 0)
                {
                    hull.Pop();
                    DrawGrahamScanFrame(points, hull, tick, form);
                    await Task.Delay(tick);
                }
                hull.Push(p);
                DrawGrahamScanFrame(points, hull, tick, form);
                await Task.Delay(tick);

            }
            hull.Push(onhull);
            DrawGrahamScanFrame(points, hull, tick, form);

        }

        public void SplitPoints(List<Point> points, out List<Point> above, out List<Point> below)
        {
            if (points == null || points.Count < 2)
            {
                above = new List<Point>();
                below = new List<Point>();
                return;
            }

            Point leftmost = points.OrderBy(p => p.X).First();
            Point rightmost = points.OrderBy(p => p.X).Last();

            double m = (rightmost.Y - leftmost.Y) / (rightmost.X - leftmost.X);
            double b = leftmost.Y - m * leftmost.X;

            above = new List<Point>();
            below = new List<Point>();

            foreach (Point p in points)
            {
                double lineY = m * p.X + b;

                if (p.Y > lineY)
                {
                    above.Add(p);
                }
                else if (p.Y < lineY)
                {
                    below.Add(p);
                }
            }
        }


        private Point FindFurthestPointFromLine(List<Point> points, Point linePoint1, Point linePoint2)
        {
            // Calculate line coefficients A, B, and C from points
            int A = linePoint2.Y - linePoint1.Y;
            int B = linePoint1.X - linePoint2.X;
            int C = A * linePoint1.X + B * linePoint1.Y;

            double maxDistance = 0;
            Point furthestPoint = new Point();

            foreach (var point in points)
            {
                double distance = Math.Abs(A * point.X + B * point.Y + C) / Math.Sqrt(A * A + B * B);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    furthestPoint = point;
                }
            }

            return furthestPoint;
        }
        

        private async void DrawQuickHull(List<Point> points, int speed, Graphics form)
        {
            List<Point> hull = new List<Point>();

            Point left = points.MinBy(arr => arr.X);
            Point right = points.MaxBy(arr => arr.X);

            SplitPoints(points, out List<Point> above, out List<Point> below);

            above = FindQuickHull(above, left, right);
            below = FindQuickHull(below, right, left);
            

        }

        private List<Point> FindQuickHull(List<Point> points, Point P, Point Q)
        {
            if (points.Count == 0)
                return points;

            Point C = FindFurthestPointFromLine(points, P, Q);

            return points;
        }

        // Unused events
        private void Form1_Load(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e) { }
    }
}
