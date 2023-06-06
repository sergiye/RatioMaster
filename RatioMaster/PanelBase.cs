using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RatioMaster {
  [DefaultEvent("Expanded"), DefaultProperty("Text")]
  public abstract class PanelBase : Panel {
    [Category("Property Changed"), Description("Occurs AllowCollapse property changed")]
    public event EventHandler AllowCollapseChanged;

    [Category("Property Changed"), Description("Occurs BevelStyle property changed")]
    public event EventHandler BevelStyleChanged;

    [Description("Occurs when the panel collapsed"), Category("Action")]
    public event EventHandler Collapsed;

    [Description("Occurs when the panel expanded"), Category("Action")]
    public event EventHandler Expanded;

    [Description("Occurs IsCollapse property changed"), Category("Property Changed")]
    public event EventHandler IsCollapseChanged;

    public PanelBase() {
      bevelStyle = BevelStyles.Flat;
      isCollapsed = false;
      fullHeight = 0;
      allowCollapse = true;
      SetStyle(ControlStyles.ContainerControl, true);
      SetStyle(ControlStyles.ResizeRedraw, true);
      SetStyle(ControlStyles.Selectable, true);
      SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    }

    public void Collapse() {
      fullHeight = Height;
      Height = GetCaptionHeight();
      isCollapsed = true;
      SetStyle(ControlStyles.FixedHeight, true);
      Invalidate();
      OnCollapsed(EventArgs.Empty);
      OnIsCollapseChanged(EventArgs.Empty);
    }

    public void Expand() {
      isCollapsed = false;
      Height = fullHeight;
      SetStyle(ControlStyles.FixedHeight, false);
      Invalidate();
      OnExpanded(EventArgs.Empty);
      OnIsCollapseChanged(EventArgs.Empty);
    }

    protected int GetCaptionHeight() {
      return Font.Height + 4;
    }

    protected virtual void OnAllowCollapseChanged(EventArgs e) {
      if (AllowCollapseChanged != null) {
        AllowCollapseChanged(this, e);
      }
    }

    protected virtual void OnBevelStyleChanged(EventArgs e) {
      if (BevelStyleChanged != null) {
        BevelStyleChanged(this, e);
      }
    }

    protected virtual void OnCollapsed(EventArgs e) {
      if (Collapsed != null) {
        Collapsed(this, e);
      }
    }

    protected virtual void OnExpanded(EventArgs e) {
      if (Expanded != null) {
        Expanded(this, e);
      }
    }

    protected virtual void OnIsCollapseChanged(EventArgs e) {
      if (IsCollapseChanged != null) {
        IsCollapseChanged(this, e);
      }
    }

    protected override void OnMouseDown(MouseEventArgs e) {
      if (allowCollapse && e.Y <= GetCaptionHeight()) {
        IsCollapsed = !IsCollapsed;
      }

      base.OnMouseDown(e);
    }

    protected override void OnResize(EventArgs e) {
      base.OnResize(e);
      if (isCollapsed) {
        Height = GetCaptionHeight();
      }
    }

    protected override void OnTextChanged(EventArgs e) {
      Invalidate();
      base.OnTextChanged(e);
    }

    [DefaultValue(true), Category("Behavior"),
     Description("Indicate whether the user can collapse/expand panel by clicking on caption")]
    public bool AllowCollapse {
      get => allowCollapse;
      set {
        if (value != allowCollapse) {
          allowCollapse = value;
          Invalidate();
          OnAllowCollapseChanged(EventArgs.Empty);
        }
      }
    }

    [Description("Style of panel's bevel"), Category("Appearance")]
    public BevelStyles BevelStyle {
      get => bevelStyle;
      set {
        if (bevelStyle != value) {
          bevelStyle = value;
          Invalidate();
          OnBevelStyleChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Layout"), Description("Control size in the expanded state")]
    public Size ExpandSize {
      get => !isCollapsed ? Size : new Size(Width, fullHeight);
      set {
        if (!isCollapsed) {
          Size = value;
        }
        else if (value != Size) {
          fullHeight = value.Height;
          Width = value.Width;
        }
      }
    }

    [DefaultValue(false), Description("Indicate whether the panel is collapsed now"), Category("Behavior")]
    public bool IsCollapsed {
      get => isCollapsed;
      set {
        if (isCollapsed != value) {
          if (value) {
            Collapse();
          }
          else {
            Expand();
          }
        }
      }
    }

    [Browsable(true)]
    public override string Text {
      get => base.Text;

      set {
        if (base.Text != value) {
          base.Text = value;
        }
      }
    }

    private bool allowCollapse;
    private BevelStyles bevelStyle;
    private int fullHeight;
    private bool isCollapsed;
  }

  public enum BevelStyles {
    None,
    Flat,
    Single,
    Double,
    Raised,
    Lowered,
    DoubleRaised,
    DoubleLowered,
    FrameRaised,
    FrameLowered
  }

  public enum PanelMarkerStyle {
    None,
    Arrow,
    PlusMinus
  }

  [ToolboxBitmap(typeof(MagneticPanel))]
  public class MagneticPanel : PanelBase {
    [Description("Occurs when the CaptionEndColor property changed"), Category("Property Changed")]
    public event EventHandler CaptionEndColorChanged;

    [Description("Occurs when the CaptionForeColor property changed"), Category("Property Changed")]
    public event EventHandler CaptionForeColorChanged;

    [Category("Property Changed"), Description("Occurs when the CaptionStartColor property changed")]
    public event EventHandler CaptionStartColorChanged;

    [Description("Occurs when the Marker property changed"), Category("Property Changed")]
    public event EventHandler MarkerChanged;

    public MagneticPanel() {
      marker = PanelMarkerStyle.Arrow;
      captionStartColor = Color.LightGray;
      captionEndColor = Color.LightGray;
      captionForeColor = Color.Black;
    }

    private void DrawBevel(Graphics g) {
      var num1 = GetCaptionHeight();
      var rectangle1 = DisplayRectangle;
      rectangle1.Size -= new Size(1, 1);
      if (BevelStyle != BevelStyles.None) {
        var point1 = rectangle1.Location;
        var point2 = rectangle1.Location + rectangle1.Size;
        var point3 = rectangle1.Location + rectangle1.Size;
        point3.Y = point1.Y + num1 - 1;
        var pen1 = SystemPens.ControlLightLight;
        var pen2 = SystemPens.ControlDark;
        var pen3 = Pens.Black;
        var pen4 = Pens.Black;
        switch (BevelStyle) {
          case BevelStyles.Flat:
            pen3 = pen2;
            pen4 = pen2;
            break;

          case BevelStyles.Single:
            pen3 = Pens.Black;
            pen4 = Pens.Black;
            break;

          case BevelStyles.Double:
            pen3 = Pens.Black;
            pen4 = Pens.Black;
            break;

          case BevelStyles.Raised:
            pen3 = pen1;
            pen4 = pen2;
            break;

          case BevelStyles.Lowered:
            pen3 = pen2;
            pen4 = pen1;
            break;

          case BevelStyles.DoubleRaised:
            pen3 = pen1;
            pen4 = pen2;
            break;

          case BevelStyles.DoubleLowered:
            pen3 = pen2;
            pen4 = pen1;
            break;

          case BevelStyles.FrameRaised:
            pen3 = pen1;
            pen4 = pen2;
            break;

          case BevelStyles.FrameLowered:
            pen3 = pen2;
            pen4 = pen1;
            break;
        }

        g.DrawLine(pen3, point1.X, point1.Y, point1.X, point2.Y);
        g.DrawLine(pen3, point1.X, point1.Y, point2.X, point1.Y);
        g.DrawLine(pen4, point1.X, point2.Y, point2.X, point2.Y);
        g.DrawLine(pen4, point2.X, point1.Y, point2.X, point2.Y);
        g.DrawLine(pen4, point1.X + 1, point3.Y, point3.X - 1, point3.Y);
        if (BevelStyle == BevelStyles.Double || BevelStyle == BevelStyles.DoubleRaised ||
            BevelStyle == BevelStyles.DoubleLowered || BevelStyle == BevelStyles.FrameLowered ||
            BevelStyle == BevelStyles.FrameRaised) {
          if (BevelStyle == BevelStyles.FrameLowered || BevelStyle == BevelStyles.FrameRaised) {
            var pen5 = pen3;
            pen3 = pen4;
            pen4 = pen5;
          }

          point1.X++;
          point1.Y++;
          point2.X--;
          point2.Y--;
          point3.X--;
          point3.Y--;
          g.DrawLine(pen3, point1.X, point1.Y, point1.X, point2.Y);
          g.DrawLine(pen3, point1.X, point1.Y, point2.X, point1.Y);
          g.DrawLine(pen4, point1.X, point2.Y, point2.X, point2.Y);
          g.DrawLine(pen4, point2.X, point1.Y, point2.X, point2.Y);
          g.DrawLine(pen4, point1.X + 1, point3.Y, point3.X - 1, point3.Y);
        }
      }
    }

    private void DrawCaption(Graphics g) {
      var color1 = captionStartColor;
      var color2 = captionEndColor;
      var color3 = captionForeColor;
      var font1 = Font;
      var num1 = GetCaptionHeight();
      var rectangle1 = DisplayRectangle;
      rectangle1.Height = num1;
      if (rectangle1.Height > 0 && rectangle1.Width > 0) {
        var brush1 = new LinearGradientBrush(rectangle1, color1, color2, LinearGradientMode.Horizontal);
        g.FillRectangle(brush1, rectangle1);
      }

      var num2 = 20;
      if (Marker == PanelMarkerStyle.None) {
        num2 = 5;
      }

      var point1 = new Point(num1 / 2, num1 / 2);
      point1.X += 3;
      if (Marker == PanelMarkerStyle.Arrow) {
        var path1 = new GraphicsPath();
        path1.StartFigure();
        if (IsCollapsed) {
          var pointArray1 = new[] {
            new Point(point1.X - 3, point1.Y - 6), new Point(point1.X - 3, point1.Y + 6),
            new Point(point1.X + 3, point1.Y)
          };
          path1.AddLines(pointArray1);
        }
        else {
          point1.Y += 2;
          var pointArray2 = new[] {
            new Point(point1.X - 6, point1.Y - 3), new Point(point1.X + 6, point1.Y - 3),
            new Point(point1.X, point1.Y + 3)
          };
          path1.AddLines(pointArray2);
        }

        path1.CloseFigure();
        g.FillPath(new SolidBrush(color3), path1);
      }

      if (Marker == PanelMarkerStyle.PlusMinus) {
        var rectangle2 = new Rectangle(point1.X - 4, point1.Y - 1, 9, 3);
        var rectangle3 = new Rectangle(point1.X - 1, point1.Y - 4, 3, 9);
        g.FillRectangle(new SolidBrush(color3), rectangle2);
        if (IsCollapsed) {
          g.FillRectangle(new SolidBrush(color3), rectangle3);
        }
      }

      g.DrawString(Text, font1, new SolidBrush(color3), num2, 2f);
    }

    protected virtual void OnCaptionEndColorChanged(EventArgs e) {
      if (CaptionEndColorChanged != null) {
        CaptionEndColorChanged(this, e);
      }
    }

    protected virtual void OnCaptionForeColorChanged(EventArgs e) {
      if (CaptionForeColorChanged != null) {
        CaptionForeColorChanged(this, e);
      }
    }

    protected virtual void OnCaptionStartColorChanged(EventArgs e) {
      if (CaptionStartColorChanged != null) {
        CaptionStartColorChanged(this, e);
      }
    }

    protected virtual void OnMarkerChanged(EventArgs e) {
      if (MarkerChanged != null) {
        MarkerChanged(this, e);
      }
    }

    protected override void OnPaint(PaintEventArgs pe) {
      base.OnPaint(pe);
    }

    protected override void OnPaintBackground(PaintEventArgs pe) {
      var num1 = GetCaptionHeight();
      var rectangle1 = new Rectangle(0, num1, DisplayRectangle.Width, DisplayRectangle.Height - num1);
      if (rectangle1.Height >= 0 && rectangle1.Width >= 0) {
        var container1 = pe.Graphics.BeginContainer();
        pe.Graphics.IntersectClip(rectangle1);
        base.OnPaintBackground(pe);
        pe.Graphics.EndContainer(container1);
      }

      DrawCaption(pe.Graphics);
      DrawBevel(pe.Graphics);
    }

    public bool ShouldSerializeCaptionEndColor() {
      return captionEndColor != Color.AntiqueWhite;
    }

    public bool ShouldSerializeCaptionForeColor() {
      return captionForeColor != Color.White;
    }

    public bool ShouldSerializeCaptionStartColor() {
      return captionStartColor != Color.SaddleBrown;
    }

    [Description("Start color of the caption gradient"), Category("Appearance")]
    public Color CaptionEndColor {
      get => captionEndColor;
      set {
        if (captionEndColor == value) return;
        captionEndColor = value;
        Invalidate();
        OnCaptionEndColorChanged(EventArgs.Empty);
      }
    }

    [Description("Start color of the caption gradient"), Category("Appearance")]
    public Color CaptionForeColor {
      get => captionForeColor;
      set {
        if (captionForeColor != value) {
          captionForeColor = value;
          Invalidate();
          OnCaptionForeColorChanged(EventArgs.Empty);
        }
      }
    }

    [Description("Start color of the caption gradient"), Category("Appearance")]
    public Color CaptionStartColor {
      get => captionStartColor;

      set {
        if (captionStartColor != value) {
          captionStartColor = value;
          Invalidate();
          OnCaptionStartColorChanged(EventArgs.Empty);
        }
      }
    }

    [DefaultValue(1), Category("Appearance"), Description("Marker shape style")]
    public PanelMarkerStyle Marker {
      get => marker;

      set {
        if (marker != value) {
          marker = value;
          Invalidate();
          OnMarkerChanged(EventArgs.Empty);
        }
      }
    }

    private Color captionEndColor;
    private Color captionForeColor;
    private Color captionStartColor;
    private PanelMarkerStyle marker;
  }
}