using Heirloom;
namespace Space;

public class Bala{
    private Image img;
    private int type;
    private Vector posicioV;
    private Rectangle posicioR;
    private int fase;
    public Bala (int tipus, Image image , Vector vector, int ronda)
    {
        type = tipus;
        img = image;
        posicioV = vector;
        posicioR = new Rectangle (posicioV,img.Size);
        fase = ronda;
    }

    public void Move (GraphicsContext gfx){
        if (type==0){
            posicioV.X -= 5+fase;
        }
        else {
            posicioV.X += 3+fase-(fase/2);
        }
        gfx.DrawImage(img,posicioV);
    }
    public bool TocarAlien (Alien alien){
        if (posicioR.Overlaps(alien.posicioR)){
            return true;
        }
        return false;
    }
    public bool TocarNau (Nau coet){
        if (posicioR.Overlaps(coet.posicioR)){
            return true;
        }
        return false;
    }
}