using Heirloom;

class Nau{
    public int HP {get;set;}
    private Vector posicioV;
    public Rectangle posicioR {get;set;}
    public Image skin;
    public Nau (Rectangle rect, string imatge)
    {
        skin = new Image (imatge);
        posicioR=rect;
    }
}