using Heirloom;
namespace Space;

public class Nau : Shoot_Objects{
    public int HP {get;set;}
    public int speed {get;set;} = 5; 
    public int numeronau {get;set;} = 0;
    public int score {get;set;}
    public int municio {get;set;}
    public int newspawn {get;set;} = 0;
    private Image imatgebala;
    private Vector posicioV;
    public Rectangle posicioR {get;set;}
    public Image skin {get;set;}
    public int i {get;set;} = 0; 
    public List <Bala> dispars {get;set;}
    public Nau (Rectangle rect, Image img, Image imgbala)
    {
        imatgebala = imgbala;
        posicioR=rect;
        skin = img;
    }
    public void Scroll (List <Image> img){
        skin = img[i];
        if (Input.CheckKey(Key.Right,ButtonState.Down)){
            i++;
        }
        if (Input.CheckKey(Key.Left,ButtonState.Down)){
            i--;
        }
        if (i<0){
            i=img.Count-1;
        }
        if (i>img.Count){
            i=0;
        }
        if (i<4){
            numeronau = 0;
        } else {
            numeronau = 1;
        }
    }
    public void vect (Vector vector){
        posicioV = vector;
    }
    public void velocitat (){
        speed = 5*(2-numeronau);
    }
    public void Move (Rectangle rect){
        var newpos = new Rectangle(posicioV, skin.Size);
        if (Input.CheckKey(Key.Right,ButtonState.Down)){
            newpos.X += newpos.X + speed;
        }
        if (Input.CheckKey(Key.Left,ButtonState.Down)){
            newpos.X -= newpos.X + speed;
        }
        if (rect.Contains(newpos)){
            posicioV.X=newpos.X;
        }
    }
    public void Spawn (GraphicsContext gfx){
        gfx.DrawImage(skin, posicioV);
        municio = dispars.Count();
    }
    public bool Shoot (){
        if (Input.CheckKey(Key.Up,ButtonState.Down)){
            if (dispars.Count<5){
                var bala = new Bala (0, imatgebala , posicioV , newspawn);
                dispars.Add(bala);
                return true;
            }
        }
        return false;
    }
}