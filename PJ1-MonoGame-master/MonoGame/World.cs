using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    public class World
    {
        private List<GameObject> gameObjects;
        private ContentManager content;

        public void InstantiateObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            gameObject.world = this;
            gameObject.Load(content);
        }

        public void LoadObjects(ContentManager contentManager)
        {
            gameObjects = new List<GameObject>();
            content = contentManager;

            Paddle paddle = new Paddle();
            InstantiateObject(paddle);

            Wall topWall = new Wall();
            topWall.position = new Vector2(0.0f, 0.0f);
            topWall.collider.size = new Vector2(1000.0f, 10.0f);
            InstantiateObject(topWall);

            Wall leftWall = new Wall();
            leftWall.position = new Vector2(0.0f, 0.0f);
            leftWall.collider.size = new Vector2(10.0f, 1000.0f);
            InstantiateObject(leftWall);

            Wall rightWall = new Wall();
            rightWall.position = new Vector2(790.0f, 0.0f);
            rightWall.collider.size = new Vector2(10.0f, 1000.0f);
            InstantiateObject(rightWall);

            Ball ball = new Ball();
            ball.paddle = paddle;
            ball.topWall = topWall;
            ball.leftWall = leftWall;
            ball.rightWall = rightWall;
            InstantiateObject(ball);

        }

        public void UpdateObjects(GameTime gameTime)
        {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                GameObject obj = gameObjects[i];
                obj.Update(gameTime);
            }
        }

        public void DrawObjects(SpriteBatch spriteBatch)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(spriteBatch);
            }
        }
    }
}
