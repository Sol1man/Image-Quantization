using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;
///Algorithms Project
///Intelligent Scissors
///

namespace ImageQuantization
{
    /// <summary>
    /// Holds the pixel color in 3 byte values: red, green and blue
    /// </summary>
    public struct RGBPixel
    {
        public byte red, green, blue;
    }
    public struct RGBPixelD
    {
        public double red, green, blue;
    }
    
  
    /// <summary>
    /// Library of static functions that deal with images
    /// </summary>
    public class ImageOperations
    {
        /// <summary>
        /// Open an image and load it into 2D array of colors (size: Height x Width)
        /// </summary>
        /// <param name="ImagePath">Image file path</param>
        /// <returns>2D array of colors</returns>
        public static RGBPixel[,] OpenImage(string ImagePath)
        {
            Bitmap original_bm = new Bitmap(ImagePath);
            int Height = original_bm.Height;
            int Width = original_bm.Width;

            RGBPixel[,] Buffer = new RGBPixel[Height, Width];

            unsafe
            {
                BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);
                int x, y;
                int nWidth = 0;
                bool Format32 = false;
                bool Format24 = false;
                bool Format8 = false;

                if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    Format24 = true;
                    nWidth = Width * 3;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)
                {
                    Format32 = true;
                    nWidth = Width * 4;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Format8 = true;
                    nWidth = Width;
                }
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (y = 0; y < Height; y++)
                {
                    for (x = 0; x < Width; x++)
                    {
                        if (Format8)
                        {
                            Buffer[y, x].red = Buffer[y, x].green = Buffer[y, x].blue = p[0];
                            p++;
                        }
                        else
                        {
                            Buffer[y, x].red = p[2];
                            Buffer[y, x].green = p[1];
                            Buffer[y, x].blue = p[0];
                            if (Format24) p += 3;
                            else if (Format32) p += 4;
                        }
                    }
                    p += nOffset;
                }
                original_bm.UnlockBits(bmd);
            }

