﻿/*
2025.5.15 
Ying TENG
based on step 1,2
for step 3,4 (random star transparency and star size)
*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Media;

namespace GME1003GoblinDanceParty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Declare some variables
        private int _numStars;          //how many stars?
        private List<int> _starsX;      //list of star x-coordinates
        private List<int> _starsY;      //list of star y-coordinates

        private List<float> _starsRotation;                         //list of stars rotation value 
        private List<float> _starsTransparency;                     //list of star transparency value
        private List<float> _starsScale;                            //list of star size

        private Texture2D _starSprite;  //the sprite image for our star

        private Random _rng;            //for all our random number needs
        private Color _starColor;       //let's have fun with colour!!
        private float _starScale;       //star size
        private float _starTransparency;//star transparency
        private float _starRotation;    //star rotation


        //***This is for the goblin. Ignore it.
        Goblin goblin;
        Song music;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _rng = new Random();        //finish setting up our Randon 
            
            _numStars = _rng.Next(50,301);                                  //random number between 100 and 300
            
            _starsX = new List<int>();  //stars X coordinate
            _starsY = new List<int>();  //stars Y coordinate

            _starsRotation = new List<float>();                           //stars rotation value
            _starsTransparency = new List<float>();                        //stars transparency value
            _starsScale = new List<float>();                               //stars size

            _starColor = new Color(128 + _rng.Next(0,129), 128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129));                   //this is a "relatively" easy way to create random colors
            _starScale = _rng.Next(50, 100) / 200f; //this will affect the size of the stars
            _starTransparency = _rng.Next(25, 101)/100f;   //star transparency
            _starRotation = _rng.Next(0, 101) / 100f;       //star rotation

            //use a separate for loop for each list - for practice
            //List of X coordinates
            for (int i = 0; i < _numStars; i++) 
            { 
                _starsX.Add(_rng.Next(0, 801)); //all star x-coordinates are between 0 and 801
            }

            //List of Y coordinates
            for (int i = 0; i < _numStars; i++)
            {
                _starsY.Add(_rng.Next(0, 481)); //all star y-coordinates are between 0 and 480
            }

            //ToDo: List of Colors
            


            //List of scale values
            for(int i=0;i<_numStars;i++)
            {
                _starsScale.Add(_rng.Next(25, 101)/100f);               //size value between 0.25f - 1f      
            }


            //List of transparency values
            for (int i = 0; i < _numStars; i++)
            {
                _starsTransparency.Add(_rng.Next(25, 101) / 100f);               //transparency value between 0.25f - 1f      
            }


            //List of rotation values
            for (int i=0;i<_numStars;i++)
            {
                _starsRotation.Add(_rng.Next(0, 101) / 100f);                   //rotation values between 0f and 1f
            }


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load out star sprite
            _starSprite = Content.Load<Texture2D>("starSprite");


            //***This is for the goblin. Ignore it for now.
            goblin = new Goblin(Content.Load<Texture2D>("goblinIdleSpriteSheet"), 400, 400);
            music = Content.Load<Song>("chiptune");
            
            //if you're tired of the music player, comment this out!
            MediaPlayer.Play(music);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

   
            //***This is for the goblin. Ignore it for now.
            goblin.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            _spriteBatch.Begin();

            //it would be great to have a background image here! 
            //you could make that happen with a single Draw statement.

            //this is where we draw the stars...
            for (int i = 0; i < _numStars; i++) 
            {
                _spriteBatch.Draw(_starSprite, 
                    new Vector2(_starsX[i], _starsY[i]),    //set the star position
                    null,                                   //ignore this
                    _starColor * _starsTransparency[i],                                  //set colour and transparency
                    _starsRotation[i],                                                           //set rotation use the list
                    new Vector2(_starSprite.Width / 2, _starSprite.Height / 2), //ignore this
                    new Vector2(_starsScale[i], _starsScale[i]),                            //set scale (same number 2x)
                    SpriteEffects.None,                     //ignore this
                    0f);                                    //ignore this
            }
            _spriteBatch.End();



            //***This is for the goblin. Ignore it for now.
            goblin.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
