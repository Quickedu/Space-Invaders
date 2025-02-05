using Heirloom;
namespace Space;
public class Alien : Shoot_Objects{
    public int hp {get; set;}
    public Rectangle posicioR {get;set;}
    public Vector posicioV {get;set;}
    private Image img;
    private int direccio = 1;
    private int velocitat = 5;
    private Random rnd = new ();
    private int probabilitat;
    private int disparo;
    public Alien(Image imatge, Rectangle rectangle)
    {
        posicioR = rectangle;
        img = imatge;
    }
    public bool Shoot (){
        probabilitat = rnd.Next(0,51);
        if (probabilitat <= disparo)return true;
        return false;
    }
    public bool Costat (List <Alien> invaders, Vector newpos, Rectangle rect){
        var nourectangle = new Rectangle (newpos,img.Size);
        foreach (var alien in invaders){
            if (alien==this) continue;
            if (nourectangle.Overlaps(alien.posicioR)||!rect.Contains(nourectangle)){
                return true;
            }
        }
        return false;
    }
    public void Move (List <Alien> invaders, Rectangle rect){
        Vector newpos = (0,posicioV.Y);
        newpos.X = posicioV.X+velocitat*direccio;
        if(Costat(invaders,newpos,rect)){
            newpos.X = posicioV.X+(velocitat*direccio*-1);
            if (Costat(invaders,newpos,rect)){
                return;
            }
            direccio*=-1;
        }
        posicioV = (newpos.X,posicioV.Y);
    }
    public void Spawn (GraphicsContext gfx){
        gfx.DrawImage (img,posicioV);
    }
}