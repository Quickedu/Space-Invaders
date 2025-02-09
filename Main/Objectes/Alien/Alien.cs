using Heirloom;
using Heirloom.Geometry;
namespace Space;
public class Alien{    
    public int hp {get; set;}
    public Rectangle posicioR {get;set;}
    public Vector posicioV {get;set;}
    private Image img;
    private int direccio = 1;
    private int velocitat = 5;
    private Random rnd = new ();
    private int probabilitat;
    private float disparo = 0;
    public Alien(Image imatge, Rectangle rectangle)
    {
        posicioR = rectangle;
        img = imatge;
        posicioV = (posicioR.X, posicioR.Y);
    }
    public bool Shoot (Nau coet){
        probabilitat = rnd.Next(0,600);
        return probabilitat <= disparo+coet.newspawn*1.25f;
    }
    public bool Costat (List <Alien> invaders, Rectangle newpos, Rectangle rect){
        if (!rect.Contains(newpos))return true;
        foreach (var alien in invaders){
            if (alien==this) continue;
            if (newpos.Overlaps(alien.posicioR)){
                return true;
            }
        }
        return false;
    }
    public void Move (List <Alien> invaders, Rectangle rect){
        var newpos = posicioR;
        newpos.X += velocitat*direccio;
        if(Costat(invaders,newpos,rect)){
            direccio*=-1;
        }
        posicioR = newpos;
    }
    public void Spawn (GraphicsContext gfx){
        gfx.DrawImage (img,posicioR);
    }
}