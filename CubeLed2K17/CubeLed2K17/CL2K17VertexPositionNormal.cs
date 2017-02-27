/* *
 * Projet      : CubeLed2K17
 * Description : GUI for user interaction with the 3D Cube led.
 * Authors     : Devaud Alan, Amado Kevin & Mendez Gregory
 * Date        :
 * Version     : 1.0
 */
#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace CubeLed2K17
{
    /// <summary>
    /// Custom vertex type for vertices that have just a
    /// position and a normal, without any texture coordinates.
    /// 
    /// This struct is borrowed from the Primitives3D sample.
    /// </summary>
    public struct CL2K17VertexPositionNormal : IVertexType
    {
        public Vector3 Position;
        public Vector3 Normal;
        

        /// <summary>
        /// Constructor.
        /// </summary>
        public CL2K17VertexPositionNormal(Vector3 position, Vector3 normal)
        {
            Position = position;
            Normal = normal;
        }

        /// <summary>
        /// A VertexDeclaration object, which contains information about the vertex
        /// elements contained within this struct.
        /// </summary>
        public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration
        (
            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
            new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0)
        );

        VertexDeclaration IVertexType.VertexDeclaration
        {
            get { return CL2K17VertexPositionNormal.VertexDeclaration; }
        }

    }
}
