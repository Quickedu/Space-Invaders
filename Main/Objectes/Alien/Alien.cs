using Heirloom;
namespace Space;
public class Alien{
    public int hp {get; set;}
    public Rectangle posicioR {get;set;}
    public Vector posicioV {get;set;}
    private Image img;
    private int direccio = 1;
    private int velocitat = 5;
    public Alien(string imatge, Rectangle rectangle)
    {
        posicioR = rectangle;
        img = new Image(imatge);
        if (imatge == "alien1.png") hp = 1;
        else hp = 1;
    }

    public bool costat (List <Alien> invaders, Vector newpos, Rectangle rect){
        var nourectangle = new Rectangle (newpos,img.Size);
        foreach (var alien in invaders){
            if (alien==this) continue;
            if (nourectangle.Overlaps(alien.posicioR)||!rect.Contains(nourectangle)){
                return true;
            }
        }
        return false;
    }
    public void move (List <Alien> invaders, Rectangle rect){
        Vector newpos = (0,posicioV.Y);
        newpos.X = posicioV.X+velocitat*direccio;
        if(costat(invaders,newpos,rect)){
            newpos.X = posicioV.X+(velocitat*direccio*-1);
            if (costat(invaders,newpos,rect)){
                return;
            }
            direccio*=-1;
        }
        posicioV = (newpos.X,posicioV.Y);
    }
    public void spawn (GraphicsContext gfx){
        gfx.DrawImage (img,posicioV);
    }
}