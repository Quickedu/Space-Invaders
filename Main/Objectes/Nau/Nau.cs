using Heirloom;
namespace Space;

public class Nau : Shoot_Objects{
    public int HP {get;set;}
    public int speed {get;set;} = 7; 
    public int numeronau {get;set;} = 0;
    public int score {get;set;}
    public int municio {get;set;}
    public int newspawn {get; set;} = 0;
    private Image imatgebala;
    private Vector posicioV;
    public Rectangle posicioR {get;set;}
    public Image skin {get;set;}
    private Size size;
    public int i {get;set;} = 0; 
    public List <Bala> dispars {get;set;} = new();
    public Nau (Image imgbala)
    {
        imatgebala = imgbala;
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
            size = (50,100);
            HP=5;  

        } else {
            numeronau = 1;
            size = (100,200);
            HP=3;
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
        var newpos = new Rectangle(posicioV, size);
        if (Input.CheckKey(Key.Right,ButtonState.Down)){
            newpos.X += speed;
        }
        if (Input.CheckKey(Key.Left,ButtonState.Down)){
            newpos.X -= speed;
        }
        if (rect.Contains(newpos)){
            posicioV.X=newpos.X;
        }
        posicioR = (posicioV,size);
    }
    public void Spawn (GraphicsContext gfx, Rectangle rect){
        gfx.DrawImage(skin, (posicioV,size));
        municio = 5-dispars.Count();
        foreach (var bala in dispars){  
            if (!bala.Move(rect)){
                dispars.Remove(bala);
                break;
            };
            bala.Spawn(gfx);
        }
    }
    public Vector Getvect(){
        return posicioV;
    }
    public bool Shoot (){
        if (Input.CheckKey(Key.Up,ButtonState.Pressed)){
            if (dispars.Count<5){
                var bala = new Bala (0, imatgebala , (posicioR.X+(posicioR.Width/2),posicioR.Y), newspawn);
                dispars.Add(bala);
                return true;
            }
        }
        return false;
    }
}