using Heirloom;
using Heirloom.Geometry;
namespace Space;

public class Bala{
    private Image img;
    private int type;
    private Vector posicioV;
    public Rectangle posicioR {get;set;}
    private int fase;
    private Size size;
    public Bala (int tipus, Image image , Vector vector, int ronda)
    {
        type = tipus;
        img = image;
        posicioV = vector;
        fase = ronda;
        size = (type == 0) ? (10, 15) : (20, 25);
    }
    public bool Move (Rectangle rect){
        if (type==0){
            posicioV.Y -= 5+fase;
        }
        else {
            posicioV.Y += 3+fase-(fase/2);
        }
        posicioR = new Rectangle(posicioV, size);
        return !OutOfWindow(rect);
    }
    public void Spawn(GraphicsContext gfx){
        gfx.DrawImage(img,posicioR);
    }
    public bool TocarAlien (Alien alien){
        return posicioR.Overlaps(alien.posicioR);
    } 
    public bool TocarNau (Nau coet){
        return posicioR.Overlaps(coet.posicioR);
    }
    public bool OutOfWindow (Rectangle rect){
        return !rect.Contains(posicioR);
    }
}