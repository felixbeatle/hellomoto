using SDL2;
using testSDL;
using static SDL2.SDL;
using static SDL2.SDL_ttf;
using static SDL2.SDL_image;
using static SDL2.SDL_mixer;
namespace TestSDL
{

    class Program
    { 
       


        static void Main(string[] args)

        {

            bool Continue = true;

           Game.Setup();
            SDL_WarpMouseInWindow(Game.Window, -1, -1);

        
            while (Continue)
            {
                Game.TakeEvents();

               
                int mouseX, mouseY;
                SDL_GetMouseState(out mouseX, out mouseY);
                bool mouseInsideWindow =
                    (mouseX >= 0 && mouseX < Game.Window) &&
                    (mouseY >= 0 && mouseY < Game.Window);

                if (mouseInsideWindow)
                {
                   
                    SDL_ShowCursor(0);
                }
                else
                {
                    
                    SDL_ShowCursor(1);
                }

                Game.Move();
                Game.Addball();
                Game.Rendertext();
                Game.Blockbreaker();
                Game.Render();
               
                
            }

            Console.WriteLine("Initialization success!!!");

        }

    }
}