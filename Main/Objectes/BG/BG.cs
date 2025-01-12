using Heirloom;
using Heirloom.Desktop;
namespace Space;

class BG{
    private Image img;
    private Vector positionV;
    private Rectangle positionR;
    public BG(Rectangle pos, string imatge)
    {
        positionR = pos;
        img = new Image(imatge);
    }
    public void background(GraphicsContext gfx, Rectangle rect)
    {
        gfx.DrawImage(img, rect);
    }
}