using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using static SDL2.SDL;
using static SDL2.SDL_ttf;
using static SDL2.SDL_image;
using static SDL2.SDL_mixer;
namespace testSDL
{
    static class Game
    {
        static Game()
        {

           
        }

        static bool blockHit1 = false;
        static bool blockHit2 = false;
        static bool blockHit3 = false;
        static bool blockHit4 = false;
        static bool blockHit5 = false;
        static bool eventtrue = true;

        static int ballSpeed = 5;
        static int ballVelocityX = 0;
        static int ballVelocityY = ballSpeed;
        public static IntPtr Window;
        public static IntPtr Renderer;
        static float impactX = Theball.Ball.x + Theball.Ball.w / 2;
        static float impactY = Theball.Ball.y + Theball.Ball.h;
        static int levelcounter = 1;
        static Random r = new Random();
        static int level = 1;
        static IntPtr hitSound;
        

       

       
        static SDL_Rect block1 = new SDL_Rect
        {
            x = r.Next(20, 100),
            y = r.Next(0, 75),
            w = 50,
            h = 30
        };
        static SDL_Rect block2 = new SDL_Rect
        {
            x = r.Next(129, 257),
            y = r.Next(0, 75),
            w = 50,
            h = 30,
        }; static SDL_Rect block3 = new SDL_Rect
        {
            x = r.Next(275, 390),
            y = r.Next(0, 75),
            w = 50,
            h = 30
        };

        static SDL_Rect block4 = new SDL_Rect
        {
            x = r.Next(400, 520),
            y = r.Next(0, 75),
            w = 30,
            h = 30,
        }; static SDL_Rect block5 = new SDL_Rect
        {
            x = r.Next(530, 600),
            y = r.Next(0, 75),
            w = 20,
            h = 30
        };
        static SDL_Rect textRect = new SDL_Rect
        { x = 450, y = 430, w = 50, h = 100 };


        public static void TakeEvents()
        {
            while (SDL_PollEvent(out SDL_Event e) == 1)
            {



                switch (e.type)
                {
                    case SDL_EventType.SDL_KEYDOWN:
                        Restartinput(e.key.keysym);
                        break;


                    default:
                        break;

                }
            }
        }

