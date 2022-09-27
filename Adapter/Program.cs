using System.Drawing;

var bmp = new Bitmap("C:/resultImage.jpg");
IProductInspector inspector = new IOpenCVProductInspector(new OpenCVInspector());
var res = inspector.Inspect(bmp);


Console.WriteLine(res);


interface IProductInspector
{
    public string Inspect(Bitmap bmp);
}

class HalconInspector : IProductInspector
{
    public string Inspect(Bitmap bmp)
    {
        return "result by halcon";
    }
}

class IOpenCVProductInspector : IProductInspector
{
    private readonly OpenCVInspector _openCVInspector;

    public IOpenCVProductInspector(OpenCVInspector openCVInspector)
    {
        _openCVInspector = openCVInspector;
    }

    public string Inspect(Bitmap bmp)
    {
        byte[] byts = ConvertToByts(bmp);

        return _openCVInspector.Inspect(byts);
    }

    private byte[] ConvertToByts(Bitmap bmp)
    {
        byte[] byts = new byte[] { 1, 1 };
        return byts;
    }
}

class OpenCVInspector
{
    public string Inspect(byte[] byts)
    {
        return "result by ";
    }
}