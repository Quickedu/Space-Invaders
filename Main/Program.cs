using Heirloom.Desktop;
using Heirloom;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
namespace Space
{
    class Program
    {
        private static Window window;
        private static Nau coet;
        private static BG space_bckground;
        private static BG inici;
        private static BG personalitzacio;
        private static BG final;
        private static Boom explota;
        private static Bala bala;
        private static BalaAliens balaalien;
        private static Alien alienbasic;
        private static Alien1 alienmid;
        private static Alien2 alienhard;
        private static Rectangle rect;
        private static List <Alien> invaders = new();
        private static List <Bala> bales = new ();
        private static Dictionary <string , int> puntuacio = new ();
        private static string dificultat;
        private static int status = 0; // 0 inici, 1 tria nau, 2 joc, 3 ending, 4 registre persona;
        static void Main (){
            Application.Run( () => {
                window = new Window ("SpaceInvaders!") { IsResizable = false };
                window.Maximize();
                coet = new Nau (rect, "asd");
                var loop = GameLoop.Create(window.Graphics, OnUpdate);
            });

            static void OnUpdate (GraphicsContext gfx, float dt){
                rect = new Rectangle(new Vector (0,0),window.Size);
                switch (status){
                    case 0:
                    Inici (gfx, dt, window , rect);
                    break;
                    case 1:
                    nau (gfx, dt);
                    break;
                    case 2:
                    joc (gfx, dt);
                    break;
                    case 3:
                    final (gfx, dt);
                    break;
                    case 4:
                    registre (gfx, dt);
                    break;

                }
            }
            static void Inici (GraphicsContext gfx, float dt, Window window, Rectangle rect){
                inici.background(gfx,rect);
                Thread.Sleep(333);
                var text = "Space Invaders!";
                var text2 = "Press Space to start";
                var text3 = "Press Esc to exit";
                gfx.DrawText(text,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                gfx.DrawText(text2,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                gfx.DrawText(text3,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                if (Input.CheckKey(Key.Space,ButtonState.Pressed)){
                    status = 1;
                    return;
                }
                if (Input.CheckKey(Key.Escape,ButtonState.Pressed)){
                    window.Close();
                }
                Thread.Sleep(666);
            }
            static void nau (GraphicsContext gfx, float dt){
                var text = "Choose your ship!";
                var text2 = "Press Right and Left arrow to change your ship";
                var text3 = "Press Space to select your ship";
                gfx.DrawText(text,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                gfx.DrawText(text2,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                gfx.DrawText(text3,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                coet.scroll();
                if (coet.numeronau==0){
                    dificultat = "Dificultat Normal";
                } else {dificultat = "Dificultat Dificil";}
                gfx.DrawText(dificultat,(window.Height,window.Width), Font.Default,30,TextAlign.Center);
                if (Input.CheckKey(Key.Space,ButtonState.Pressed)){
                    var shipvect = new Vector(rect.Width/2,rect.Height-50);
                    coet.vect(shipvect);
                    status = 4;
                    return;
                }
            }
            static void joc (GraphicsContext gfx, float dt){
            space_bckground.background(gfx,rect);

            coet.mou(rect);
            coet.dispara();
            foreach (var bala in bales){
                foreach (var alien in invaders){
                    if (bala.tocar(alien)){
                        if (alien.hp -1 == 0){
                            invaders.Remove(alien);
                            return;
                        } else {
                            alien.hp--;
                            return;
                        }
                    }
                }
            }
            foreach (var alien in invaders){
                alien.move(rect);
                alien.spawn(rect);
            };
            coet.spawn(rect,gfx);

            var fps = gfx.CurrentFPS;
            var Sfps = Math.Round(fps).ToString();
            gfx.DrawText(Sfps,(15,8),Font.Default,30);
            gfx.DrawText($"HP: {coet.HP}",(window.Height,window.Width),Font.Default,30,TextAlign.Right);
            }
            static void final (GraphicsContext gfx, float dt){
                final.background(gfx,rect);
                var text = "Game Over!";
                var text3 = "Press Space to restart";
                var text4 = "Press Esc to exit";
                //---------------------------------
                foreach (var i in puntuacio){
                    if (puntuacio. ){
                        var text2 = $"You: {i.Value}";
                        gfx.DrawText(text2,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                    }
                    if (coet.score > i.Value){
                        i.value=coet.score;
                        puntuacio.Add("You",coet.score);
                    }
                    var text2 = $"{i.Key}: {i.Value}";
                    gfx.DrawText(puntuacio.ToString(),(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                }
                //--------------------------------- BUCLE PER ESCRIURE LA PUNTUACIO DE TOTS ELS JUGADORS GUARDATS DINS EL TXT.
                gfx.DrawText(text,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                gfx.DrawText(text3,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                gfx.DrawText(text4,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                if (Input.CheckKey(Key.Space,ButtonState.Pressed)){
                    status = 1;
                    return;
                }
                if (Input.CheckKey(Key.Escape,ButtonState.Pressed)){
                    window.Close();
                }
            }
            static void registre (){
                var score = new Score(); //crear un registre per a la puntuacio on la persona posa el seu nom.
                score.setname();
                
            }
        }
    }
}



// El txt s'anira actualitzant cada vegada que la puntuacio augmenti (kill). Max 10 saves i ordre max a min.