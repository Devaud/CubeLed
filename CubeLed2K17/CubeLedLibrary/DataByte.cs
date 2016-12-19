/*
 *  Project     : CubeLedLibrary
 *  Description :
 *  Author      : Devaud Alan
 *  Version     : 1.0
 *  Date        : 19.12.2016
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFPT
{
    public class DataByte
    {
        #region Fields
        private const int START_INDEX_DATABYTE = 0;
        private const int DEFAULT_DATABYTE_SIZE = 1;
        private const int DEFAULT_DATABYTE_VALUE = 0;
        #endregion

        #region Properties
        public byte[] Data { get; set; }
        public int Length { get { return this.Data.Length; } }

        /// <summary>
        /// Get or set the DataByte value at the specific index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Value at the index</returns>
        public byte this[int index]
        {
            get { return this.Data[index]; }
            set { this.Data[index] = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new DataByte with variable number of parameters
        /// </summary>
        /// <param name="param_databyte"></param>
        public DataByte(params byte[] param_databyte)
        {
            this.Data = new byte[param_databyte.Length];
            param_databyte.CopyTo(this.Data, START_INDEX_DATABYTE);
        }

        /// <summary>
        /// Create new DataByte with default value
        /// </summary>
        public DataByte()
            : this(DEFAULT_DATABYTE_SIZE)
        {

        }

        /// <summary>
        /// Create DataByte with specific size
        /// </summary>
        /// <param name="param_size">DataByte size</param>
        public DataByte(int param_size)
            : this(param_size, DEFAULT_DATABYTE_VALUE)
        {

        }

        /// <summary>
        /// Create DataByte with specific size and initValue
        /// </summary>
        /// <param name="param_size">DataByte size</param>
        /// <param name="param_initValue">DataByte initialize value</param>
        public DataByte(int param_size, byte param_initValue)
        {
            this.Data = new byte[param_size];
            for (int i = 0; i < param_size; i++)
                this.Data[i] = param_initValue;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Return the databyte array
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return this.Data;
        }

        /// <summary>
        /// Get the IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<double> GetEnumerator()
        {
            foreach (int value in this.Data)
                yield return value;
        }
        #endregion
    }
}
