using UnityEngine;

/// <summary>テクスチャだらけ</summary>
public static class TextureWareHouse
{
    public static Texture2D MakeTexture(int width, int height, Color color)
    {
        Texture2D tex = new(width, height);

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                tex.SetPixel(x, y, color);

        tex.Apply();

        return tex;
    }//width、heightはピクセルの大きさを決める
}
