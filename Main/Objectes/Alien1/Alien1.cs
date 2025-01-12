using Heirloom;

namespace Space;
//ALIEN BASE HP 2
class Alien1{
    private int hp;
    private Vector posicioV;
    private Rectangle posicioR;
    private Image img;
    public Alien1(Rectangle rect, string imatge)
    {
        posicioR = rect;
        img = new Image (imatge);
        hp = 2;
    }
}