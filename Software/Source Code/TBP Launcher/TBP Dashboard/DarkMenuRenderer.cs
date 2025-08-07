using System.Drawing;
using System.Windows.Forms;

public class DarkMenuRenderer : ToolStripProfessionalRenderer
{
    private Color baseColor = Color.FromArgb(51, 51, 51);
    private Color hoverColor = Color.FromArgb(72, 72, 72);
    private Color borderColor = Color.FromArgb(51, 51, 51);
    private Color textColor = Color.White;

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        Color fillColor = e.Item.Selected ? hoverColor : baseColor;
        e.Graphics.FillRectangle(new SolidBrush(fillColor), e.Item.ContentRectangle);
    }

    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        e.Graphics.Clear(baseColor);
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        e.TextColor = textColor;
        base.OnRenderItemText(e);
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        using (var pen = new Pen(borderColor))
        {
            Rectangle rect = new Rectangle(Point.Empty, e.ToolStrip.Size - new Size(1, 1));
            e.Graphics.DrawRectangle(pen, rect);
        }
    }

    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        int y = e.Item.ContentRectangle.Top + e.Item.ContentRectangle.Height / 2;
        e.Graphics.DrawLine(new Pen(Color.DimGray), e.Item.ContentRectangle.Left + 2, y, e.Item.ContentRectangle.Right - 2, y);
    }

    protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
    {
        base.OnRenderItemImage(e); // Use default image drawing
    }

    protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
    {
        // Fill image margin (left bar in submenus) with dark color
        Rectangle marginRect = e.AffectedBounds;
        using (SolidBrush b = new SolidBrush(baseColor))
        {
            e.Graphics.FillRectangle(b, marginRect);
        }
    }
}