        public static void Move()
        {


            SDL_SetRenderDrawColor(Renderer, 0, 255, 0, 255);


            SDL_RenderFillRect(Renderer, ref Paddle.my_rectangle);

            int mouseX, mouseY;
            SDL_GetMouseState(out mouseX, out mouseY);


            if (mouseX > 0 && mouseX < 640 - Paddle.my_rectangle.w)
            {


                Paddle.my_rectangle.x = mouseX;
            }




        }
        public static void Addball()
        {
            SDL_SetRenderDrawColor(Renderer, 0, 100, 100, 255);
            SDL_RenderFillRect(Renderer, ref Theball.Ball);
            
            Theball.Ball.x += ballVelocityX;
            Theball.Ball.y += ballVelocityY;

            float impactX = Theball.Ball.x + Theball.Ball.w / 2;
            float impactY = Theball.Ball.y + Theball.Ball.h;
            if (Theball.Ball.x + Theball.Ball.w > Paddle.my_rectangle.x && Theball.Ball.x < Paddle.my_rectangle.x +  Paddle.my_rectangle.w &&
                Theball.Ball.y + Theball.Ball.h >    Paddle.my_rectangle.y && Theball.Ball.y < Paddle.my_rectangle.y + Paddle.my_rectangle.h)
            {
                ballVelocityY = -ballSpeed;
                Mix_PlayChannel(-1, hitSound, 0);

                if (impactX < (Paddle.my_rectangle.x + Paddle.my_rectangle.w / 2) - 30)
                {
                    ballVelocityX = -ballSpeed;
                }
                else if (impactX > (Paddle.my_rectangle.x +  Paddle.my_rectangle.w / 2) + 30)
                {
                    ballVelocityX = ballSpeed;
                }
                else
                {
                    ballVelocityY = -ballSpeed;


                }
            }
            if (Theball.Ball.x + Theball.Ball.w > block1.x &&    Theball.Ball.x < block1.x + block1.w &&
                Theball.Ball.y + Theball.Ball.h > block1.y && Theball.Ball.y < block1.y + block1.h && blockHit1 == false)
            {
                ballVelocityY = -ballSpeed;
                Mix_PlayChannel(-1, hitSound, 0);

                if (impactX < block1.x + block1.w / 2)
                {
                    ballVelocityX = -ballSpeed;
                }
                else
                {
                    ballVelocityX = ballSpeed;
                }
                blockHit1 = true;
            }
            if (Theball.Ball.x + Theball.Ball.w > block2.x && Theball.Ball.x < block2.x + block2.w &&
               Theball.Ball.y + Theball.Ball.h > block2.y && Theball.Ball.y < block2.y + block2.h && blockHit2 == false)
            {
                ballVelocityY = -ballSpeed;
                Mix_PlayChannel(-1, hitSound, 0);

                if (impactX < block2.x + block2.w / 2)
                {
                    ballVelocityX = -ballSpeed;
                }
                else
                {
                    ballVelocityX = ballSpeed;
                }
                blockHit2 = true;
            }
            if (Theball.Ball.x + Theball.Ball.w > block3.x && Theball.Ball.x < block3.x + block3.w &&
               Theball.Ball.y + Theball.Ball.h > block3.y && Theball.Ball.y < block3.y + block3.h && blockHit3 == false)
            {
                ballVelocityY = -ballSpeed;
                Mix_PlayChannel(-1, hitSound, 0);
                if (impactX < block3.x + block3.w / 2)
                {
                    ballVelocityX = -ballSpeed;
                }
                else
                {
                    ballVelocityX = ballSpeed;
                }
                blockHit3 = true;
            }
            if (levelcounter > 1 && Theball.Ball.x + Theball.Ball.w > block4.x && Theball.Ball.x < block4.x + block4.w &&
              Theball.Ball.y + Theball.Ball.h > block4.y && Theball.Ball.y < block4.y + block4.h && blockHit4 == false)
            {
                ballVelocityY = -ballSpeed;
                Mix_PlayChannel(-1, hitSound, 0);

                if (impactX < block4.x + block4.w / 2)
                {
                    ballVelocityX = -ballSpeed;
                }
                else
                {
                    ballVelocityX = ballSpeed;
                }
                blockHit4 = true;
            }
            if (levelcounter > 2 && Theball.Ball.x + Theball.Ball.w > block5.x && Theball.Ball.x < block5.x + block5.w &&
              Theball.Ball.y + Theball.Ball.h > block5.y && Theball.Ball.y < block5.y + block5.h && blockHit5 == false)
            {
                ballVelocityY = -ballSpeed;
                Mix_PlayChannel(-1, hitSound, 0);

                if (impactX < block5.x + block5.w / 2)
                {
                    ballVelocityX = -ballSpeed;
                    Mix_PlayChannel(-1, hitSound, 0);

                }
                else
                {
                    ballVelocityX = ballSpeed;
                    Mix_PlayChannel(-1, hitSound, 0);

                }
                blockHit5 = true;
            }


            if (Theball.Ball.y <= 0 && ballVelocityY < 0)
            {
                ballVelocityY = -ballVelocityY;
                Mix_PlayChannel(-1, hitSound, 0);
            }

            if (Theball.Ball.x <= 0 && ballVelocityX < 0 || Theball.Ball.x + Theball.Ball.w >= 640 && ballVelocityX > 0)
            {
                ballVelocityX = -ballVelocityX;
                Mix_PlayChannel(-1, hitSound, 0);
            }

            if (levelcounter < 2)
            {


                if (blockHit1 && blockHit2 && blockHit3)
                {
                    SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION, "blockbreaker", "You win! press 'c' to uprgade levels 'r' to restart or 'q' to quit  ", Window);
                    while (eventtrue)
                    {
                        TakeEvents();
                    }

                }
            }
            else if (levelcounter < 3)
            {
                if (blockHit1 && blockHit2 && blockHit3 && blockHit4)
                {
                    SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION, "blockbreaker", "You win! press 'r' to restart or 'q' to quit", Window);
                    while (eventtrue)
                    {
                        TakeEvents();
                    }

                }

            }
            else if (blockHit1 && blockHit2 && blockHit3 && blockHit4 && blockHit5)
            {

                SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION, "blockbreaker", "You win! press 'r' to restart or 'q' to quit or 'c' to continue", Window);
                while (eventtrue)
                {
                    TakeEvents();
                }
            }
                
            if (Theball.Ball.y > 640)
            {

                SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION, "blockbreaker", "Game over!  press 'r' to restart'or 'q' to quit", Window);
                while (eventtrue)
                {
                    TakeEvents();
                }


            }
            
            
            eventtrue = true;
        }
        public static void Blockbreaker()
        {
            if (!blockHit1)
            {
                SDL_SetRenderDrawColor(Renderer, 0, 100, 20, 255);
                SDL_RenderFillRect(Renderer, ref block1);
            }
            if (!blockHit2)
            {
                SDL_SetRenderDrawColor(Renderer, 0, 0, 200, 255);
                SDL_RenderFillRect(Renderer, ref block2);
            }
            if (!blockHit3)
            {
                SDL_SetRenderDrawColor(Renderer, 0, 150, 0, 255);
                SDL_RenderFillRect(Renderer, ref block3);
            }
            if (levelcounter > 1 && !blockHit4)
            {

                SDL_SetRenderDrawColor(Renderer, 150, 0, 50, 255);
                SDL_RenderFillRect(Renderer, ref block4);

            }
            if (levelcounter > 2 && !blockHit5)
            {


                SDL_SetRenderDrawColor(Renderer, 0, 90, 24, 255);
                SDL_RenderFillRect(Renderer, ref block5);

            }


            SDL_RenderPresent(Renderer);

        }





        public static void Setup()
        {
            
            
            if (SDL_Init(SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine($"There was an issue starting SDL \n {SDL_GetError()}");
                return;
            }

            SDL_WindowFlags WindowFlags = SDL_WindowFlags.SDL_WINDOW_SHOWN;
            Window = SDL_CreateWindow("Test", 400, 150, 640, 480, WindowFlags);
            if (Window == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the window \n {SDL_GetError()}");
                return;
            }

            SDL_RendererFlags RenderFlags = SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC;
            Renderer = SDL_CreateRenderer(Window, -1, RenderFlags);
            if (Renderer == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the renderer \n {SDL_GetError()}");
                return;
            }



            TTF_Init();
            Mix_Init(MIX_InitFlags.MIX_INIT_MP3);
            
            Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 2048);
            Mix_AllocateChannels(1);
            hitSound = Mix_LoadWAV("sound/bonk.mp3");


            if (hitSound == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue loading the sound \n {SDL_GetError()}");
                return;
            }
           
        }
            


        public static void Render()
        {

            SDL_SetRenderDrawColor(Renderer, 255, 0, 0, 255);
            SDL_RenderClear(Renderer);

        }
        public static void Rendertext()
        {

            IntPtr font = TTF_OpenFont("fonts/arial.ttf", 40);
            string text = $"Level {level}";
            SDL_Color color = new SDL_Color { r = 255, g = 255, b = 255, a = 255 }; IntPtr surface = TTF_RenderText_Solid(font, text, color);
            IntPtr texture = SDL_CreateTextureFromSurface(Renderer, surface);
            SDL_QueryTexture(texture, out _, out _, out textRect.w, out textRect.h);
            SDL_RenderCopy(Renderer, texture, IntPtr.Zero, ref textRect);



            SDL_FreeSurface(surface);
            SDL_DestroyTexture(texture);
            TTF_CloseFont(font);
            if (font == IntPtr.Zero)
            {
                Console.WriteLine($"There is an issue loading the font \n {SDL_GetError()}");
                return;
            }


            if (surface == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the surface \n {SDL_GetError()}");
                return;
            }

            if (texture == IntPtr.Zero)
            {
                Console.WriteLine($"There was an problem creating the texture \n {SDL_GetError()}");
                return;
            }
        }

        public static void ResetGame()
        {

            Theball.Ball.x = 320;
            Theball.Ball.y = 150;
            ballVelocityX = 0;
            ballVelocityY = ballSpeed;


            eventtrue = false;
            blockHit1 = false;
            blockHit2 = false;
            blockHit3 = false;
            blockHit4 = false;
            blockHit5 = false;
            Paddle.my_rectangle.x = 255;
           Paddle.my_rectangle.y = 400;


        }


        public static void Restartinput(SDL_Keysym keysym)
        {
            if (keysym.sym == SDL_Keycode.SDLK_r)
            {
                ResetGame();
            }
            if (keysym.sym == SDL_Keycode.SDLK_q)
            {
                SDL_Quit();
            }
            if (keysym.sym == SDL_Keycode.SDLK_c)
            {
                ResetGame();
                levelcounter++;
                ballSpeed += ballSpeed / 4;
                level++;


            }

        }

       
        

    }
    internal static class Paddle 
    {
        public static void paddle()
        {
            
           
        }
       internal static SDL_Rect my_rectangle = new SDL_Rect
        {
            x = 255,
            y = 400,
            w = 180,
            h = 30
        };


    }
    internal static class Theball
    {
        public static void theBall()
        {


        }
        internal static SDL_Rect Ball = new SDL_Rect
        {
            x = 320,
            y = 150,
            w = 20,
            h = 20


        };


    }



}
