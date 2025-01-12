namespace Space;
using Heirloom;
public class Score{
      private string name;
      public Score(){

      }
      public void setname(){ //segurament cal posar totes les tecles amb input sobre la sting name. fleches R i L serveixen per poder correr per l'array.
            foreach (var key in Enum.GetValues(typeof(Key))){
                  if (Input.){
                        name += key.ToString();
                  }
            }
      }
}