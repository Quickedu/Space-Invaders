using Heirloom;
namespace Space{
    public class BG{
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
        public void Canvifons (Score score){
            if (score.newspawn == 2){
                img = new Image("fons2.png");
            }
            if (score.newspawn == 5){
                img = new Image("fons3.png");
            }
        }
    }
}