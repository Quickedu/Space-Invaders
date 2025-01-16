using System.Security.Cryptography.X509Certificates;
using Heirloom;
using Microsoft.VisualBasic;
using Space;

class Bala{
    private Image img;
    private string input;
    private Vector posicioV;
    private Rectangle posicioR;
    public Bala (string imatge, Vector vector)
    {
        img = new Image (imatge);
        input = imatge;
        posicioV = vector;
        posicioR = new Rectangle (posicioV,img.Size);
    }

    public void Move (GraphicsContext gfx){
        if (input=="BalaNau.png"){
            posicioV.X -= 5;
        }
        else {
            posicioV.X += 3;
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