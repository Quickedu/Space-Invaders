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
    public Nau (Rectangle rect, Image imgbala)
    {
        imatgebala = imgbala;
        posicioR=rect;
    }
    public void Scroll (List <Image> img){
        if (Input.CheckKey(Key.Right,ButtonState.Pressed)){
            i++;
        }
        if (Input.CheckKey(Key.Left,ButtonState.Pressed)){
            i--;
        }
        if (i<0){
            i=img.Count-1;
        }
        if (i>img.Count-1){
            i=0;
        }
        if (i<4){
            numeronau = 0;
        } else {
            numeronau = 1;
        }
        skin = img[i];
    }
    public void vect (Vector vector){
        posicioV = vector;
    }
    public void velocitat (){
        speed = 5*(2-numeronau);
    }
    public void Move (Rectangle rect){
        var newpos = new Rectangle(posicioV, size:(30,50));
        if (Input.CheckKey(Key.Right,ButtonState.Down)){
            newpos.X += newpos.X + speed;
        }
        if (Input.CheckKey(Key.Left,ButtonState.Down)){
            newpos.X -= newpos.X + speed;
        }
        if (rect.Contains(newpos)){
            posicioR=newpos;
        }
    }
    public void Spawn (GraphicsContext gfx){
        gfx.DrawImage(skin, posicioR);
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