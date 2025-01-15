namespace Space;
using Heirloom;
public class Score{
      public List <string> input{get;set;}
      public string name {get;set;}
      public Score(){ 
      }
      public void setname(){ //segurament cal posar totes les tecles amb input sobre la sting name. fleches R i L serveixen per poder correr per l'array.
            foreach (var key in Enum.GetValues(typeof(Key))){
                  if (Input.CheckKey(Key.A,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.B,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.C,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.D,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.E,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.F,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.G,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.H,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.I,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.J,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.K,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.L,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.M,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.N,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.O,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.P,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.Q,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.R,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.S,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.T,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.U,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.V,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.W,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.X,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.Y,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
                  if (Input.CheckKey(Key.Z,ButtonState.Down)){
                        input.Add(key.ToString());
                  }
            }
      }
      public void nametostring(){
            foreach (var i in input){
                  name += i;
            }
      }
}