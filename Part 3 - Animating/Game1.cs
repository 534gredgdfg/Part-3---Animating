using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Part_3___Animating
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribbleGreyTexture, tribbleCreamTexture, tribbleBrownTexture, closetTexture;
        Rectangle tribbleGreyRect, tribbleCreamRect, tribbleBrownRect, BackroundRect ;
        Vector2 tribbleGreySpeed, tribbleCreamSpeed, tribbleBrownSpeed, gravity;
        SoundEffect tribbleSound;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Random rand = new Random();
            int randomX = rand.Next(0, 600);

            _graphics.PreferredBackBufferWidth = 800; // Sets the width of the window
            _graphics.PreferredBackBufferHeight = 600; // Sets the height of the window
            _graphics.ApplyChanges(); // Applies the new dimensions

            BackroundRect = new Rectangle(0, 0, 800, 600);

            tribbleGreyRect = new Rectangle(rand.Next(0, 600), rand.Next(0, 300), 120, 120);
            tribbleGreySpeed = new Vector2(2, 1);

            tribbleCreamRect = new Rectangle(rand.Next(0, 600), rand.Next(0, 300), 100, 100);
            tribbleCreamSpeed = new Vector2(-3, 1);

            tribbleBrownRect = new Rectangle(rand.Next(0, 600), rand.Next(0, 300), 80, 80);
            tribbleBrownSpeed = new Vector2(3, 1);

            gravity = new Vector2(0, 1);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            closetTexture = Content.Load<Texture2D>("closet Backround");
            tribbleSound = Content.Load<SoundEffect>("tribble_sound");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            tribbleGreySpeed.Y += (int)gravity.Y;
            tribbleCreamSpeed.Y += (int)gravity.Y;
            tribbleBrownSpeed.Y += (int)gravity.Y;

            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;

            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;


            if (tribbleGreyRect.X > 700  || tribbleGreyRect.X <= 0)
                tribbleGreySpeed.X *= -1;
            

            if (tribbleGreyRect.Y > 480 || tribbleGreyRect.Y <= 0)
            {
                tribbleGreySpeed.Y *= -1;
                tribbleGreyRect.Y = 480;
                tribbleSound.Play();
            }
                


            if (tribbleCreamRect.X > 700 || tribbleCreamRect.X <= 0)
                tribbleCreamSpeed.X *= -1;
            if (tribbleCreamRect.Y > 500 || tribbleCreamRect.Y <= 0)
            {
                tribbleCreamSpeed.Y *= -1;
                tribbleCreamRect.Y = 500;
                tribbleSound.Play();
            }
                

            if (tribbleBrownRect.X > 700 || tribbleBrownRect.X <= 0)
                tribbleBrownSpeed.X *= -1;
            if (tribbleBrownRect.Y > 520 || tribbleBrownRect.Y <= 0)
            {
                tribbleBrownSpeed.Y *= -1;
                tribbleBrownRect.Y = 520;
                tribbleSound.Play();
            }
                



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(closetTexture, BackroundRect, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}