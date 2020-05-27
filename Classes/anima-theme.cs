using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

internal static class Helpers
{
    public static SizeF Size;

    public static Point MiddlePoint(Graphics G, string TargetText, Font TargetFont, Rectangle Rect)
    {
        Size = G.MeasureString(TargetText, TargetFont);
        return new Point((int)Rect.Width / 2 - (int)Size.Width / 2, (int)Rect.Height / 2 - (int)Size.Height / 2);
    }
}

public class AnimaTextBox : Control
{
    private Graphics G;
    private TextBox _T;

    private TextBox T
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _T;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_T != null)
            {
                _T.Enter -= _T_Enter;
                _T.KeyPress -= _T_KeyPress;
                _T.Leave -= _T_Leave;
                _T.TextChanged -= _T_TextChanged;
            }

            _T = value;
            if (_T != null)
            {
                _T.Enter += _T_Enter;
                _T.KeyPress += _T_KeyPress;
                _T.Leave += _T_Leave;
                _T.TextChanged += _T_TextChanged;
            }
        }
    }

    private void _T_TextChanged(object sender, EventArgs e)
    {
        OnTextChanged(EventArgs.Empty);
    }

    private void _T_Leave(object sender, EventArgs e)
    {
        AnimatingT2 = new Thread(UndoAnimation) { IsBackground = true };
        AnimatingT2.Start();
    }

    private void _T_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Numeric)
        {
            if ((int)(e.KeyChar) != 8)
            {
                if ((int)(e.KeyChar) < 48 | (int)(e.KeyChar) > 57)
                    e.Handled = true;
            }
        }
    }

    private void _T_Enter(object sender, EventArgs e)
    {
        if (!Block)
        {
            AnimatingT = new Thread(DoAnimation) { IsBackground = true };
            AnimatingT.Start();
        }
    }

    private Thread AnimatingT;
    private Thread AnimatingT2;

    private int[] RGB = new[] { 45, 45, 48 };
    private int RGB1 = 45;
    private bool Block;

    public bool Dark { get; set; }

    public bool Numeric { get; set; }

    public new string Text
    {
        get
        {
            return T.Text;
        }
        set
        {
            base.Text = value;
            T.Text = value;
            Invalidate();
        }
    }

    public int MaxLength
    {
        get
        {
            return T.MaxLength;
        }
        set
        {
            T.MaxLength = value;
            Invalidate();
        }
    }

    public bool UseSystemPasswordChar
    {
        get
        {
            return T.UseSystemPasswordChar;
        }
        set
        {
            T.UseSystemPasswordChar = value;
            Invalidate();
        }
    }

    public bool MultiLine
    {
        get
        {
            return T.Multiline;
        }
        set
        {
            T.Multiline = value;
            Helpers.Size = new Size(T.Width + 2, T.Height + 2);
            Invalidate();
        }
    }

    public bool ReadOnly
    {
        get
        {
            return T.ReadOnly;
        }
        set
        {
            T.ReadOnly = value;
            Invalidate();
        }
    }

    public AnimaTextBox()
    {
        DoubleBuffered = true;

        T = new TextBox() { BorderStyle = BorderStyle.None, ForeColor = Color.FromArgb(200, 200, 200), BackColor = Color.FromArgb(55, 55, 58), Location = new Point(6, 5), Multiline = false };

        Controls.Add(T);
    }

    protected override void CreateHandle()
    {
        if (Dark)
        {
            RGB = new[] { 42, 42, 45 };
            RGB1 = 45;
            T.BackColor = Color.FromArgb(45, 45, 48);
        }
        else
        {
            RGB = new[] { 70, 70, 70 };
            RGB1 = 70;
            T.BackColor = Color.FromArgb(55, 55, 58);
        }
        base.CreateHandle();
    }

    protected override void OnEnter(EventArgs e)
    {
        T.Select();
        base.OnEnter(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        G = e.Graphics;

        if (Enabled)
        {
            if (Dark)
            {
                G.Clear(Color.FromArgb(45, 45, 48));

                using (Pen Border = new Pen(Color.FromArgb(RGB[0], RGB[1], RGB[2])))
                {
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }
            else
            {
                G.Clear(Color.FromArgb(55, 55, 58));

                using (Pen Shadow = new Pen(Color.FromArgb(42, 42, 45)))
                using (Pen Border = new Pen(Color.FromArgb(RGB[0], RGB[1], RGB[2]))
)
                {
                    G.DrawRectangle(Border, new Rectangle(1, 1, Width - 3, Height - 3));
                    G.DrawRectangle(Shadow, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }
        }
        else
        {
            G.Clear(Color.FromArgb(50, 50, 53));
            T.BackColor = Color.FromArgb(50, 50, 53);

            using (Pen Border = new Pen(Color.FromArgb(42, 42, 45)))
            using (Pen Shadow = new Pen(Color.FromArgb(66, 66, 69))
)
            {
                e.Graphics.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                e.Graphics.DrawRectangle(Shadow, new Rectangle(1, 1, Width - 3, Height - 3));
            }
        }

        base.OnPaint(e);
    }

    protected override void OnResize(EventArgs e)
    {
        if (MultiLine)
        {
            T.Size = new Size(Width - 7, Height - 7); Invalidate();
        }
        else
        {
            T.Size = new Size(Width - 8, Height - 15); Invalidate();
        }
        base.OnResize(e);
    }

    private void DoAnimation()
    {
        while (RGB[2] < 204 && !Block)
        {
            RGB[1] += 1;
            RGB[2] += 2;

            Invalidate();
            Thread.Sleep(5);
        }
    }

    private void UndoAnimation()
    {
        Block = true;

        while (RGB[2] > RGB1)
        {
            RGB[1] -= 1;
            RGB[2] -= 2;

            Invalidate();
            Thread.Sleep(5);
        }

        Block = false;
    }
}

public class AnimaCheckBox : CheckBox
{
    private Graphics G;

    private Thread AnimatingT;
    private Thread AnimatingT2;

    readonly private int[] RGB = new[] { 36, 36, 39 };

    private bool Block;

    public bool Radio { get; set; }

    public bool Caution { get; set; }

    private const string CheckedIcon = "iVBORw0KGgoAAAANSUhEUgAAAAsAAAAKCAMAAABVLlSxAAAASFBMVEUlJSYuLi8oKCmlpaXx8fGioqJoaGjOzs8+Pj/k5OTu7u5LS0zIyMiBgYKFhYXo6OhUVFWVlZW7u7t+fn7h4eE5OTlfX1+YmJn8uq7eAAAAA3RSTlMAAAD6dsTeAAAACXBIWXMAAABIAAAASABGyWs+AAAAO0lEQVQI12NgwAKYWVhhTDYWdkYok4OTixvCYGDiYeEFM/n4BQRZhCDywiz8XCKiDDAOixjcPGFxDCsASakBdDYGvzAAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTYtMTItMTRUMTI6MDM6MjktMDY6MDB4J65tAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE2LTEyLTE0VDEyOjAzOjI5LTA2OjAwCXoW0QAAAABJRU5ErkJggg==";

    public AnimaCheckBox()
    {
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 9);
        ForeColor = Color.FromArgb(200, 200, 200);
        SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        G = e.Graphics;
        G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        G.Clear(BackColor);

        using (SolidBrush Background = new SolidBrush(Color.FromArgb(38, 38, 41)))
        {
            G.FillRectangle(Background, new Rectangle(0, 0, 16, 16));
        }

        using (Pen Border = new Pen(Color.FromArgb(RGB[0], RGB[1], RGB[2])))
        {
            G.DrawRectangle(Border, new Rectangle(0, 0, 16, 16));
        }

        using (SolidBrush Fore = new SolidBrush(ForeColor))
        {
            G.DrawString(Text, Font, Fore, new Point(22, 0));
        }

        if (Checked)
        {
            using (Image Mark = Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(CheckedIcon))))
            {
                G.DrawImage(Mark, new Point(2, 3));
            }
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        if (!Block)
        {
            AnimatingT = new Thread(DoAnimation) { IsBackground = true };
            AnimatingT.Start();
        }

        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        AnimatingT2 = new Thread(UndoAnimation) { IsBackground = true };
        AnimatingT2.Start();

        base.OnMouseLeave(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (Radio)
        {
            foreach (AnimaCheckBox C in Parent.Controls.OfType<AnimaCheckBox>())
            {
                if (C.Radio)
                    C.Checked = false;
            }
        }

        base.OnMouseUp(e);
    }

    private void DoAnimation()
    {
        if (Caution)
        {
            while (RGB[2] < 130 && !Block)
            {
                RGB[1] += 1;
                RGB[2] += 1;

                Invalidate();
                Thread.Sleep(4);
            }
        }
        else
            while (RGB[2] < 204 && !Block)
            {
                RGB[1] += 1;
                RGB[2] += 2;

                Invalidate();
                Thread.Sleep(4);
            }
    }

    private void UndoAnimation()
    {
        Block = true;

        if (Caution)
        {
            while (RGB[2] > 42)
            {
                RGB[1] -= 1;
                RGB[2] -= 1;

                Invalidate();
                Thread.Sleep(4);
            }
        }
        else
            while (RGB[2] > 42)
            {
                RGB[1] -= 1;
                RGB[2] -= 2;

                Invalidate();
                Thread.Sleep(4);
            }

        Block = false;
    }
}

public class AnimaButton : Button
{
    private Graphics G;

    private Thread HoverAnim, CHoverAnim, DownAnimationT;

    readonly private int[] RGB = new[] { 42, 42, 45 };

    private Point Loc = new Point();
    private Size RSize = new Size();

    private bool Block;

    private bool Animate;

    public Point ImageLocation { get; set; }

    public Size ImageSize { get; set; } = new Size(14, 14);

    public AnimaButton()
    {
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 9);
        ForeColor = Color.FromArgb(200, 200, 200);
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        ImageLocation = new Point(Width / 2 - 7, 6);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        G = e.Graphics;

        G.Clear(BackColor);

        using (SolidBrush Background = new SolidBrush(Color.FromArgb(55, 55, 58)))
        {
            G.FillRectangle(Background, new Rectangle(0, 0, Width - 1, Height - 1));
        }

        if (Animate)
        {
            using (SolidBrush Background = new SolidBrush(Color.FromArgb(66, 66, 69)))
            {
                G.FillEllipse(Background, new Rectangle(Loc.X, -30, RSize.Width, 80));
            }
        }

        using (Pen Border = new Pen(Color.FromArgb(RGB[0], RGB[1], RGB[2])))
        {
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
        }

        if (Image != null)
            G.DrawImage(Image, new Rectangle(ImageLocation, ImageSize));
        else
            using (SolidBrush Fore = new SolidBrush(ForeColor))
            {
                G.DrawString(Text, Font, Fore, Helpers.MiddlePoint(G, Text, Font, new Rectangle(0, 0, Width - 1, Height - 1)));
            }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        if (!Block)
        {
            HoverAnim = new Thread(DoAnimation) { IsBackground = true };
            HoverAnim.Start();
        }

        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        CHoverAnim = new Thread(UndoAnimation) { IsBackground = true };
        CHoverAnim.Start();

        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        DownAnimationT = new Thread(() => DoBackAnimation(e.Location)) { IsBackground = true };
        DownAnimationT.Start();

        base.OnMouseDown(e);
    }

    private void DoBackAnimation(Point P)
    {
        Loc = P;
        RSize = new Size();

        Animate = true; Invalidate();

        while (RSize.Width < Width * 3)
        {
            Loc.X -= 1;
            RSize.Width += 2;
            Thread.Sleep(4);
            Invalidate();
        }

        Animate = false; Invalidate();
    }

    private void DoAnimation()
    {
        while (RGB[2] < 204 && !Block)
        {
            RGB[1] += 1;
            RGB[2] += 2;

            Invalidate();
            Thread.Sleep(5);
        }
    }

    private void UndoAnimation()
    {
        Block = true;

        while (RGB[2] > 45)
        {
            RGB[1] -= 1;
            RGB[2] -= 2;

            Invalidate();
            Thread.Sleep(5);
        }

        Block = false;
    }
}

public class Renderer : ToolStripRenderer
{
    public event PaintMenuBackgroundEventHandler PaintMenuBackground;

    public delegate void PaintMenuBackgroundEventHandler(object sender, ToolStripRenderEventArgs e);

    public event PaintMenuBorderEventHandler PaintMenuBorder;

    public delegate void PaintMenuBorderEventHandler(object sender, ToolStripRenderEventArgs e);

    public event PaintMenuImageMarginEventHandler PaintMenuImageMargin;

    public delegate void PaintMenuImageMarginEventHandler(object sender, ToolStripRenderEventArgs e);

    public event PaintItemCheckEventHandler PaintItemCheck;

    public delegate void PaintItemCheckEventHandler(object sender, ToolStripItemImageRenderEventArgs e);

    public event PaintItemImageEventHandler PaintItemImage;

    public delegate void PaintItemImageEventHandler(object sender, ToolStripItemImageRenderEventArgs e);

    public event PaintItemTextEventHandler PaintItemText;

    public delegate void PaintItemTextEventHandler(object sender, ToolStripItemTextRenderEventArgs e);

    public event PaintItemBackgroundEventHandler PaintItemBackground;

    public delegate void PaintItemBackgroundEventHandler(object sender, ToolStripItemRenderEventArgs e);

    public event PaintItemArrowEventHandler PaintItemArrow;

    public delegate void PaintItemArrowEventHandler(object sender, ToolStripArrowRenderEventArgs e);

    public event PaintSeparatorEventHandler PaintSeparator;

    public delegate void PaintSeparatorEventHandler(object sender, ToolStripSeparatorRenderEventArgs e);

    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        PaintMenuBackground?.Invoke(this, e);
    }

    protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
    {
        PaintMenuImageMargin?.Invoke(this, e);
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        PaintMenuBorder?.Invoke(this, e);
    }

    protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
        PaintItemCheck?.Invoke(this, e);
    }

    protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
    {
        PaintItemImage?.Invoke(this, e);
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        PaintItemText?.Invoke(this, e);
    }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        PaintItemBackground?.Invoke(this, e);
    }

    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
        PaintItemArrow?.Invoke(this, e);
    }

    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        PaintSeparator?.Invoke(this, e);
    }
}