using Heirloom;

namespace Space;
//ALIEN BASE HP 1
class Alien{
    public int hp {get; set;}
    private Image img;
    public Alien(string imatge)
    {
        img = new Image (imatge);
        hp = 1;
    }
}