namespace Space;
using Heirloom;
public class Score{
      public List <string> input{get;set;} = ["|"];
      public string name {get;set;}
      private int i = 0;
      private int ii = 0;
      public int newspawn {get;set;} = 0;
      public Score(){ 
      }
      public void setname(){ //segurament cal posar totes les tecles amb input sobre la sting name. fleches R i L serveixen per poder correr per l'array.
            if (Input.CheckKey(Key.A,ButtonState.Pressed)){
                  if (i < input.Count-1){
                        input.Insert(i,"A");
                        i++;
                        return;
                  }
                  input.Add("A");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.B,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"A");
                        i++;
                        return;
                  }
                  input.Add("B");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.C,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"C");
                        i++;
                        return;
                  }
                  input.Add("C");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.D,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"D");
                        i++;
                        return;
                  }
                  input.Add("D");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.E,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"E");
                        i++;
                        return;
                  }
                  input.Add("E");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.F,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"F");
                        i++;
                        return;
                  }
                  input.Add("F");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.G,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"G");
                        i++;
                        return;
                  }
                  input.Add("G");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.H,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"H");
                        i++;
                        return;
                  }
                  input.Add("H");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.I,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"I");
                        i++;
                        return;
                  }
                  input.Add("I");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.J,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"J");
                        i++;
                        return;
                  }
                  input.Add("J");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.K,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"K");
                        i++;
                        return;
                  }
                  input.Add("K");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.L,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"L");
                        i++;
                        return;
                  }
                  input.Add("L");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.M,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"M");
                        i++;
                        return;
                  }
                  input.Add("M");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.N,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"N");
                        i++;
                        return;
                  }
                  input.Add("N");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.O,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"O");
                        i++;
                        return;
                  }
                  input.Add("O");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.P,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"P");
                        i++;
                        return;
                  }
                  input.Add("P");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.Q,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"Q");
                        i++;
                        return;
                  }
                  input.Add("Q");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.R,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"R");
                        i++;
                        return;
                  }
                  input.Add("R");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.S,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"S");
                        i++;
                        return;
                  }
                  input.Add("S");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.T,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"T");
                        i++;
                        return;
                  }
                  input.Add("T");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.U,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"U");
                        i++;
                        return;
                  }
                  input.Add("U");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.V,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"V");
                        i++;
                        return;
                  }
                  input.Add("V");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.W,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"W");
                        i++;
                        return;
                  }
                  input.Add("W");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.X,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"X");
                        i++;
                        return;
                  }
                  input.Add("X");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.Y,ButtonState.Pressed)){
                  if (i < input.Count-1){
                        input.Insert(i,"Y");
                        i++;
                        return;
                  }
                  input.Add("Y");
                  i++;
            }
            if (Input.CheckKey(Key.Z,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i,"Z");
                        i++;
                        return;
                  }
                  input.Add("Z");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.Space,ButtonState.Pressed)){
                  if (i< input.Count-1){
                        input.Insert(i," ");
                        i++;
                        return;
                  }
                  input.Add(" ");
                  i++;
                  return;
            }
            if (Input.CheckKey(Key.Backspace,ButtonState.Pressed)){
                  if (i>0){
                        input.RemoveAt(i-1);
                        i--;
                        ii--;
                  }
            }
            if (Input.CheckKey(Key.Right,ButtonState.Pressed)){
                  if (i < input.Count-1){
                        i++;
                  }
            }
            if (Input.CheckKey(Key.Left, ButtonState.Pressed)){
                  if (i > 0){
                        i--;
                  }
            }
            if (i!=ii){
                  input.RemoveAt(ii);
                  input.Insert(i,"|");
            }
            ii = i;          
            nametostring();
      }
      public void nametostring(){
            name = "";
            foreach (var lletra in input){
                  name += lletra;
            }
      }
}