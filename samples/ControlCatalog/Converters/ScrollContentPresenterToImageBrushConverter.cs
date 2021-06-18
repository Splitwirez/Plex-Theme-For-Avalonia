using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.LogicalTree;
using Avalonia.Markup;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Data;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using Avalonia.VisualTree;
using AvaloniaPlexTheme;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControlCatalog.Converters
{
    public class ScrollContentPresenterToImageBrushConverter : IMultiValueConverter
    {
        static readonly Vector PX_DPI = new Vector(1, 1);
        static readonly Color FILL_COLOR = Color.FromArgb(0xFF, 0x7F, 0x7F, 0x7F);
        static readonly Thickness EDGE_FADE_THICKNESS = new Thickness(24);
        static readonly IEasing EDGE_FADE_EASE = new LinearEasing();
        
        
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            var presenter = (values[0] as ScrollContentPresenter);
            var offset = presenter.Offset;
            var extent = presenter.Extent;

            var padd = presenter.Padding;
            Thickness restrictedPadding = (padd != null) ? (new Thickness(Math.Max(padd.Left, 0), Math.Max(padd.Top, 0), Math.Max(padd.Right, 0), Math.Max(padd.Bottom, 0))) : new Thickness(0);
            
            /*bool l = offset.X > 0;
            bool t = offset.Y > 0;
            bool r = offset.X < extent.Width;
            bool b = offset.Y < extent.Height;*/

            if (presenter.Content is IVisual vis)
            {
                var visBound = vis.Bounds;
                var thisBound = presenter.Bounds;

                double left = thisBound.Left - visBound.Left;
                double top = thisBound.Top - visBound.Top;
                double right = visBound.Right - thisBound.Right;
                double bottom = visBound.Bottom - thisBound.Bottom;

                bool canScrollH = presenter.CanHorizontallyScroll;
                bool canScrollV = presenter.CanVerticallyScroll;
                
                double pLeft = (left + restrictedPadding.Left);
                double pTop = (top + restrictedPadding.Top);
                double pRight = (right + restrictedPadding.Right);
                double pBottom = (bottom + restrictedPadding.Bottom);
                Console.WriteLine($"\tPadded: {pLeft}, {pTop}, {pRight}, {pBottom}");


                bool l = canScrollH && (pLeft > 0);
                bool t = canScrollV && (pTop > 0);
                bool r = canScrollH && (pRight > 0);
                bool b = canScrollV && (pBottom > 0);
                Console.WriteLine($"\tResults: {l}, {t}, {r}, {b}");

                /*bool anyDifferent =
                    (l != _prevL) ||
                    (t != _prevT) ||
                    (r != _prevR) ||
                    (b != _prevB);


                if (anyDifferent)
                {
                    UpdateOpacityMask(l, t, r, b);

                Console.WriteLine($"Converting: {l}, {t}, {r}, {b}");*/

                return GetOpacityMask(presenter, l, t, r, b, restrictedPadding);
            }
            return null;
        }


        static IBrush GetOpacityMask(ScrollContentPresenter pres, bool fadeFromLeft, bool fadeFromTop, bool fadeFromRight, bool fadeFromBottom, Thickness restrictedPadding) //double left, double top, double right, double bottom)
        {
            if (
                    (!fadeFromLeft) &&
                    (!fadeFromTop) &&
                    (!fadeFromRight) &&
                    (!fadeFromBottom)
                )
            {
                return null;
            }

            Size size = pres.Bounds.Size;

            

            bool noSize = (size.Width <= 0) || (size.Height <= 0);
            
            if (noSize)
                return null;
            
            
            
            WriteableBitmap bmp = new WriteableBitmap(PixelSize.FromSize(size, PX_DPI.X), PX_DPI, PixelFormat.Rgba8888, AlphaFormat.Unpremul);
            using (var fb = bmp.Lock())
            {
                unsafe
                {
                    int pxWidth = fb.Size.Width;
                    int pxHeight = fb.Size.Height;
                    int rowBytes = fb.RowBytes;
                    
                    int byteCount = (pxWidth * pxHeight) * 4;
                    
                    
                    Color[,] pixels = new Color[pxWidth, pxHeight];

                    int pixelsTotalLength = pixels.GetLength(0) * pixels.GetLength(1);
                    
                    
                    int exteriorL = fadeFromLeft ? (int)restrictedPadding.Left : 0;
                    int exteriorT = fadeFromTop ? (int)restrictedPadding.Top : 0;
                    int exR = fadeFromRight ? (int)restrictedPadding.Right : 0;
                    int exB = fadeFromBottom ? (int)restrictedPadding.Bottom : 0;
                    
                    int interiorL = fadeFromLeft ? exteriorL + (int)EDGE_FADE_THICKNESS.Left : 0;
                    int interiorT = fadeFromTop ? exteriorT + (int)EDGE_FADE_THICKNESS.Top : 0;
                    int inR = fadeFromRight ? exR + (int)EDGE_FADE_THICKNESS.Right : 0;
                    int inB = fadeFromBottom ? exB + (int)EDGE_FADE_THICKNESS.Bottom : 0;

                    int interiorR = pxWidth - inR;
                    int exteriorR = pxWidth - exR;

                    int interiorB = pxHeight - inB;
                    int exteriorB = pxHeight - exB;

                    
                    //bool noSpaceH = (exteriorL >= interiorL) || (interiorL >= interiorR) || (interiorR >= exteriorR);
                    //bool noSpaceV = (exteriorT >= interiorT) || (interiorT >= interiorB) || (interiorB >= exteriorB);
                    //bool noSpace = (noSpaceH || noSpaceV) && false;

                    bool hasSpaceH = (exteriorL < interiorL) && (interiorL < interiorR) && (interiorR < exteriorR);
                    bool hasSpaceV = (exteriorT < interiorT) && (interiorT < interiorB) && (interiorB < exteriorB);


                    if (!hasSpaceH)
                    {
                        exteriorL = 0;
                        interiorL = 0;
                        interiorR = pxWidth;
                        exteriorR = pxWidth;
                    }

                    if (!hasSpaceV)
                    {
                        exteriorT = 0;
                        interiorT = 0;
                        interiorB = pxHeight;
                        exteriorB = pxHeight;
                    }


                    for (int y = interiorT; y < interiorB; y++)
                    {
                        for (int x = interiorL; x < interiorR; x++)
                        {
                            pixels[x, y] = FILL_COLOR;
                        }
                    }


                    if (hasSpaceH || hasSpaceV)
                    {
                        if (hasSpaceH && fadeFromLeft)
                            FadeEdge(exteriorL, interiorT, interiorL, interiorB, Dock.Left, ref pixels);


                        if (hasSpaceV && fadeFromTop)
                        {
                            FadeEdge(interiorL, exteriorT, interiorR, interiorT, Dock.Top, ref pixels);

                            if (hasSpaceH)
                            {
                                if (fadeFromLeft)
                                    FadeCorner(exteriorL, exteriorT, interiorL, interiorT, StartCorner.TopLeft, ref pixels);
                            
                                if (fadeFromRight)
                                    FadeCorner(interiorR, exteriorT, exteriorR, interiorT, StartCorner.TopRight, ref pixels);
                            }
                        }


                        if (hasSpaceH && fadeFromRight)
                            FadeEdge(interiorR, interiorT, exteriorR, interiorB, Dock.Right, ref pixels);


                        if (hasSpaceV && fadeFromBottom)
                        {
                            FadeEdge(interiorL, interiorB, interiorR, exteriorB, Dock.Bottom, ref pixels);

                            if (hasSpaceH)
                            {
                                if (fadeFromRight)
                                    FadeCorner(interiorR, interiorB, exteriorR, exteriorB, StartCorner.BottomRight, ref pixels);
                            
                                if (fadeFromLeft)
                                    FadeCorner(exteriorL, interiorB, interiorL, exteriorB, StartCorner.BottomLeft, ref pixels);
                            }
                        }
                    }


                    using (var stream = new UnmanagedMemoryStream((byte*)fb.Address, byteCount, byteCount, FileAccess.ReadWrite))
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        for (int y = 0; y < pxHeight; y++)
                        {
                            for (int x = 0; x < pxWidth; x++)
                            {
                                Color currentColor = pixels[x, y];
                                
                                stream.WriteByte(currentColor.B);
                                stream.WriteByte(currentColor.G);
                                stream.WriteByte(currentColor.R);
                                stream.WriteByte(currentColor.A);
                            }
                        }
                    }
                }
            }
            
            return new ImageBrush(bmp);
        }
        

        const byte FADED_PIXEL_RED = 0xFF;
        const byte FADED_PIXEL_GREEN = 0x00;
        const byte FADED_PIXEL_BLUE = 0xFF;
        static void FadePixels(int xStart, int yStart, int xEnd, int yEnd, Func<int, int, byte> getAlpha, ref Color[,] pixels) //int xFirst, int xLast, int yFirst, int yLast, Func<int, int, byte> getAlpha, ref Color[,] pixels, bool xStepToPositive = true, bool yStepToPositive = true) //int xStep = 1, int yStep = 1
        {
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"{nameof(FadePixels)} called");*/
            
            if (xStart >= xEnd)
                throw new Exception($"'{nameof(xStart)}' must be less than '{nameof(xEnd)}'!");
            
            if (yStart >= yEnd)
                throw new Exception($"'{nameof(yStart)}' must be less than '{nameof(yEnd)}'!");
            
            /*int xStep = xStepToPositive ? 1 : -1;
            int yStep = yStepToPositive ? 1 : -1;

            int xStart = xStepToPositive ? xFirst : xLast;
            int xEnd = xStepToPositive ? xLast : xFirst;
            int yStart = yStepToPositive ? yFirst : yLast;
            int yEnd = yStepToPositive ? yLast : yFirst;*/
            
            
            /*int alphaStart = xStart * yStart;
            int alphaEnd = xEnd * yEnd;*/

            for (int y = yStart; y < yEnd; y++)
            {
                /*if (DEBUG_PRINT_ALPHA_CALC)
                    Console.WriteLine($"{nameof(FadePixels)} called");*/
                for (int x = xStart; x < xEnd; x++)
                {
                    pixels[x,y] = Color.FromArgb(getAlpha(x, y), FADED_PIXEL_RED, FADED_PIXEL_GREEN, FADED_PIXEL_BLUE);
                }
            }
        }


        static void FadeEdge(int edgeLeft, int edgeTop, int edgeRight, int edgeBottom, Dock edge, ref Color[,] pixels)
        {
            int startDistance;
            int endDistance;
            int nearInset;
            int farInset;
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            //int startFar = -1;
            //int endFar = -1;

            Func<int, int, byte> calcAlpha;

            switch (edge)
            {
                case (Dock.Top):
                    calcAlpha = (x, y) => CalcAlpha(edgeTop, edgeBottom, y);
                    break;
                case (Dock.Right):
                    calcAlpha = (x, y) => (byte)(byte.MaxValue - CalcAlpha(edgeLeft, edgeRight, x));
                    break;
                case (Dock.Bottom):
                    //DEBUG_PRINT_ALPHA_CALC = true;
                    /*calcAlpha = (x, y) => 
                    {
                        if (edge == Dock.Bottom)
                            DEBUG_PRINT_ALPHA_CALC = true;
                        
                        var ret = CalcAlpha(edgeTop, edgeBottom, y);
                        DEBUG_PRINT_ALPHA_CALC = false;
                        return ret;
                    };*/
                    //DEBUG_PRINT_ALPHA_CALC = false;
                    calcAlpha = (x, y) => (byte)(byte.MaxValue - CalcAlpha(edgeTop, edgeBottom, y));
                    break;
                /*case (Dock.Right):
                    //startFar = width - startDistance;
                    //endFar = width - endDistance;
                    FadePixels(startDistance, endDistance, nearInset, farInset, (x, y) => CalcAlpha(startDistance, endDistance, x), ref pixels);
                    break;*/
                /*case (Dock.Bottom):
                    //startFar = height - startDistance;
                    //endFar = height - endDistance;
                    FadePixels(nearInset, farInset, startDistance, endDistance, (x, y) => CalcAlpha(startDistance, endDistance, y), ref pixels);
                    break;*/
                default: //from left
                    //FadePixels(startDistance, endDistance, nearInset, farInset, (x, y) => CalcAlpha(startDistance, endDistance, x), ref pixels);
                    calcAlpha = (x, y) => CalcAlpha(edgeLeft, edgeRight, x);
                    break;    
            }

            FadePixels(edgeLeft, edgeTop, edgeRight, edgeBottom, calcAlpha, ref pixels);
        }

        static void FadeCorner(int cornerLeft, int cornerTop, int cornerRight, int cornerBottom, StartCorner corner, ref Color[,] pixels)
        {
            /*int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);*/
            /*int cornerBottom = cornerLeft + cornerWidth;
            int cornerRight = cornerTop + cornerHeight;*/
            double cornerWidth = cornerRight - cornerLeft;
            double cornerHeight = cornerTop - cornerBottom;

            Func<int, int, byte> positiveCalcAlpha = 
                (x, y) => CalcAlpha(cornerLeft * cornerTop, cornerRight * cornerBottom, x * y);
            

            Func<int, byte> calcXAlpha = 
                (val) => CalcAlpha(cornerLeft, cornerRight, val);
            
            Func<int, byte> calcYAlpha = 
                (val) => CalcAlpha(cornerTop, cornerRight, val);

            Func<int, byte> calcReversedXAlpha = 
                (val) => 
                {
                    double result = -calcXAlpha(val);

                    result /= (double)byte.MaxValue;

                    result *= cornerWidth;
                    return (byte)((cornerLeft + result) * byte.MaxValue);
                };
            
            Func<int, byte> calcReversedYAlpha = 
                (val) => 
                {
                    double result = -calcYAlpha(val);

                    result /= (double)byte.MaxValue;

                    result *= cornerHeight;
                    return (byte)((cornerTop + result) * byte.MaxValue);
                };
            
            Func<double, double, byte> averageCalculatedAlphas =
                (first, second) => (byte)((first + second) / 2.0);

            bool xToPositive = true;
            bool yToPositive = true;

            Func<int, int, byte> calcAlpha;
            switch (corner)
            {
                case (StartCorner.TopRight):
                    xToPositive = false;
                    calcAlpha = (x, y) => averageCalculatedAlphas(calcReversedXAlpha(x), calcYAlpha(y));
                    break;
                case (StartCorner.BottomRight):
                    xToPositive = false;
                    yToPositive = false;
                    //calcAlpha = (x, y) => CalcAlpha(inFromRight * inFromBottom, width * height, x * y);

                    

                    double brCalcAlpha_first = cornerLeft * cornerTop;
                    double brCalcAlpha_second = cornerRight * cornerBottom;
                    
                    double brCalcAlpha_max = Math.Max(brCalcAlpha_first, brCalcAlpha_second);
                    /*calcAlpha = (x, y) =>
                    {
                        return CalcAlpha(brCalcAlpha_first, brCalcAlpha_second, ((x * y) - brCalcAlpha_max) * -1);
                    };

                    calcAlpha = (x, y) => 
                    {
                        CalcAlpha((cornerLeft * -cornerTop), (-cornerRight * -cornerBottom)
                    }*/
                    calcAlpha = (x, y) => averageCalculatedAlphas(calcReversedXAlpha(x), calcReversedYAlpha(y));
                    break;
                case (StartCorner.BottomLeft):
                    yToPositive = false;
                    //calcAlpha = (x, y) => CalcAlpha(width, inFromBottom, x * y);
                    calcAlpha = (x, y) => averageCalculatedAlphas(calcXAlpha(x), calcReversedYAlpha(y));
                    break;
                default: //top-left
                    //calcAlpha = (x, y) => CalcAlpha(0, cornerWidth * cornerHeight, x * y);
                    //calcAlpha = positiveCalcAlpha;
                    calcAlpha = (x, y) => averageCalculatedAlphas(calcXAlpha(x), calcYAlpha(y));
                    break;
            }

            FadePixels(cornerLeft, cornerTop, cornerRight, cornerBottom, calcAlpha, ref pixels/*, xToPositive, yToPositive*/);
        }

        static byte CalcAlpha(double start, double end, double pos)
        {
            //double extreme1 = Math.Abs(firstExtreme);
            //double extreme2 = Math.Abs(secondExtreme);

            //double start = Math.Min(extreme1, extreme2);
            //double end = Math.Max(extreme1, extreme2);
            if (start >= end)
                throw new Exception($"'{nameof(start)}' must be less than '{nameof(end)}'!");
            
            double progress = Math.Abs(pos);


            /*bool isAtEnds = 
                    (progress <= (start + 1)) ||
                    (progress >= (end - 1));*/
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"{nameof(CalcAlpha)}: {start}, {end}, {progress}...");*/

            double diff = end - start;
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"\t...{nameof(diff)}: {diff}...");*/

            double intoEase = (progress - start) / diff;
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"\t...{nameof(intoEase)}: {intoEase}...");*/
            
            double eased = EDGE_FADE_EASE.Ease(intoEase);
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"\t...{nameof(eased)}: {eased}...");*/



            byte retVal = (byte)((double)eased * (double)byte.MaxValue); //((eased / 100) * (double)byte.MaxValue);
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"...returning {nameof(retVal)}: {retVal}");*/
            
            return retVal;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}