namespace Space;
using Heirloom;

public class Alien2 : Alien{
      private Image img;
      private Rectangle positionR;
      public Alien2(Image imatge, Rectangle rectangle) : base (imatge, rectangle)
      {
            img = imatge;
            positionR = rectangle;   
      }
}