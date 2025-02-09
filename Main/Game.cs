using Heirloom.Desktop;
using Heirloom;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace Space
{
    public class Game
    {
      private Window window;
      private Score score;
      private Nau coet;
      private BG bg;
      private Boom explota;
      private Rectangle rect;
      private List <Alien> invaders = new();
      private List <Bala> bales = new ();
      private Dictionary <string , int> puntuacio {get;set;}= new ();
      private  string dificultat;
      private Vector shipvect;
      private Size midaalien;
      private Rectangle coetrectangle;
      private List <Image> AlienSkins = new();
      private List <Image> NauSkins = new();
      private List <Image> BalaSkins = new();
      private Image explosio;
      private List <Image> BGrounds = new();
      private int status = 0; // 0 inici, 1 tria nau, 2 joc, 3 ending mostant puntuacions, 4 registre persona, 5 calcul puntuacions;
      public Game(Window finestra)
      {
            window = finestra;
      }
      public void load (){
            score = new Score();
            // personalitzacio = new BG(rect,"personalitzacio.png");
            for (int i=1;i<=8;i++){
                  NauSkins.Insert(i-1,new Image ($"Objectes/Nau/Images/nau{i}.png"));
            }
            BalaSkins.Add(new Image ("Objectes/Bala/Images/Balanau.png"));
            BalaSkins.Add(new Image ("Objectes/Bala/Images/Balaalien.png"));
            AlienSkins.Add(new Image ("Objectes/Alien/Images/Alien1.png"));
            AlienSkins.Add(new Image ("Objectes/Alien/Images/Alien2-1.png"));
            AlienSkins.Add(new Image ("Objectes/Alien/Images/Alien2-2.png"));
            AlienSkins.Add(new Image ("Objectes/Alien/Images/Alien2-3.png"));
            explosio = new Image ("Objectes/Explosio/Images/Explosio.gif");
            BGrounds.Add(new Image ("Objectes/BG/Images/BGStart.png"));
            BGrounds.Add(new Image ("Objectes/BG/Images/BGPersonalitzacio.png"));
            BGrounds.Add(new Image ("Objectes/BG/Images/BGGame1.png"));
            BGrounds.Add(new Image ("Objectes/BG/Images/BGGame2.png"));
            BGrounds.Add(new Image ("Objectes/BG/Images/BGEnd.png"));
            coet = new Nau (BalaSkins[0]);
            bg = new BG ();

      }
      public void Run(GraphicsContext gfx, float dt){
            rect = new Rectangle(new Vector (0,0),window.Size);
            switch (status){
                  case 0:
                  Inici (gfx, dt);
                  break;
                  case 1:
                  nau (gfx, dt);
                  break;
                  case 2:
                  joc (gfx, dt);
                  break;
                  case 3:
                  Final (gfx, dt);
                  break;
                  case 4:
                  registre (gfx, dt);
                  break;
                  case 5:
                  puntuacions (gfx, dt);
                  break;
            }
      }
      public void Inici (GraphicsContext gfx, float dt){
            bg.Canvifons(coet, BGrounds ,status);
            bg.Spawn(gfx,rect);
            var text = "Space Invaders!";
            var text2 = "Press Space to start";
            var text3 = "Press Esc to exit";
            gfx.DrawText($"{text}",(rect.Width/2,rect.Height/2-300),Font.Default,180,TextAlign.Center);
            gfx.DrawText($"{text2}",(rect.Width/2,rect.Height/2-100),Font.Default,100,TextAlign.Center);
            gfx.DrawText($"{text3}",(rect.Width/2,rect.Height/2+100),Font.Default,60,TextAlign.Center);
            if (Input.CheckKey(Key.Space,ButtonState.Pressed)){
                  status = 1;
                  bg.Canvifons(coet, BGrounds ,status);
                  return;
            }
            if (Input.CheckKey(Key.Escape,ButtonState.Pressed)){
                  window.Close();
            }
      }
      public void nau (GraphicsContext gfx, float dt){
            bg.Spawn(gfx,rect);            
            var text = "Choose your ship!";
            var text2 = "Press LEFT and RIGHT arrow to change your ship";
            var text3 = "Press Space to select your ship";
            gfx.Color = Color.Black;
            gfx.DrawText(text,(rect.Width/2,rect.Height/2-250),Font.Default,180,TextAlign.Center);
            gfx.DrawText(text2,(rect.Width/2,rect.Height/2-100),Font.Default,100,TextAlign.Center);
            gfx.DrawText(text3,(rect.Width/2,rect.Height/2+280),Font.Default,30,TextAlign.Center);
            gfx.Color = Color.White;
            coet.Scroll(NauSkins);
            if (coet.numeronau==0){
                  coetrectangle = ((rect.Width/2-25,rect.Height/2+100),size:(50,100));
                  dificultat = "Dificultat Normal";
            } else {
                  dificultat = "Dificultat Dificil";
                  coetrectangle = ((rect.Width/2-62.5f,rect.Height/2+30),size:(125,250));
                  }

            gfx.DrawImage(coet.skin,coetrectangle);

            gfx.DrawText($"Nau {coet.i+1} - {dificultat}",(rect.Width/2,rect.Height/2), Font.Default,30,TextAlign.Center);
            if (Input.CheckKey(Key.Space,ButtonState.Pressed)){
                  shipvect = new Vector(rect.Width/2-(coet.posicioR.Width/2),rect.Height-250);
                  coet.vect(shipvect);
                  crearalien();
                  status = 4;
                  return;
            }
            if (Input.CheckKey(Key.Escape,ButtonState.Down)){
                  window.Close();
            }
      }
      public void joc (GraphicsContext gfx, float dt){
            rect = new Rectangle((0,0), window.Size); 
            bg.Spawn(gfx,rect);
            foreach (var alien in invaders){
                  if (alien.Shoot(coet)){
                        bales.Add(new Bala (1,BalaSkins[1],(alien.posicioR.X+(alien.posicioR.Width/2),alien.posicioR.Y+alien.posicioR.Height),coet.newspawn)); 
                  }
            }
            coet.Shoot();
            for (int i = bales.Count - 1; i >= 0; i--){
                  var bala = bales[i];
                  if (bala.TocarNau(coet)){
                        bales.Clear();
                        if (coet.HP - 1 == 0){
                        invaders.Clear();
                        status = 5;
                        return;
                        }
                        coet.HP--;
                        coet.vect(shipvect);
                        break;
                  }
            }
            for (int i = coet.dispars.Count - 1; i >= 0; i--) {
                  var bala = coet.dispars[i];
                  foreach (var alien in invaders) {
                        if (bala.TocarAlien(alien)){
                              coet.dispars.Remove(bala);
                              invaders.Remove(alien);
                              coet.score++;
                              break;
                        }
                  }
            }
            if (invaders.Count == 0) {
                  bales.Clear();
                  coet.dispars.Clear();
                  crearalien();
                  bg.Canvifons(coet,BGrounds,status);
            }
            foreach (var alien in invaders){
                  alien.Move(invaders,rect);
                  alien.Spawn(gfx);
            };
            for (int i = bales.Count - 1; i >= 0; i--){
                  var bala = bales[i];
                  if (!bala.Move(rect)){
                        bales.Remove(bala);
                        continue;
                  }
                  bala.Spawn(gfx);
            }
            coet.Move(rect);
            coet.Spawn(gfx,rect);

            var fps = gfx.CurrentFPS;
            var Sfps = Math.Round(fps).ToString();
            gfx.DrawText(Sfps,(15,8),Font.Default,30);
            gfx.DrawText($"HP: {coet.HP}",(rect.Width-50,10),Font.Default,30,TextAlign.Right);
            gfx.DrawText($"BALES: {5-coet.municio}/5",(rect.Width-50,45),Font.Default,30,TextAlign.Right);
            gfx.DrawText($"SCORE: {coet.score}",(rect.Width-50,80),Font.Default,30,TextAlign.Right);
      }
      public void Final (GraphicsContext gfx, float dt){
            bg.Spawn(gfx,rect);
            var text = "Game Over!";
            var text3 = "Press Space to restart";
            var text4 = "Press Esc to exit";
            var scoreboard = "SCOREBOARD";
            //---------------------------------
            var j = 0;
            foreach (var nom in puntuacio.OrderByDescending(x => x.Value)){
                  j++;
                  var puntuacioText = $"{nom.Key}: {nom.Value}";
                  gfx.DrawText(puntuacioText,(rect.Width/2,rect.Height/2-50+35*j),Font.Default,30,TextAlign.Center);
            }
            gfx.Color = Color.Yellow;
            gfx.DrawText(text,(rect.Width/2,rect.Height/2-400),Font.Default,200,TextAlign.Center);
            gfx.Color = Color.White;
            gfx.DrawText(text3,(rect.Width/2,rect.Height/2-200),Font.Default,100,TextAlign.Center);
            gfx.Color=Color.Black;
            gfx.DrawText(scoreboard,(rect.Width/2,rect.Height/2-100),Font.Default,100,TextAlign.Center);
            gfx.Color = Color.White;
            gfx.DrawText(text4,(rect.Width/2,rect.Height/2+300),Font.Default,30,TextAlign.Center);
            if (Input.CheckKey(Key.Space,ButtonState.Pressed)){
                  status = 1;
                  bg.Canvifons(coet, BGrounds ,status);
                  coet.dispars.Clear();
                  coet.newspawn = 0;
                  coet.score = 0;
                  return;
            }
            if (Input.CheckKey(Key.Escape,ButtonState.Pressed)){
                  window.Close();
            }

      }
      public void registre (GraphicsContext gfx, float dt){
            //crear un registre per a la puntuacio on la persona posa el seu nom.
            bg.Spawn(gfx,rect);
            score.setname();
            gfx.DrawText(score.name,(window.Width/2,window.Height/2),Font.Default,200,TextAlign.Center);
            gfx.DrawImage(coet.skin,((window.Width-100,window.Height-120),size:(50,100)));
            if (Input.CheckKey(Key.Enter,ButtonState.Down)){
                  status = 2;
                  bg.Canvifons(coet, BGrounds ,status);
                  return;
            }
      }
      public void puntuacions (GraphicsContext gfx, float dt){
            //passem del txt a la llista de puntuacions.
            if (puntuacio.Count == 0){
                  File.ReadAllLines("Objectes/Score/score.txt").Select(line => line.Split('-')).ToList().ForEach(parts => puntuacio[parts[0]] = int.Parse(parts[1]));
            }
            if (!puntuacio.ContainsKey(score.name)){ // Si el jugador no esta a la llista de puntuacions, s'afegira.
                  puntuacio.Add(score.name,coet.score);
            } else if (coet.score > puntuacio[score.name]){ // Si el jugador ja esta a la llista de puntuacions, es comprovara si la seva puntuacio es mes gran que la que ja te.
                  puntuacio[score.name] = coet.score;
            }               
            File.WriteAllLines("Objectes/Score/score.txt", [.. puntuacio.OrderByDescending(x => x.Value).Select(x => $"{x.Key}-{x.Value}")]);
            status=3;
            bg.Canvifons(coet, BGrounds ,status);
      }
      public void crearalien(){
            coet.newspawn++;
            midaalien = new Size (100,100);
            int columnes = (int)Math.Floor(rect.Width / (100 + 30));
            int files = 3;
            for (int fila = 0; fila < files ; fila++){
                  for (int columna = 0; columna < columnes ; columna++){
                        var newpos = new Rectangle ((30*(columna+1)+(100*columna),100*(fila+1)+10*(fila+1)), midaalien);
                        if (rect.Contains(newpos)){
                              invaders.Add(new Alien(AlienSkins[0],newpos));
                        }
                  }
            }
            bg.Canvifons(coet,BGrounds,status);
      }
    }
}