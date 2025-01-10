using Heirloom.Desktop;
using Heirloom;
using Heirloom.Sound;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
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
        private static BalaAlien balaalien;
        private static Alien alienbasic;
        private static Alien1 alienmid;
        private static Alien2 alienhard;
        private static Rectangle rect;
        private static List <Alien> invaders = new();
        private static List <Bala> bales = new ();
        private static int status = 0; // 0 inici, 1 tria nau, 2 joc, 3 ending
        static void Main (){
            Application.Run( () => {
                window = new Window ("SpaceInvaders!") { IsResizable = false };
                window.Maximize();
                coet = new Nau (rect, "asd");
                var loop = GameLoop.Create(window.Graphics, OnUpdate);
            });

            static void OnUpdate (GraphicsContext gfx, float dt){
                switch (status){
                    case 0:
                    inici (gfx, dt);
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

                }
            }
            static void inici (GraphicsContext gfx, float dt){

            }
            static void nau (GraphicsContext gfx, float dt){

            }
            static void joc (GraphicsContext gfx, float dt){
            rect = new Rectangle(new Vector (0,0), 50,50);
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
            coet.spawn(gfx);
            var fps = gfx.CurrentFPS;
            var Sfps = Math.Round(fps).ToString();
            gfx.DrawText(Sfps,(15,8),Font.Default,30);
            gfx.DrawText($"HP: {coet.HP}",(window.Height,window.Width),Font.Default,30,TextAlign.Right);
            }
            static void final (GraphicsContext gfx, float dt){

            }
        }
    }
}