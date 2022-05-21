using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;
using System.Diagnostics;

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
        public class Quantizer
        {
            private int k;
            private double MSTSum;
            private RGBPixel[,] originalImage;
            private RGBPixel[,] quantizedImage;
            private HashSet<int> DistinctColorsSet;
            private vertex[] mst;
            // adjacency list for distinct colors
            private List<int>[] adj;
            // maps hashed distinct color to its mean representation
            private Dictionary<int, int> distColMap;
            private int clusterCount = 1;
            public Stopwatch operationsSW;

            private class vertex
            {
                public int id;
                public int parent;
                public double weight = double.MaxValue;
                public int color; // Hashed color value
                public int cluster_id;
            }
            public Quantizer()
            {
                this.k = 1;
                this.DistinctColorsSet = new HashSet<int>();
                this.operationsSW = new Stopwatch();
                this.distColMap = new Dictionary<int, int>();
            }
            public void quantize(RGBPixel[,] imageMatrix, int k)
            {
                this.k = k;
                // save original image
                this.originalImage = imageMatrix;
                // time distinct colors aggregation
                
                // measure time taken to find distinct colors
                this.operationsSW.Start();
                findDistinctColors();
                this.operationsSW.Stop();

                // adjacency list for distinct colors
                this.adj = new List<int>[this.DistinctColorsSet.Count];
                this.mst = GenerateMST();
                this.MSTSum = CalcMSTSum();
                ExtractClusters();
                Get_Adj();
                BFS();
                ClustersColor();
                ReplaceDistColors();
            }
            private int hashRGB(RGBPixel pi)
            {
                // Time: O(1)
                return (pi.red << 16) + (pi.green << 8) + (pi.blue);
            }
            private RGBPixel unHashRGB(int pi)
            {
                // Time: O(1)
                RGBPixel RGBpi;
                RGBpi.red = Convert.ToByte((pi & 0xff0000) >> 16);
                RGBpi.green = Convert.ToByte((pi & 0xff00) >> 8);
                RGBpi.blue = Convert.ToByte((pi & 0xff));
                return RGBpi;
            }
            private void findDistinctColors()
            {
                // Time: O/theta(N^2) 
                // Space: O(D^2)
                // create set of unique colors in original image
                foreach (var p in this.originalImage)
                {
                    this.DistinctColorsSet.Add(hashRGB(p));
                }
            }
            private int fastPow(int x, uint pow)
            {
                // Time: O(log(pow)) === O(log(2))
                int ret = 1;
                while (pow != 0)
                {
                    if ((pow & 1) == 1)
                        ret *= x;
                    x *= x;
                    pow >>= 1;
                }
                return ret;
            }
            private double getDistance(RGBPixel p1, RGBPixel p2)
            {
                // Time: O(log(2))...? Math.sqrt -> O(1) according to StackOverflow
                return Math.Sqrt(fastPow(p1.red - p2.red, 2) + fastPow(p1.green - p2.green, 2) + fastPow(p1.blue - p2.blue, 2));
            }
            private vertex[] GenerateMST()
            {
                vertex[] vertices = new vertex[this.DistinctColorsSet.Count];
                bool[] isGray = new bool[this.DistinctColorsSet.Count];
                //=================GRAPH CONSTRUCTION======================\\
                // Time: O(D)
                // copy pixels from set to array of class vertices
                int vertices_init_i = 0;
                foreach (var color in DistinctColorsSet)
                {
                    vertices[vertices_init_i] = new vertex();
                    vertices[vertices_init_i].color = color;
                    vertices[vertices_init_i].id = vertices_init_i;

                    adj[vertices_init_i] = new List<int>();
                    isGray[vertices_init_i] = false;

                    vertices_init_i++;
                }
                vertices[0].weight = 0;
                //==================================================\\

                //=================MST CONSTRUCTION======================\\
                // Total Time: O (D^2)
                // holds index of the node with minimum weight
                int bestNode = 0;
                // Time: O(D)
                for (int D=0;D<this.DistinctColorsSet.Count;D++)
                {
                    double bestDist = double.MaxValue;
                    //vertex minVertex = q.Dequeue();
                    isGray[bestNode] = true;
                    //vertices[bestNode].isGray = true;
                    vertex minVertex = vertices[bestNode];

                    // Time: O(D)
                    foreach (var vert in vertices)
                    {
                        //if (!vert.isGray)
                        if (!isGray[vert.id])
                        {
                            double currentDistance = getDistance(unHashRGB(minVertex.color), unHashRGB(vert.color));
                            if (currentDistance < vert.weight)
                            {
                                vert.parent = minVertex.id;
                                vert.weight = currentDistance;
                            }
                            if (vert.weight < bestDist)
                            {
                                bestNode = vert.id;
                                bestDist = vert.weight;
                            }
                        }
                    }
                }
                //==================================================\\
                return vertices;
            }
            private void ExtractClusters()
            {
                //=================CLUSTER EXTRACTION======================\\
                // Time: O(K*D)
                // extract k clusters using k-1 cuts
                for (int cuts = 0; cuts != k - 1; cuts++)
                {
                    double mx = -1;
                    int idx = -1;
                    foreach (var vert in mst)
                    {
                        if (vert.parent != -1 && (mx < vert.weight))
                        {
                            idx = vert.id;
                            mx = vert.weight;
                        }
                    }
                    mst[idx].parent = -1;
                }
                //==================================================\\
            }
            private double CalcMSTSum()
            {
                double res = 0;
                for (int i = 0; i < mst.Length; i++)
                {
                    res += mst[i].weight;
                }
                return Math.Round(res, 1);
            }
            private void Get_Adj()
            {
                foreach (var v in mst)
                {
                    if (v.parent == -1)
                        continue;

                    adj[v.id].Add(v.parent);
                    adj[v.parent].Add(v.id);
                }
            }
            private void BFS()
            {
                bool[] visited = new bool[mst.Length];
                int cluster_id = 0;
                foreach (var v in mst)
                {
                    if (visited[v.id] == true)
                        continue;
                    visited[v.id] = true;
                    Queue<int> nodes = new Queue<int>();
                    nodes.Enqueue(v.id);
                    while (nodes.Count != 0)
                    {
                        int parent = nodes.Dequeue();
                        mst[parent].cluster_id = cluster_id;
                        
                        foreach (var child in adj[parent])
                        {
                            if (!visited[child])
                            {
                                visited[child] = true;
                                nodes.Enqueue(child);
                            }
                        }
                    }

                    cluster_id++;
                    clusterCount++;
                }
            }
            private void ClustersColor()
            {
                int[] counter = new int[clusterCount];
                double[] cluster_red = new double[clusterCount];
                double[] cluster_green = new double[clusterCount];
                double[] cluster_blue = new double[clusterCount];
                
                //calculate sum of each cluster RBG
                //O(d)
                foreach (var t in mst)
                {
                    RGBPixel MyPixel = unHashRGB(t.color);
                    counter[t.cluster_id]++;
                    cluster_red[t.cluster_id] += MyPixel.red;
                    cluster_green[t.cluster_id] += MyPixel.green;
                    cluster_blue[t.cluster_id] += MyPixel.blue;
                }

                //calculate clusters mean 
                //O(d)
                foreach (var t in mst)
                {
                    RGBPixel pixel_mean;
                    pixel_mean.red = (byte)(cluster_red[t.cluster_id] / counter[t.cluster_id]);
                    pixel_mean.green = (byte)(cluster_green[t.cluster_id] / counter[t.cluster_id]);
                    pixel_mean.blue = (byte)(cluster_blue[t.cluster_id] / counter[t.cluster_id]);
                    distColMap.Add(t.color, hashRGB(pixel_mean));
                }

            }
            private void ReplaceDistColors()
            {
                quantizedImage = new RGBPixel[originalImage.GetLength(0), originalImage.GetLength(1)];
                for (int i = 0; i < originalImage.GetLength(0); i++)
                {
                    for (int j = 0; j < originalImage.GetLength(1); j++)
                    {
                        quantizedImage[i, j] = unHashRGB(distColMap[hashRGB(originalImage[i, j])]);
                    }
                }
            }
            public RGBPixel[,] getImage()
            {
                return quantizedImage;
            }
            public int getDistinctColoursCount() { 
                return this.DistinctColorsSet.Count; 
            }
            public double getMSTSum()
            {
                return this.MSTSum;
            }
        }
        
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
