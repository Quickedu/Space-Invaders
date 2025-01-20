using Heirloom.Desktop;
using Heirloom;

namespace Space
{
    public class Program
    {
        private static Window window;
        private static Score score;
        private static Nau coet;
        private static BG space_bckground;
        private static BG inici;
        private static BG personalitzacio;
        private static BG final;
        private static Boom explota;
        private static Alien alien;
        private static Rectangle rect;
        private static List <Alien> invaders = new();
        private static List <Bala> bales = new ();
        private static Dictionary <string , int> puntuacio {get;set;}= new ();
        private static string dificultat;
        private static string nom;
        private static int status = 0; // 0 inici, 1 tria nau, 2 joc, 3 ending, 4 registre persona, 5 puntuacions;
        static void Main (){
            Application.Run( () => {
                window = new Window ("SpaceInvaders!") { IsResizable = false };
                window.Maximize();
                coet = new Nau (rect);
                score = new Score();
                var loop = GameLoop.Create(window.Graphics, OnUpdate);
            });

            static void OnUpdate (GraphicsContext gfx, float dt){
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
            static void Inici (GraphicsContext gfx, float dt){
                inici.background(gfx,rect);
                Thread.Sleep(500);
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
                Thread.Sleep(500);
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
                    crearalien();
                    status = 4;
                    return;
                }
                if (Input.CheckKey(Key.Escape,ButtonState.Down)){
                    window.Close();
                }
            }
            static void joc (GraphicsContext gfx, float dt){
                rect = new Rectangle((0,0), window.Size); 
                space_bckground.background(gfx,rect);
                foreach (var alien in invaders){

                }
                coet.mou(rect);
                coet.dispara();
                foreach (var bala in bales){
                    if (bala.TocarNau (coet)){
                        bales.Remove(bala);
                        if (coet.HP -1 == 0){
                            status = 5;
                            return;
                        }
                        coet.HP--;
                    }
                }
                foreach (var bala in coet.dispars){
                    foreach (var alien in invaders){
                        if (bala.TocarAlien(alien)){
                            bales.Remove(bala);
                            if (alien.hp -1 == 0){
                                invaders.Remove(alien);
                            } else {
                                alien.hp--;
                            }
                        }
                    }
                }
                foreach (var alien in invaders){
                    alien.move(invaders,rect);
                    alien.spawn(gfx);
                };
                coet.spawn(gfx);

                var fps = gfx.CurrentFPS;
                var Sfps = Math.Round(fps).ToString();
                gfx.DrawText(Sfps,(15,8),Font.Default,30);
                gfx.DrawText($"HP: {coet.HP}",(window.Height,window.Width),Font.Default,30,TextAlign.Right);
                gfx.DrawText($"BALES: {5-coet.municio}/5",(window.Height,window.Width),Font.Default,30,TextAlign.Right);
            }
            static void Final (GraphicsContext gfx, float dt){
                final.background(gfx,rect);
                var text = "Game Over!";
                var text3 = "Press Space to restart";
                var text4 = "Press Esc to exit";
                //---------------------------------
                foreach (var i in puntuacio.OrderByDescending(x => x.Value).Take(10)){ //agafem els 10 més elevats.
                    var puntuacioText = $"{i.Key}: {i.Value}";
                    for (int j = 1; j <= 10; j++){    //BUCLE PER ESCRIURE LA PUNTUACIO DE TOTS ELS JUGADORS GUARDATS DINS EL TXT.
                        gfx.DrawText(puntuacioText,(50+5*j,window.Width),Font.Default,30,TextAlign.Center);
                    }
                }
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
            static void registre (GraphicsContext gfx, float dt){
                //crear un registre per a la puntuacio on la persona posa el seu nom.
                score.setname();
                gfx.DrawText(score.name,(window.Height,window.Width),Font.Default,30,TextAlign.Center);
                if (Input.CheckKey(Key.Enter,ButtonState.Down)){
                    status = 2;
                    return;
                }
            }
            static void puntuacions (GraphicsContext gfx, float dt){
                //passem del txt a la llista de puntuacions.
                File.ReadAllLines("./Objectes/Score/score.txt").Select(line => line.Split('-')).ToList().ForEach(parts => puntuacio[parts[0]] = int.Parse(parts[1]));
                if (!puntuacio.ContainsKey(score.name)){ // Si el jugador no esta a la llista de puntuacions, s'afegira.
                    puntuacio.Add(score.name,coet.score);
                    return;
                }
                if (coet.score > puntuacio[score.name]){ // Si el jugador ja esta a la llista de puntuacions, es comprovara si la seva puntuacio es mes gran que la que ja te.
                    puntuacio[score.name] = coet.score;
                }               
                File.WriteAllLines("./Objectes/Score/score.txt", [.. puntuacio.OrderByDescending(x => x.Value).Select(x => $"{x.Key}-{x.Value}").Take(10)]);
                status=3;
            }
            static void crearalien(){
                score.newspawn++;
                var i = 0;
                while (!invaders[i].posicioR.Overlaps(rect)){
                    if (coet.numeronau==0){
                        var alien = new Alien("alien1.png",new Rectangle((40+(40*i),40), new Size(40,40)));
                        invaders.Add(alien);
                        i++;
                    } else {
                    invaders.Add(alien);
                    i++;
                    }
                }
            }
        }
    }
}



// El txt s'anira actualitzant cada vegada que la puntuacio augmenti (kill). Max 10 saves i ordre max a min.