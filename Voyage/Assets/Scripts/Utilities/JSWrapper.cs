using System.Runtime.InteropServices;

namespace Utilities
{
    public static class JSWrapper
    {

        [DllImport("__Internal")]
        internal static extern void Initialize();

        [DllImport("__Internal")]
        internal static extern void CallGenerator(string str);

        // LEFT AS EXAMPLES
        //[DllImport("__Internal")]
        //private static extern void PrintFloatArray(float[] array, int size);
        //
        //[DllImport("__Internal")]
        //private static extern int AddNumbers(int x, int y);
        //
        //[DllImport("__Internal")]
        //private static extern string StringReturnValueFunction();
        //
        //[DllImport("__Internal")]
        //private static extern void BindWebGLTexture(int texture);

        //public static void Run()
        //{
        //    Hello();
        //
        //    CallGenerator("This is a string.");
        //
        //    float[] myArray = new float[10];
        //    PrintFloatArray(myArray, myArray.Length);
        //
        //    int result = AddNumbers(5, 7);
        //    //Debug.Log(result);
        //
        //    //Debug.Log(StringReturnValueFunction());
        //
        //    var texture = new Texture2D(0, 0, TextureFormat.ARGB32, false);
        //    BindWebGLTexture(texture.GetNativeTextureID());
        //}
    }
}