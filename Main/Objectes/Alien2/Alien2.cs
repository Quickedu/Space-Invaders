using Heirloom;

namespace Space;
//ALIEN BASE HP 3
class Alien2{
    private int hp;
    private Image img;
    public Alien2(string imatge)
    {
        img = new Image (imatge);
        hp = 3;
    }
}