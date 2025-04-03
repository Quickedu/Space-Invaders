using Heirloom.Desktop;
using Heirloom;

namespace Space
{
    public class Program
    {
        private static Window window;
        public static Game game {get;set;}

        static void Main (){
            Application.Run( () => {
                window = new Window ("SpaceInvaders!") { IsResizable = false };
                window.Maximize();
                game = new Game(window);
                game.load();
                var loop = GameLoop.Create(window.Graphics, OnUpdate);
                loop.Start();
            });

            static void OnUpdate (GraphicsContext gfx, float dt){
                game.Run(gfx,dt);
            }
        }
    }
}