            return Buffer;
        }

        //PRIORY Queue implementation
        public class PriorityQueue<T>
        {
            class Node
            {
                public float Priority { get; set; }
                public T Object { get; set; }
            }

            //object array
            List<Node> queue = new List<Node>();
            int heapSize = -1;
            bool _isMinPriorityQueue;
            public int Count { get { return queue.Count; } }

            /// <summary>
            /// If min queue or max queue
            /// </summary>
            /// <param name="isMinPriorityQueue"></param>
            public PriorityQueue(bool isMinPriorityQueue = false)
            {
                _isMinPriorityQueue = isMinPriorityQueue;
            }


            public void Enqueue(float priority, T obj)
            {
                Node node = new Node() { Priority = priority, Object = obj };
                queue.Add(node);
                heapSize++;
                //Maintaining heap
                if (_isMinPriorityQueue)
                    BuildHeapMin(heapSize);
                else
                    BuildHeapMax(heapSize);
            }
            public T Dequeue()
            {
                if (heapSize > -1)
                {
                    var returnVal = queue[0].Object;
                    queue[0] = queue[heapSize];
                    queue.RemoveAt(heapSize);
                    heapSize--;
                    //Maintaining lowest or highest at root based on min or max queue
                    if (_isMinPriorityQueue)
                        MinHeapify(0);
                    else
                        MaxHeapify(0);
                    return returnVal;
                }
                else
                    throw new Exception("Queue is empty");
            }
            public void UpdatePriority(T obj, float priority)
            {
                int i = 0;
                for (; i <= heapSize; i++)
                {
                    Node node = queue[i];
                    if (object.ReferenceEquals(node.Object, obj))
                    {
                        node.Priority = priority;
                        if (_isMinPriorityQueue)
                        {
                            BuildHeapMin(i);
                            MinHeapify(i);
                        }
                        else
                        {
                            BuildHeapMax(i);
                            MaxHeapify(i);
                        }
                    }
                }
            }
            private void BuildHeapMax(int i)
            {
                while (i >= 0 && queue[(i - 1) / 2].Priority < queue[i].Priority)
                {
                    Swap(i, (i - 1) / 2);
                    i = (i - 1) / 2;
                }
            }
            /// <summary>
            /// Maintain min heap
            /// </summary>
            /// <param name="i"></param>
            private void BuildHeapMin(int i)
            {
                while (i >= 0 && queue[(i - 1) / 2].Priority > queue[i].Priority)
                {
                    Swap(i, (i - 1) / 2);
                    i = (i - 1) / 2;
                }
            }
            private void MaxHeapify(int i)
            {
                int left = ChildL(i);
                int right = ChildR(i);

                int heighst = i;

                if (left <= heapSize && queue[heighst].Priority < queue[left].Priority)
                    heighst = left;
                if (right <= heapSize && queue[heighst].Priority < queue[right].Priority)
                    heighst = right;

                if (heighst != i)
                {
                    Swap(heighst, i);
                    MaxHeapify(heighst);
                }
            }
            private void MinHeapify(int i)
            {
                int left = ChildL(i);
                int right = ChildR(i);

                int lowest = i;

                if (left <= heapSize && queue[lowest].Priority > queue[left].Priority)
                    lowest = left;
                if (right <= heapSize && queue[lowest].Priority > queue[right].Priority)
                    lowest = right;

                if (lowest != i)
                {
                    Swap(lowest, i);
                    MinHeapify(lowest);
                }
            }
            private void Swap(int i, int j)
            {
                var temp = queue[i];
                queue[i] = queue[j];
                queue[j] = temp;
            }
            private int ChildL(int i)
            {
                return i * 2 + 1;
            }
            private int ChildR(int i)
            {
                return i * 2 + 2;
            }
        }
        //========================End of priorty Queue=========================\\
        
        public class Quantizer {
            public int k;
            public int DistinctColours;
            public float MSTSum;
            private RGBPixel[,] originalImage;
            private RGBPixel[,] quantizedImage;
            private HashSet<RGBPixel> DistinctColorsSet;
            private vertex[] mst;


            public class vertex {
                public int id;
                public int parent = -1;
                public float weight = float.MaxValue;
                public bool isgray = false;
                public RGBPixel color;
            }

            public Quantizer()
            {
                this.k = 1;
                this.DistinctColorsSet = new HashSet<RGBPixel>();
            }
            public void quantize(RGBPixel[,] imageMatrix, int k)
            {
                this.k = k;

                // save original image
                this.originalImage = imageMatrix;
                findDistinctColors();
                mst = generatMST();
                MSTSum = calcMSTsum();
            }
            private void findDistinctColors()
            {
                // Time: O/theta(N^2) 
                // Space: O(D^2)

                // create set of unique colors in original image
                foreach (var p in this.originalImage){
                    this.DistinctColorsSet.Add(p);
                }
                // count number of distinct colors (set size)
                this.DistinctColours = DistinctColorsSet.Count;
            }

            private float getDistance(RGBPixel p1, RGBPixel p2)
            {
                // Time: O(1)
                float dist = (float)(Math.Pow(p1.red - p2.red,2) + Math.Pow(p1.green - p2.green,2) + Math.Pow(p1.blue - p2.blue,2));
                return (float) Math.Sqrt(dist);
            }

            public vertex[] generatMST()
            {
                PriorityQueue<vertex> q = new PriorityQueue<vertex>(true);
                int vertexCount = this.DistinctColours;
                vertex[] vertices = new vertex[vertexCount];

                //=================GRAPH CONSTRUCTION======================\\
                //initialize each vertex
                //copy pixels from set to class vertices
                int vertices_init_i = 0;
                foreach(var dc in DistinctColorsSet)
                {
                    vertices[vertices_init_i] = new vertex();
                    vertices[vertices_init_i].color = dc;
                    vertices[vertices_init_i].id = vertices_init_i;
                    
                    if (vertices_init_i==0)
                        vertices[vertices_init_i].weight = 0;
                    q.Enqueue(vertices[vertices_init_i].weight, vertices[vertices_init_i]);
                    vertices_init_i++;
                }
                //==================================================\\


                while( q.Count > 0)
                {
                    //minimize weight of all the vertex's adjacents
                    vertex minVertex = q.Dequeue();
                    int u = minVertex.id;
                    minVertex.isgray = true;
                    vertices[u].isgray = true;

                    foreach (var vert in vertices)
                    {
                        float currentDistance = getDistance(minVertex.color, vert.color);
                        if ((currentDistance < vert.weight) && !(vert.isgray))
                        {
                            vert.parent = minVertex.id;
                            vert.weight = currentDistance;
                            q.UpdatePriority(vert, vert.weight);
                        }
                    }
                }
                return vertices;
            }

            public float calcMSTsum()
            {
                float res = 0;
                for( int i = 0; i < mst.Length; i++)
                {
                    res += mst[i].weight;
                }
                return res;
            }
            // returns image for displaying
            public RGBPixel[,] getImage()
            {
                return quantizedImage;
            }
        }

        /// <summary>
        /// Get the height of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Height</returns>
        public static int GetHeight(RGBPixel[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(0);
        }

        /// <summary>
        /// Get the width of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Width</returns>
        public static int GetWidth(RGBPixel[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(1);
        }

        /// <summary>
        /// Display the given image on the given PictureBox object
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <param name="PicBox">PictureBox object to display the image on it</param>
        public static void DisplayImage(RGBPixel[,] ImageMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        p[2] = ImageMatrix[i, j].red;
                        p[1] = ImageMatrix[i, j].green;
                        p[0] = ImageMatrix[i, j].blue;
                        p += 3;
                    }

                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }


       /// <summary>
       /// Apply Gaussian smoothing filter to enhance the edge detection 
       /// </summary>
       /// <param name="ImageMatrix">Colored image matrix</param>
       /// <param name="filterSize">Gaussian mask size</param>
       /// <param name="sigma">Gaussian sigma</param>
       /// <returns>smoothed color image</returns>
        public static RGBPixel[,] GaussianFilter1D(RGBPixel[,] ImageMatrix, int filterSize, double sigma)
        {
            int Height = GetHeight(ImageMatrix);
            int Width = GetWidth(ImageMatrix);

            RGBPixelD[,] VerFiltered = new RGBPixelD[Height, Width];
            RGBPixel[,] Filtered = new RGBPixel[Height, Width];

           
            // Create Filter in Spatial Domain:
            //=================================
            //make the filter ODD size
            if (filterSize % 2 == 0) filterSize++;

            double[] Filter = new double[filterSize];

            //Compute Filter in Spatial Domain :
            //==================================
            double Sum1 = 0;
            int HalfSize = filterSize / 2;
            for (int y = -HalfSize; y <= HalfSize; y++)
            {
                //Filter[y+HalfSize] = (1.0 / (Math.Sqrt(2 * 22.0/7.0) * Segma)) * Math.Exp(-(double)(y*y) / (double)(2 * Segma * Segma)) ;
                Filter[y + HalfSize] = Math.Exp(-(double)(y * y) / (double)(2 * sigma * sigma));
                Sum1 += Filter[y + HalfSize];
            }
            for (int y = -HalfSize; y <= HalfSize; y++)
            {
                Filter[y + HalfSize] /= Sum1;
            }

            //Filter Original Image Vertically:
            //=================================
            int ii, jj;
            RGBPixelD Sum;
            RGBPixel Item1;
            RGBPixelD Item2;

            for (int j = 0; j < Width; j++)
                for (int i = 0; i < Height; i++)
                {
                    Sum.red = 0;
                    Sum.green = 0;
                    Sum.blue = 0;
                    for (int y = -HalfSize; y <= HalfSize; y++)
                    {
                        ii = i + y;
                        if (ii >= 0 && ii < Height)
                        {
                            Item1 = ImageMatrix[ii, j];
                            Sum.red += Filter[y + HalfSize] * Item1.red;
                            Sum.green += Filter[y + HalfSize] * Item1.green;
                            Sum.blue += Filter[y + HalfSize] * Item1.blue;
                        }
                    }
                    VerFiltered[i, j] = Sum;
                }

            //Filter Resulting Image Horizontally:
            //===================================
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    Sum.red = 0;
                    Sum.green = 0;
                    Sum.blue = 0;
                    for (int x = -HalfSize; x <= HalfSize; x++)
                    {
                        jj = j + x;
                        if (jj >= 0 && jj < Width)
                        {
                            Item2 = VerFiltered[i, jj];
                            Sum.red += Filter[x + HalfSize] * Item2.red;
                            Sum.green += Filter[x + HalfSize] * Item2.green;
                            Sum.blue += Filter[x + HalfSize] * Item2.blue;
                        }
                    }
                    Filtered[i, j].red = (byte)Sum.red;
                    Filtered[i, j].green = (byte)Sum.green;
                    Filtered[i, j].blue = (byte)Sum.blue;
                }

            return Filtered;
        }


    }
}
