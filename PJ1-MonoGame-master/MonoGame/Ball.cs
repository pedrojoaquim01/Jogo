using C3.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
	public class Ball : GameObject
    {
        public Paddle paddle;
        public Wall topWall;
        public Wall leftWall;
        public Wall rightWall;
        public bool destroi = true;

        public override void Load(ContentManager content)
        {
            animation.textures = new Texture2D[1];
            animation.textures[0] = content.Load<Texture2D>("BallSprite");
            scale = 0.2f;
            position = new Vector2(paddle.position.X + 7, paddle.position.Y - 25);
            velocity = new Vector2(80.0f, 400.0f);

			collider.size = new Vector2( 25.0f, 25.0f );
        }

        public override void Update(GameTime gameTime)
        {
           // float deltaT = ((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);

            if (paddle.atira == true && destroi == true)
            {
                position.Y -= 8.0f;
                position.X += 0;
            }
           
            if(destroi == false)
            {
                position = new Vector2(paddle.position.X + 11, paddle.position.Y - 25);
                destroi = true;
            }

            if(position.X > paddle.position.X + 11 && paddle.atira == false)
            {
                position.X -= 4;
            }

            if (position.X < paddle.position.X + 11 && paddle.atira == false)
            {
                position.X += 4;
            }


            if ( BoxCollider.AreColliding(this, topWall))
            {
                destroi = false;
                paddle.atira = false;
            }

            if (BoxCollider.AreColliding(this, leftWall))
            {
                velocity.X *= -1.0f;
            }

            if (BoxCollider.AreColliding(this, rightWall))
            {
                velocity.X *= -1.0f;
            }
        }
    }
}
