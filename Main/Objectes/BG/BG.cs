using Heirloom;
namespace Space{
    public class BG{
        private Image img;
        public BG(){
        }
        public void Spawn(GraphicsContext gfx, Rectangle rect){
            gfx.DrawImage(img, rect);
        }
        public void Canvifons (Nau nau,List <Image> BGrounds,int status){
            if (status == 0){
                img = BGrounds [0];
            }
            if (status == 1 || status == 4){
                img = BGrounds [1];
            }
            if (status == 2 && nau.newspawn < 4){
                img = BGrounds[2];
            }
            if (nau.newspawn >= 4){
                img = BGrounds[3];
            }
            if (status == 3){
                img = BGrounds[4];
            }
        }
    }
}