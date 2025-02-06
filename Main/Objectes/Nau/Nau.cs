using Heirloom;
namespace Space;

public class Nau{
    public int HP {get;set;}
    public int speed {get;set;} = 5; 
    public int numeronau {get;set;} = 0;
    public int score {get;set;}
    public int municio {get;set;}
<<<<<<< HEAD
    public int newspawn {get;set;}
=======
    private Image imatgebala;
>>>>>>> 71080d7021e12fa02bda02025a6508af771479ec
    private Vector posicioV;
    public Rectangle posicioR {get;set;}
    public Image skin {get;set;}
    private string [] pathskin = {"nau1.png","nau2.png","nau3.png","nau4.png","nau5.png","nau6.png","nau7.png","nau8.png"};
    private int i = 0;
    public List <Bala> dispars {get;set;}
    public Nau (Rectangle rect)
    {
        imatgebala = new Image ("Balanau.png");
        posicioR=rect;
        skin = new Image (pathskin[0]);
    }
    public void scroll (){
        skin = new Image (pathskin[i]);
        if (Input.CheckKey(Key.Right,ButtonState.Down)){
            i++;
        }
        if (Input.CheckKey(Key.Left,ButtonState.Down)){
            i--;
        }
        if (i<0){
            i=pathskin.Length-1;
        }
        if (i>pathskin.Length){
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
    public void mou (Rectangle rect){
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
    public void spawn (GraphicsContext gfx){
        gfx.DrawImage(skin, posicioV);
        municio = dispars.Count();
    }
    public void dispara (){
        if (Input.CheckKey(Key.Up,ButtonState.Down)){
            if (dispars.Count<5){
<<<<<<< HEAD
                var bala = new Bala ("BalaNau.png",a,posicioV);
=======
                var bala = new Bala ("BalaNau.png", imatgebala , posicioV);
>>>>>>> 71080d7021e12fa02bda02025a6508af771479ec
                dispars.Add(bala);
                return;
            }
        }
    }
}